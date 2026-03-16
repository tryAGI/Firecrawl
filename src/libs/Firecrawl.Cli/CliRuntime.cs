using System.CommandLine;
using System.CommandLine.Parsing;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firecrawl.Cli;

internal static class CliRuntime
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true,
    };

    public static string GetSettingsFolder()
    {
        var folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".firecrawl");
        Directory.CreateDirectory(folder);

        return folder;
    }

    public static string GetApiKeyPath()
    {
        return Path.Combine(GetSettingsFolder(), "apiKey.txt");
    }

    public static async Task<string> ResolveApiKeyAsync(ParseResult parseResult)
    {
        var apiKeyOption = parseResult.GetValue(CliOptions.ApiKey);
        if (!string.IsNullOrWhiteSpace(apiKeyOption))
        {
            return apiKeyOption;
        }

        var apiKeyFromEnvironment = Environment.GetEnvironmentVariable("FIRECRAWL_API_KEY");
        if (!string.IsNullOrWhiteSpace(apiKeyFromEnvironment))
        {
            return apiKeyFromEnvironment;
        }

        var apiKeyPath = GetApiKeyPath();
        if (File.Exists(apiKeyPath))
        {
            var apiKey = await File.ReadAllTextAsync(apiKeyPath).ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                return apiKey;
            }
        }

        throw new CliException("API key not found. Use --api-key, set FIRECRAWL_API_KEY, or run 'firecrawl auth set <api-key>'.");
    }

    public static async Task<AuthStatusInfo> GetAuthStatusAsync(ParseResult parseResult)
    {
        var apiKeyOption = parseResult.GetValue(CliOptions.ApiKey);
        if (!string.IsNullOrWhiteSpace(apiKeyOption))
        {
            return new AuthStatusInfo(true, "option", MaskSecret(apiKeyOption), null);
        }

        var apiKeyFromEnvironment = Environment.GetEnvironmentVariable("FIRECRAWL_API_KEY");
        if (!string.IsNullOrWhiteSpace(apiKeyFromEnvironment))
        {
            return new AuthStatusInfo(true, "environment", MaskSecret(apiKeyFromEnvironment), null);
        }

        var apiKeyPath = GetApiKeyPath();
        if (File.Exists(apiKeyPath))
        {
            var apiKey = await File.ReadAllTextAsync(apiKeyPath).ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                return new AuthStatusInfo(true, "file", MaskSecret(apiKey), apiKeyPath);
            }
        }

        return new AuthStatusInfo(false, "none", null, File.Exists(apiKeyPath) ? apiKeyPath : null);
    }

    public static async Task<FirecrawlClient> CreateClientAsync(ParseResult parseResult)
    {
        var apiKey = await ResolveApiKeyAsync(parseResult).ConfigureAwait(false);
        var baseUrl = ResolveBaseUrl(parseResult);
        return string.IsNullOrWhiteSpace(baseUrl)
            ? new FirecrawlClient(apiKey)
            : new FirecrawlClient(apiKey, baseUri: new Uri(baseUrl, UriKind.Absolute));
    }

    public static string? ResolveBaseUrl(ParseResult parseResult)
    {
        var fromOption = parseResult.GetValue(CliOptions.BaseUrl);
        if (!string.IsNullOrWhiteSpace(fromOption))
        {
            return fromOption;
        }

        var fromEnvironment = Environment.GetEnvironmentVariable("FIRECRAWL_BASE_URL");
        return string.IsNullOrWhiteSpace(fromEnvironment) ? null : fromEnvironment;
    }

    public static bool WasSpecified(ParseResult parseResult, Symbol optionOrArgument)
    {
        return parseResult.GetResult(optionOrArgument) is not null;
    }

    public static async Task<T?> LoadInputAsync<T>(
        ParseResult parseResult,
        Option<string> inputOption,
        Func<string, JsonSerializerContext, T?> parser)
    {
        var input = parseResult.GetValue(inputOption);
        if (string.IsNullOrWhiteSpace(input))
        {
            return default;
        }

        var json = await ReadTextAsync(input).ConfigureAwait(false);
        var model = parser(json, SourceGenerationContext.Default);
        if (model is null)
        {
            throw new CliException($"Unable to deserialize '{input}' into {typeof(T).Name}.");
        }

        return model;
    }

    public static async Task<string> ReadTextAsync(string pathOrDash)
    {
        if (pathOrDash == "-")
        {
            return await Console.In.ReadToEndAsync().ConfigureAwait(false);
        }

        if (!File.Exists(pathOrDash))
        {
            throw new CliException($"File not found: {pathOrDash}");
        }

        return await File.ReadAllTextAsync(pathOrDash).ConfigureAwait(false);
    }

    public static async Task<object?> ReadJsonValueAsync(
        ParseResult parseResult,
        Option<string>? inlineJsonOption,
        Option<string>? fileOption)
    {
        var inlineSpecified = inlineJsonOption is not null && WasSpecified(parseResult, inlineJsonOption);
        var fileSpecified = fileOption is not null && WasSpecified(parseResult, fileOption);

        if (inlineSpecified && fileSpecified)
        {
            throw new CliException($"Options '{inlineJsonOption!.Name}' and '{fileOption!.Name}' cannot be used together.");
        }

        if (inlineSpecified)
        {
            var inlineJson = parseResult.GetValue(inlineJsonOption!);
            return ParseJsonValue(inlineJson);
        }

        if (fileSpecified)
        {
            var filePath = GetRequiredValue(parseResult, fileOption!);
            var json = await ReadTextAsync(filePath).ConfigureAwait(false);
            return ParseJsonValue(json);
        }

        return null;
    }

    public static Dictionary<string, string>? ReadKeyValuePairs(ParseResult parseResult, Option<string[]> option)
    {
        if (!WasSpecified(parseResult, option))
        {
            return null;
        }

        return ParseKeyValuePairs(GetValues(parseResult, option));
    }

    public static object? BuildObjectFromPairsOrJson(
        Dictionary<string, string>? pairs,
        object? jsonValue)
    {
        if (pairs is not null && jsonValue is not null)
        {
            throw new CliException("Key=value metadata and JSON metadata cannot be used together.");
        }

        if (pairs is not null)
        {
            return JsonSerializer.SerializeToElement(pairs, JsonOptions);
        }

        return jsonValue;
    }

    public static Dictionary<string, string> ParseKeyValuePairs(IEnumerable<string> pairs)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var pair in pairs)
        {
            var index = pair.IndexOf('=', StringComparison.Ordinal);
            if (index <= 0)
            {
                throw new CliException($"Expected key=value but received '{pair}'.");
            }

            result[pair[..index]] = pair[(index + 1)..];
        }

        return result;
    }

    public static async Task WriteOutputAsync(ParseResult parseResult, object response, string humanText, string? outputPath)
    {
        var rendered = parseResult.GetValue(CliOptions.Json)
            ? SerializeJson(response)
            : humanText;

        if (string.IsNullOrWhiteSpace(outputPath))
        {
            await Console.Out.WriteAsync(rendered).ConfigureAwait(false);
            if (!rendered.EndsWith(Environment.NewLine, StringComparison.Ordinal))
            {
                await Console.Out.WriteLineAsync().ConfigureAwait(false);
            }

            return;
        }

        var directory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllTextAsync(outputPath, rendered).ConfigureAwait(false);
    }

    public static async Task WritePageResultFilesAsync(string outputDirectory, IEnumerable<SavedPageResult> items)
    {
        Directory.CreateDirectory(outputDirectory);

        var index = 0;
        foreach (var item in items)
        {
            index++;
            var baseName = !string.IsNullOrWhiteSpace(item.SourceUrl)
                ? SanitizeFileName(item.SourceUrl!)
                : $"item-{index:000}";

            if (!string.IsNullOrWhiteSpace(item.Markdown))
            {
                await File.WriteAllTextAsync(Path.Combine(outputDirectory, $"{baseName}.md"), item.Markdown).ConfigureAwait(false);
            }

            if (!string.IsNullOrWhiteSpace(item.Html))
            {
                await File.WriteAllTextAsync(Path.Combine(outputDirectory, $"{baseName}.html"), item.Html).ConfigureAwait(false);
            }

            if (!string.IsNullOrWhiteSpace(item.RawHtml))
            {
                await File.WriteAllTextAsync(Path.Combine(outputDirectory, $"{baseName}.raw.html"), item.RawHtml).ConfigureAwait(false);
            }

            if (item.Links?.Any() == true)
            {
                await File.WriteAllTextAsync(
                    Path.Combine(outputDirectory, $"{baseName}.links.txt"),
                    string.Join(Environment.NewLine, item.Links)).ConfigureAwait(false);
            }

            var metadataJson = SerializeJson(new
            {
                sourceUrl = item.SourceUrl,
                screenshot = item.Screenshot,
                metadata = item.Metadata,
            });
            await File.WriteAllTextAsync(Path.Combine(outputDirectory, $"{baseName}.metadata.json"), metadataJson).ConfigureAwait(false);
        }
    }

    public static async Task<T> PollAsync<T>(
        Func<Task<T>> fetchAsync,
        Func<T, bool> isComplete,
        TimeSpan pollInterval,
        TimeSpan waitTimeout,
        CancellationToken cancellationToken = default)
    {
        using var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cancellationTokenSource.CancelAfter(waitTimeout);

        while (true)
        {
            cancellationTokenSource.Token.ThrowIfCancellationRequested();

            var result = await fetchAsync().ConfigureAwait(false);
            if (isComplete(result))
            {
                return result;
            }

            await Task.Delay(pollInterval, cancellationTokenSource.Token).ConfigureAwait(false);
        }
    }

    public static TimeSpan ParseDuration(string value, string optionName)
    {
        if (TimeSpan.TryParse(value, out var timeSpan))
        {
            return timeSpan;
        }

        if (value.EndsWith("ms", StringComparison.OrdinalIgnoreCase) &&
            double.TryParse(value[..^2], out var milliseconds))
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        if (EndsWithUnit(value, 's') &&
            double.TryParse(value[..^1], out var seconds))
        {
            return TimeSpan.FromSeconds(seconds);
        }

        if (EndsWithUnit(value, 'm') &&
            double.TryParse(value[..^1], out var minutes))
        {
            return TimeSpan.FromMinutes(minutes);
        }

        if (EndsWithUnit(value, 'h') &&
            double.TryParse(value[..^1], out var hours))
        {
            return TimeSpan.FromHours(hours);
        }

        throw new CliException($"Unable to parse duration '{value}' for option '{optionName}'.");
    }

    public static object ParseJsonValue(string? json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            throw new CliException("JSON content cannot be empty.");
        }

        using var document = JsonDocument.Parse(json);
        return document.RootElement.Clone();
    }

    public static string SerializeJson(object value)
    {
        return JsonSerializer.Serialize(value, JsonOptions);
    }

    public static string MaskSecret(string secret)
    {
        if (string.IsNullOrWhiteSpace(secret))
        {
            return string.Empty;
        }

        return secret.Length <= 8
            ? new string('*', secret.Length)
            : $"{secret[..4]}...{secret[^4..]}";
    }

    public static string SanitizeFileName(string value)
    {
        var normalized = value
            .Replace("https://", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("http://", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("www.", string.Empty, StringComparison.OrdinalIgnoreCase);

        foreach (var invalid in Path.GetInvalidFileNameChars())
        {
            normalized = normalized.Replace(invalid, '_');
        }

        return normalized;
    }

    public static string FormatApiException(ApiException exception)
    {
        var builder = new StringBuilder();
        builder.Append("Request failed");
        builder.Append(" (");
        builder.Append((int)exception.StatusCode);
        builder.Append(')');

        if (!string.IsNullOrWhiteSpace(exception.ResponseBody))
        {
            builder.AppendLine();
            builder.Append(exception.ResponseBody);
        }
        else if (!string.IsNullOrWhiteSpace(exception.Message))
        {
            builder.AppendLine();
            builder.Append(exception.Message);
        }

        return builder.ToString();
    }

    public static string FormatStartResult(string operationName, bool? success, string? id, string nextCommand, string? url = null, IEnumerable<string>? invalidUrls = null)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"{operationName}: {(success == false ? "failed" : "started")}");
        if (!string.IsNullOrWhiteSpace(id))
        {
            AppendInvariantLine(builder, $"id: {id}");
        }

        if (!string.IsNullOrWhiteSpace(url))
        {
            AppendInvariantLine(builder, $"url: {url}");
        }

        if (invalidUrls is not null)
        {
            var values = invalidUrls.Where(static x => !string.IsNullOrWhiteSpace(x)).ToArray();
            if (values.Length > 0)
            {
                AppendInvariantLine(builder, $"invalid-urls: {string.Join(", ", values)}");
            }
        }

        builder.Append(FormattableString.Invariant($"next: {nextCommand}"));
        return builder.ToString();
    }

    public static string FormatScrapeResponse(ScrapeResponse response)
    {
        var builder = new StringBuilder();
        var data = response.Data;
        AppendInvariantLine(builder, $"success: {response.Success}");
        if (data?.Metadata?.Title is { Length: > 0 } title)
        {
            AppendInvariantLine(builder, $"title: {title}");
        }

        if (data?.Metadata?.SourceURL is { Length: > 0 } sourceUrl)
        {
            AppendInvariantLine(builder, $"source-url: {sourceUrl}");
        }

        if (data?.Metadata?.StatusCode is { } statusCode)
        {
            AppendInvariantLine(builder, $"status-code: {statusCode}");
        }

        if (!string.IsNullOrWhiteSpace(data?.Metadata?.Error))
        {
            AppendInvariantLine(builder, $"error: {data.Metadata.Error}");
        }

        AppendSection(builder, "markdown", data?.Markdown);
        AppendSection(builder, "html", data?.Html);
        AppendSection(builder, "rawHtml", data?.RawHtml);
        if (data?.Links is { Count: > 0 })
        {
            AppendSection(builder, "links", string.Join(Environment.NewLine, data.Links));
        }

        AppendSection(builder, "screenshot", data?.Screenshot);
        if (data?.LlmExtraction is not null)
        {
            AppendSection(builder, "llm_extraction", SerializeJson(data.LlmExtraction));
        }

        if (!string.IsNullOrWhiteSpace(data?.Warning))
        {
            AppendSection(builder, "warning", data.Warning);
        }

        if (data?.ChangeTracking is not null)
        {
            AppendSection(builder, "changeTracking", SerializeJson(data.ChangeTracking));
        }

        if (data?.Branding is not null)
        {
            AppendSection(builder, "branding", SerializeJson(data.Branding));
        }

        return builder.ToString().TrimEnd();
    }

    public static string FormatBatchScrapeStatus(BatchScrapeStatusResponseObj response)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"status: {response.Status}");
        AppendInvariantLine(builder, $"completed: {response.Completed}/{response.Total}");
        if (response.CreditsUsed is not null)
        {
            AppendInvariantLine(builder, $"credits-used: {response.CreditsUsed}");
        }

        if (response.ExpiresAt is not null)
        {
            AppendInvariantLine(builder, $"expires-at: {response.ExpiresAt:O}");
        }

        AppendPageItems(
            builder,
            response.Data?.Select(static item => new SavedPageResult(
                item.Metadata?.SourceURL,
                item.Markdown,
                item.Html,
                item.RawHtml,
                item.Links,
                item.Screenshot,
                item.Metadata)));

        return builder.ToString().TrimEnd();
    }

    public static string FormatCrawlStatus(CrawlStatusResponseObj response)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"status: {response.Status}");
        AppendInvariantLine(builder, $"completed: {response.Completed}/{response.Total}");
        if (response.CreditsUsed is not null)
        {
            AppendInvariantLine(builder, $"credits-used: {response.CreditsUsed}");
        }

        if (response.ExpiresAt is not null)
        {
            AppendInvariantLine(builder, $"expires-at: {response.ExpiresAt:O}");
        }

        AppendPageItems(
            builder,
            response.Data?.Select(static item => new SavedPageResult(
                item.Metadata?.SourceURL,
                item.Markdown,
                item.Html,
                item.RawHtml,
                item.Links,
                item.Screenshot,
                item.Metadata)));

        return builder.ToString().TrimEnd();
    }

    public static string FormatErrors(CrawlErrorsResponseObj response)
    {
        var builder = new StringBuilder();
        if (response.Errors is { Count: > 0 })
        {
            foreach (var error in response.Errors)
            {
                AppendInvariantLine(builder, $"url: {error.Id}");
                if (!string.IsNullOrWhiteSpace(error.Error))
                {
                    AppendInvariantLine(builder, $"error: {error.Error}");
                }

                builder.AppendLine();
            }
        }
        else
        {
            builder.AppendLine("No errors.");
        }

        if (response.RobotsBlocked is { Count: > 0 })
        {
            builder.AppendLine("robots-blocked:");
            foreach (var item in response.RobotsBlocked)
            {
                builder.AppendLine(item);
            }
        }

        return builder.ToString().TrimEnd();
    }

    public static string FormatMapResponse(MapResponse response)
    {
        if (response.Links is null || response.Links.Count == 0)
        {
            return $"success: {response.Success}{Environment.NewLine}No links returned.";
        }

        return string.Join(Environment.NewLine, response.Links);
    }

    public static string FormatExtractStatus(ExtractStatusResponse response)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"success: {response.Success}");
        if (response.Status is not null)
        {
            AppendInvariantLine(builder, $"status: {response.Status.Value.ToValueString()}");
        }

        if (response.ExpiresAt is not null)
        {
            AppendInvariantLine(builder, $"expires-at: {response.ExpiresAt:O}");
        }

        if (response.Data is not null)
        {
            AppendSection(builder, "data", SerializeJson(response.Data));
        }

        return builder.ToString().TrimEnd();
    }

    public static string FormatActiveCrawls(GetActiveCrawlsResponse response)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"success: {response.Success}");
        if (response.Crawls is null || response.Crawls.Count == 0)
        {
            builder.Append("No active crawls.");
            return builder.ToString();
        }

        foreach (var crawl in response.Crawls)
        {
            AppendInvariantLine(builder, $"id: {crawl.Id}");
            AppendInvariantLine(builder, $"url: {crawl.Url}");
            AppendInvariantLine(builder, $"team-id: {crawl.TeamId}");
            builder.AppendLine();
        }

        return builder.ToString().TrimEnd();
    }

    public static string FormatDeepResearchStatus(GetDeepResearchStatusResponse response)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"success: {response.Success}");
        if (response.Data?.Status is not null)
        {
            AppendInvariantLine(builder, $"status: {response.Data.Status.Value.ToValueString()}");
        }

        if (response.Data?.CurrentDepth is not null && response.Data?.MaxDepth is not null)
        {
            AppendInvariantLine(builder, $"depth: {response.Data.CurrentDepth}/{response.Data.MaxDepth}");
        }

        if (response.Data?.TotalUrls is not null)
        {
            AppendInvariantLine(builder, $"total-urls: {response.Data.TotalUrls}");
        }

        if (!string.IsNullOrWhiteSpace(response.Data?.Error))
        {
            AppendInvariantLine(builder, $"error: {response.Data.Error}");
        }

        AppendSection(builder, "finalAnalysis", response.Data?.FinalAnalysis);
        if (response.Data?.Json is not null)
        {
            AppendSection(builder, "json", SerializeJson(response.Data.Json));
        }

        if (response.Data?.Sources is { Count: > 0 })
        {
            AppendSection(
                builder,
                "sources",
                string.Join(
                    Environment.NewLine,
                    response.Data.Sources.Select(static source => $"{source.Title} - {source.Url}")));
        }

        return builder.ToString().TrimEnd();
    }

    public static string FormatCreditUsage(GetCreditUsageResponse response)
    {
        return $"success: {response.Success}{Environment.NewLine}remaining-credits: {response.Data?.RemainingCredits}";
    }

    public static string FormatTokenUsage(GetTokenUsageResponse response)
    {
        return $"success: {response.Success}{Environment.NewLine}remaining-tokens: {response.Data?.RemainingTokens}";
    }

    public static string FormatSearchResponse(SearchAndScrapeResponse response)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"success: {response.Success}");
        if (!string.IsNullOrWhiteSpace(response.Warning))
        {
            AppendInvariantLine(builder, $"warning: {response.Warning}");
        }

        if (response.Data is null || response.Data.Count == 0)
        {
            builder.Append("No results.");
            return builder.ToString();
        }

        foreach (var item in response.Data)
        {
            builder.AppendLine(item.Title);
            builder.AppendLine(item.Url);
            if (!string.IsNullOrWhiteSpace(item.Description))
            {
                builder.AppendLine(item.Description);
            }

            if (!string.IsNullOrWhiteSpace(item.Markdown))
            {
                AppendSection(builder, "markdown", item.Markdown);
            }

            builder.AppendLine();
        }

        return builder.ToString().TrimEnd();
    }

    public static string FormatLlmstxtStatus(GetLLMsTxtStatusResponse response)
    {
        var builder = new StringBuilder();
        AppendInvariantLine(builder, $"success: {response.Success}");
        if (response.Status is not null)
        {
            AppendInvariantLine(builder, $"status: {response.Status.Value.ToValueString()}");
        }

        if (response.ExpiresAt is not null)
        {
            AppendInvariantLine(builder, $"expires-at: {response.ExpiresAt:O}");
        }

        AppendSection(builder, "llmstxt", response.Data?.Llmstxt);
        AppendSection(builder, "llmsfulltxt", response.Data?.Llmsfulltxt);

        return builder.ToString().TrimEnd();
    }

    public static IList<OneOf<ScrapeOptionsActionWait, ScrapeOptionsActionScreenshot, ScrapeOptionsActionClick, ScrapeOptionsActionWriteText, ScrapeOptionsActionPressAKey, ScrapeOptionsActionScroll, ScrapeOptionsActionScrape, ScrapeOptionsActionExecuteJavaScript>>? ParseActions(
        IEnumerable<string>? inlineJson,
        IEnumerable<string>? filePaths)
    {
        var payloads = new List<string>();
        if (inlineJson is not null)
        {
            payloads.AddRange(inlineJson.Where(static x => !string.IsNullOrWhiteSpace(x)));
        }

        if (filePaths is not null)
        {
            foreach (var filePath in filePaths.Where(static x => !string.IsNullOrWhiteSpace(x)))
            {
                payloads.Add(File.ReadAllText(filePath));
            }
        }

        if (payloads.Count == 0)
        {
            return null;
        }

        var result = new List<OneOf<ScrapeOptionsActionWait, ScrapeOptionsActionScreenshot, ScrapeOptionsActionClick, ScrapeOptionsActionWriteText, ScrapeOptionsActionPressAKey, ScrapeOptionsActionScroll, ScrapeOptionsActionScrape, ScrapeOptionsActionExecuteJavaScript>>();
        foreach (var payload in payloads)
        {
            using var document = JsonDocument.Parse(payload);
            if (document.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var element in document.RootElement.EnumerateArray())
                {
                    result.Add(ParseAction(element.GetRawText()));
                }
            }
            else
            {
                result.Add(ParseAction(document.RootElement.GetRawText()));
            }
        }

        return result;
    }

    public static void ApplyScrapeOptions(ParseResult parseResult, ScrapeOptionSet options, ScrapeOptions target)
    {
        if (WasSpecified(parseResult, options.Formats))
        {
            target.Formats = parseResult
                .GetValue(options.Formats)!
                .Select(ParseScrapeFormat)
                .ToList();
        }

        ApplyNullable(parseResult, options.OnlyMainContent, value => target.OnlyMainContent = value);
        ApplyList(parseResult, options.IncludeTags, value => target.IncludeTags = value.ToList());
        ApplyList(parseResult, options.ExcludeTags, value => target.ExcludeTags = value.ToList());
        ApplyNullable(parseResult, options.MaxAge, value => target.MaxAge = value);
        if (WasSpecified(parseResult, options.Headers))
        {
            target.Headers = ParseKeyValuePairs(GetValues(parseResult, options.Headers));
        }

        ApplyNullable(parseResult, options.WaitFor, value => target.WaitFor = value);
        ApplyNullable(parseResult, options.Mobile, value => target.Mobile = value);
        ApplyNullable(parseResult, options.SkipTlsVerification, value => target.SkipTlsVerification = value);
        ApplyNullable(parseResult, options.Timeout, value => target.Timeout = value);
        ApplyNullable(parseResult, options.ParsePdf, value => target.ParsePDF = value);

        var jsonOptions = target.JsonOptions;
        if (WasSpecified(parseResult, options.JsonPrompt) ||
            WasSpecified(parseResult, options.JsonSystemPrompt) ||
            WasSpecified(parseResult, options.JsonSchemaJson) ||
            WasSpecified(parseResult, options.JsonSchemaFile))
        {
            jsonOptions ??= new ScrapeOptionsJsonOptions();
            if (WasSpecified(parseResult, options.JsonPrompt))
            {
                jsonOptions.Prompt = parseResult.GetValue(options.JsonPrompt);
            }

            if (WasSpecified(parseResult, options.JsonSystemPrompt))
            {
                jsonOptions.SystemPrompt = parseResult.GetValue(options.JsonSystemPrompt);
            }

            var schemaValue = ReadJsonValueAsync(parseResult, options.JsonSchemaJson, options.JsonSchemaFile).GetAwaiter().GetResult();
            if (schemaValue is not null)
            {
                jsonOptions.Schema = schemaValue;
            }

            target.JsonOptions = jsonOptions;
        }

        if (WasSpecified(parseResult, options.ActionJson) || WasSpecified(parseResult, options.ActionFile))
        {
            target.Actions = ParseActions(
                WasSpecified(parseResult, options.ActionJson) ? parseResult.GetValue(options.ActionJson) : null,
                WasSpecified(parseResult, options.ActionFile) ? parseResult.GetValue(options.ActionFile) : null);
        }

        var location = target.Location;
        if (WasSpecified(parseResult, options.LocationCountry) || WasSpecified(parseResult, options.LocationLanguage))
        {
            location ??= new ScrapeOptionsLocation();
            if (WasSpecified(parseResult, options.LocationCountry))
            {
                location.Country = parseResult.GetValue(options.LocationCountry);
            }

            if (WasSpecified(parseResult, options.LocationLanguage))
            {
                location.Languages = GetValues(parseResult, options.LocationLanguage).ToList();
            }

            target.Location = location;
        }

        ApplyNullable(parseResult, options.RemoveBase64Images, value => target.RemoveBase64Images = value);
        ApplyNullable(parseResult, options.BlockAds, value => target.BlockAds = value);
        if (WasSpecified(parseResult, options.Proxy))
        {
            var proxy = ScrapeOptionsProxyExtensions.ToEnum(parseResult.GetValue(options.Proxy) ?? string.Empty);
            if (proxy is null)
            {
                throw new CliException("Proxy must be one of: basic, enhanced, auto.");
            }

            target.Proxy = proxy;
        }

        var changeOptions = target.ChangeTrackingOptions;
        if (WasSpecified(parseResult, options.ChangeMode) ||
            WasSpecified(parseResult, options.ChangePrompt) ||
            WasSpecified(parseResult, options.ChangeTag) ||
            WasSpecified(parseResult, options.ChangeSchemaJson) ||
            WasSpecified(parseResult, options.ChangeSchemaFile))
        {
            changeOptions ??= new ScrapeOptionsChangeTrackingOptions();
            if (WasSpecified(parseResult, options.ChangeMode))
            {
                changeOptions.Modes = parseResult
                    .GetValue(options.ChangeMode)!
                    .Select(ParseChangeMode)
                    .ToList();
            }

            if (WasSpecified(parseResult, options.ChangePrompt))
            {
                changeOptions.Prompt = parseResult.GetValue(options.ChangePrompt);
            }

            if (WasSpecified(parseResult, options.ChangeTag))
            {
                changeOptions.Tag = parseResult.GetValue(options.ChangeTag);
            }

            var schema = ReadJsonValueAsync(parseResult, options.ChangeSchemaJson, options.ChangeSchemaFile).GetAwaiter().GetResult();
            if (schema is not null)
            {
                changeOptions.Schema = schema;
            }

            target.ChangeTrackingOptions = changeOptions;
        }

        ApplyNullable(parseResult, options.StoreInCache, value => target.StoreInCache = value);
    }

    public static SearchAndScrapeRequestScrapeOptions? BuildSearchScrapeOptions(ParseResult parseResult, Option<string[]> formatsOption)
    {
        if (!WasSpecified(parseResult, formatsOption))
        {
            return null;
        }

        return new SearchAndScrapeRequestScrapeOptions
        {
            Formats = GetValues(parseResult, formatsOption).Select(ParseSearchFormat).ToList(),
        };
    }

    public static string BuildNextCommand(string commandPath, string id)
    {
        return $"firecrawl {commandPath} {id}";
    }

    private static OneOf<ScrapeOptionsActionWait, ScrapeOptionsActionScreenshot, ScrapeOptionsActionClick, ScrapeOptionsActionWriteText, ScrapeOptionsActionPressAKey, ScrapeOptionsActionScroll, ScrapeOptionsActionScrape, ScrapeOptionsActionExecuteJavaScript> ParseAction(string json)
    {
        var action = OneOf<ScrapeOptionsActionWait, ScrapeOptionsActionScreenshot, ScrapeOptionsActionClick, ScrapeOptionsActionWriteText, ScrapeOptionsActionPressAKey, ScrapeOptionsActionScroll, ScrapeOptionsActionScrape, ScrapeOptionsActionExecuteJavaScript>.FromJson(
            json,
            SourceGenerationContext.Default);

        if (action is null)
        {
            throw new CliException("Unable to parse action JSON.");
        }

        return action.Value;
    }

    private static ScrapeOptionsFormat ParseScrapeFormat(string value)
    {
        var parsed = ScrapeOptionsFormatExtensions.ToEnum(value);
        return parsed ?? throw new CliException($"Invalid format '{value}'.");
    }

    private static ScrapeOptionsChangeTrackingOptionsMode ParseChangeMode(string value)
    {
        var parsed = ScrapeOptionsChangeTrackingOptionsModeExtensions.ToEnum(value);
        return parsed ?? throw new CliException($"Invalid change mode '{value}'.");
    }

    public static SearchAndScrapeRequestScrapeOptionsFormat ParseSearchFormat(string value)
    {
        var parsed = SearchAndScrapeRequestScrapeOptionsFormatExtensions.ToEnum(value);
        return parsed ?? throw new CliException($"Invalid search scrape format '{value}'.");
    }

    public static StartDeepResearchRequestFormat ParseResearchFormat(string value)
    {
        var parsed = StartDeepResearchRequestFormatExtensions.ToEnum(value);
        return parsed ?? throw new CliException($"Invalid research format '{value}'.");
    }

    public static ScrapeAndExtractFromUrlsRequestWebhookEvent ParseBatchWebhookEvent(string value)
    {
        var parsed = ScrapeAndExtractFromUrlsRequestWebhookEventExtensions.ToEnum(value);
        return parsed ?? throw new CliException($"Invalid batch webhook event '{value}'.");
    }

    public static CrawlUrlsRequestWebhookEvent ParseCrawlWebhookEvent(string value)
    {
        var parsed = CrawlUrlsRequestWebhookEventExtensions.ToEnum(value);
        return parsed ?? throw new CliException($"Invalid crawl webhook event '{value}'.");
    }

    public static string GetRequiredValue(ParseResult parseResult, Argument<string> argument)
    {
        return parseResult.GetValue(argument)
            ?? throw new CliException($"Argument '{argument.Name}' is required.");
    }

    public static string[] GetRequiredValue(ParseResult parseResult, Argument<string[]> argument)
    {
        return parseResult.GetValue(argument)
            ?? throw new CliException($"Argument '{argument.Name}' is required.");
    }

    public static string GetRequiredValue(ParseResult parseResult, Option<string> option)
    {
        return parseResult.GetValue(option)
            ?? throw new CliException($"Option '{option.Name}' is required.");
    }

    public static string[] GetValues(ParseResult parseResult, Option<string[]> option)
    {
        return parseResult.GetValue(option) ?? [];
    }

    private static void ApplyNullable<T>(ParseResult parseResult, Option<T> option, Action<T> assign)
    {
        if (WasSpecified(parseResult, option))
        {
            assign(parseResult.GetValue(option)!);
        }
    }

    private static void ApplyList(ParseResult parseResult, Option<string[]> option, Action<IReadOnlyList<string>> assign)
    {
        if (WasSpecified(parseResult, option))
        {
            assign(GetValues(parseResult, option));
        }
    }

    private static void AppendSection(StringBuilder builder, string label, string? content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return;
        }

        builder.AppendLine();
        AppendInvariantLine(builder, $"[{label}]");
        builder.AppendLine(content);
    }

    private static void AppendPageItems(StringBuilder builder, IEnumerable<SavedPageResult>? items)
    {
        if (items is null)
        {
            return;
        }

        var materialized = items.ToArray();
        if (materialized.Length == 0)
        {
            return;
        }

        foreach (var item in materialized)
        {
            builder.AppendLine();
            AppendInvariantLine(builder, $"url: {item.SourceUrl}");
            AppendSection(builder, "markdown", item.Markdown);
            AppendSection(builder, "html", item.Html);
            AppendSection(builder, "rawHtml", item.RawHtml);
            if (item.Links?.Any() == true)
            {
                AppendSection(builder, "links", string.Join(Environment.NewLine, item.Links));
            }

            AppendSection(builder, "screenshot", item.Screenshot);
        }
    }

    private static void AppendInvariantLine(StringBuilder builder, FormattableString value)
    {
        builder.AppendLine(value.ToString(CultureInfo.InvariantCulture));
    }

    private static bool EndsWithUnit(string value, char unit)
    {
        return value.Length > 0 && char.ToLowerInvariant(value[^1]) == unit;
    }
}

internal sealed record AuthStatusInfo(bool Authenticated, string Source, string? ApiKeyHint, string? Path);

internal sealed record SavedPageResult(
    string? SourceUrl,
    string? Markdown,
    string? Html,
    string? RawHtml,
    IEnumerable<string>? Links,
    string? Screenshot,
    object? Metadata);
