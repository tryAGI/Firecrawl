#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class ScrapingScrapeAndExtractFromUrlsCommandApiCommand
{
    private static Option<global::System.Collections.Generic.IList<string>> Urls { get; } = new(
        name: @"--urls")
    {
        Description = @"",
    };

    private static Option<bool?> IgnoreInvalidURLs { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--ignore-invalid-urls",
        description: @"If invalid URLs are specified in the urls array, they will be ignored. Instead of them failing the entire request, a batch scrape using the remaining valid URLs will be created, and the invalid URLs will be returned in the invalidURLs field of the response.");

    private static Option<global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsFormat>?> Formats { get; } = new(
        name: @"--formats")
    {
        Description = @"Formats to include in the output. `rawBase64` must be requested by itself.",
    };

    private static Option<bool?> OnlyMainContent { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--only-main-content",
        description: @"Only return the main content of the page excluding headers, navs, footers, etc.");

    private static Option<global::System.Collections.Generic.IList<string>?> IncludeTags { get; } = new(
        name: @"--include-tags")
    {
        Description = @"Tags to include in the output.",
    };

    private static Option<global::System.Collections.Generic.IList<string>?> ExcludeTags { get; } = new(
        name: @"--exclude-tags")
    {
        Description = @"Tags to exclude from the output.",
    };

    private static Option<int?> MaxAge { get; } = new(
        name: @"--max-age")
    {
        Description = @"Returns a cached version of the page if it is younger than this age in milliseconds. If a cached version of the page is older than this value, the page will be scraped. If you do not need extremely fresh data, enabling this can speed up your scrapes by 500%. Defaults to 0, which disables caching.",
    };

    private static Option<int?> WaitFor { get; } = new(
        name: @"--wait-for")
    {
        Description = @"Specify a delay in milliseconds before fetching the content, allowing the page sufficient time to load.",
    };

    private static Option<bool?> Mobile { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--mobile",
        description: @"Set to true if you want to emulate scraping from a mobile device. Useful for testing responsive pages and taking mobile screenshots.");

    private static Option<bool?> SkipTlsVerification { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--skip-tls-verification",
        description: @"Skip TLS certificate verification when making requests");

    private static Option<int?> Timeout { get; } = new(
        name: @"--timeout")
    {
        Description = @"Timeout in milliseconds for the request",
    };

    private static Option<bool?> ParsePDF { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--parse-pdf",
        description: @"Controls how PDF files are processed during scraping. When true, the PDF content is extracted and converted to markdown format, with billing based on the number of pages (1 credit per page). When false, the PDF file is returned in base64 encoding with a flat rate of 1 credit total.");

    private static Option<string?> JsonOptionsSystemPrompt { get; } = new(
        name: @"--json-options-system-prompt")
    {
        Description = @"The system prompt to use for the extraction (Optional)",
    };

    private static Option<string?> JsonOptionsPrompt { get; } = new(
        name: @"--json-options-prompt")
    {
        Description = @"The prompt to use for the extraction without a schema (Optional)",
    };

    private static Option<string?> LocationCountry { get; } = new(
        name: @"--location-country")
    {
        Description = @"ISO 3166-1 alpha-2 country code (e.g., 'US', 'AU', 'DE', 'JP')",
    };

    private static Option<global::System.Collections.Generic.IList<string>?> LocationLanguages { get; } = new(
        name: @"--location-languages")
    {
        Description = @"Preferred languages and locales for the request in order of priority. Defaults to the language of the specified location. See https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Language",
    };

    private static Option<bool?> RemoveBase64Images { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--remove-base64-images",
        description: @"Removes all base 64 images from the output, which may be overwhelmingly long. The image's alt text remains in the output, but the URL is replaced with a placeholder.");

    private static Option<bool?> BlockAds { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--block-ads",
        description: @"Enables ad-blocking and cookie popup blocking.");

    private static Option<global::Firecrawl.ScrapeOptionsProxy?> Proxy { get; } = new(
        name: @"--proxy")
    {
        Description = @"Specifies the type of proxy to use.

 - **basic**: Proxies for scraping sites with none to basic anti-bot solutions. Fast and usually works.
 - **enhanced**: Enhanced proxies for scraping sites with advanced anti-bot solutions. Slower, but more reliable on certain sites. Billed at the same credit cost as basic.
 - **auto**: Firecrawl will automatically retry scraping with enhanced proxies if the basic proxy fails. Enhanced proxies carry no credit surcharge, so either way only the regular cost is billed.

If you do not specify a proxy, Firecrawl will default to basic.",
    };

    private static Option<global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode>?> ChangeTrackingOptionsModes { get; } = new(
        name: @"--change-tracking-options-modes")
    {
        Description = @"The mode to use for change tracking. 'git-diff' provides a detailed diff, and 'json' compares extracted JSON data.",
    };

    private static Option<string?> ChangeTrackingOptionsPrompt { get; } = new(
        name: @"--change-tracking-options-prompt")
    {
        Description = @"Prompt to use for change tracking when using 'json' mode. If not provided, the default prompt will be used.",
    };

    private static Option<string?> ChangeTrackingOptionsTag { get; } = new(
        name: @"--change-tracking-options-tag")
    {
        Description = @"Tag to use for change tracking. Tags can separate change tracking history into separate ""branches"", where change tracking with a specific tagwill only compare to scrapes made in the same tag. If not provided, the default tag (null) will be used.",
    };

    private static Option<bool?> StoreInCache { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--store-in-cache",
        description: @"If true, the page will be stored in the Firecrawl index and cache. Setting this to false is useful if your scraping activity may have data protection concerns. Using some parameters associated with sensitive scraping (actions, headers) will force this parameter to be false.");
      private static Option<string?> Input { get; } = new(@"--input")
      {
          Description = "Load request JSON from a file path, '-' for stdin, or an inline JSON object/array string.",
      };

      private static Option<string?> RequestJson { get; } = new(@"--request-json")
      {
          Description = "Request body as JSON.",
          Hidden = true,
      };

      private static Option<string?> RequestFile { get; } = new(@"--request-file")
      {
          Description = "Path to a JSON request file, or '-' for stdin.",
          Hidden = true,
      };
      private static Option<bool> Wait { get; } = new("--wait")
      {
          Description = "Poll the generated wait helper until the resource reaches a terminal state.",
      };

      private static Option<string> PollInterval { get; } = new("--poll-interval")
      {
          Description = "Polling interval, for example 250ms, 2s, 30m, or 01:00:00.",
          DefaultValueFactory = _ => "2s",
      };

      private static Option<string> WaitTimeout { get; } = new("--wait-timeout")
      {
          Description = "Maximum time to wait before timing out, for example 30m or 00:30:00.",
          DefaultValueFactory = _ => "30m",
      };

                    private static string FormatResponse(ParseResult parseResult, global::Firecrawl.BatchScrapeResponseObj value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
                    {
                        string? text = null;
                        CustomizeResponseText(parseResult, value, ref text);
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            return text;
                        }

                        var hints = new Dictionary<string, CliFormatHint>(StringComparer.OrdinalIgnoreCase)
                        {
                        };
                        CustomizeResponseFormatHints(hints);
                        return CliRuntime.FormatHumanReadable(value, context, truncateLongStrings, hints);
                    }

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Firecrawl.BatchScrapeResponseObj value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    static partial void CustomizeCommand(ref Command command);

    public static Command Create(string? commandName = null)
    {
        var command = new Command(commandName ?? @"scrape-and-extract-from-urls", @"Scrape multiple URLs and optionally extract information using an LLM");
                        command.Options.Add(Urls);
                        command.Options.Add(IgnoreInvalidURLs);
                        command.Options.Add(Formats);
                        command.Options.Add(OnlyMainContent);
                        command.Options.Add(IncludeTags);
                        command.Options.Add(ExcludeTags);
                        command.Options.Add(MaxAge);
                        command.Options.Add(WaitFor);
                        command.Options.Add(Mobile);
                        command.Options.Add(SkipTlsVerification);
                        command.Options.Add(Timeout);
                        command.Options.Add(ParsePDF);
                        command.Options.Add(JsonOptionsSystemPrompt);
                        command.Options.Add(JsonOptionsPrompt);
                        command.Options.Add(LocationCountry);
                        command.Options.Add(LocationLanguages);
                        command.Options.Add(RemoveBase64Images);
                        command.Options.Add(BlockAds);
                        command.Options.Add(Proxy);
                        command.Options.Add(ChangeTrackingOptionsModes);
                        command.Options.Add(ChangeTrackingOptionsPrompt);
                        command.Options.Add(ChangeTrackingOptionsTag);
                        command.Options.Add(StoreInCache);
          command.Options.Add(Input);
          command.Options.Add(RequestJson);
          command.Options.Add(RequestFile);
          command.Validators.Add(result =>
          {
              var hasInput = result.GetResult(Input) is not null;
              var hasRequestJson = result.GetResult(RequestJson) is not null;
              var hasRequestFile = result.GetResult(RequestFile) is not null;
              var specifiedCount = (hasInput ? 1 : 0) + (hasRequestJson ? 1 : 0) + (hasRequestFile ? 1 : 0);
              if (specifiedCount > 1)
              {
                  result.AddError(@"Specify at most one of --input, --request-json, or --request-file.");
              }
          });
          command.Options.Add(Wait);
          command.Options.Add(PollInterval);
          command.Options.Add(WaitTimeout);
        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Firecrawl.AllOf<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions>>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Firecrawl.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var urls = (CliRuntime.WasSpecified(parseResult, Urls)
                            ? parseResult.GetValue(Urls)
                            : __requestBase.Value1?.Urls)
                            ?? throw new CliException(@"Specify urls or include it in the base request body.");
                        var ignoreInvalidURLs = CliRuntime.WasSpecified(parseResult, IgnoreInvalidURLs) ? parseResult.GetValue(IgnoreInvalidURLs) : (__requestBase is { } __IgnoreInvalidURLsBaseValue ? __IgnoreInvalidURLsBaseValue.Value1?.IgnoreInvalidURLs : default);
                        var formats = CliRuntime.WasSpecified(parseResult, Formats) ? parseResult.GetValue(Formats) : (__requestBase is { } __FormatsBaseValue ? __FormatsBaseValue.Value2?.Formats : default);
                        var onlyMainContent = CliRuntime.WasSpecified(parseResult, OnlyMainContent) ? parseResult.GetValue(OnlyMainContent) : (__requestBase is { } __OnlyMainContentBaseValue ? __OnlyMainContentBaseValue.Value2?.OnlyMainContent : default);
                        var includeTags = CliRuntime.WasSpecified(parseResult, IncludeTags) ? parseResult.GetValue(IncludeTags) : (__requestBase is { } __IncludeTagsBaseValue ? __IncludeTagsBaseValue.Value2?.IncludeTags : default);
                        var excludeTags = CliRuntime.WasSpecified(parseResult, ExcludeTags) ? parseResult.GetValue(ExcludeTags) : (__requestBase is { } __ExcludeTagsBaseValue ? __ExcludeTagsBaseValue.Value2?.ExcludeTags : default);
                        var maxAge = CliRuntime.WasSpecified(parseResult, MaxAge) ? parseResult.GetValue(MaxAge) : (__requestBase is { } __MaxAgeBaseValue ? __MaxAgeBaseValue.Value2?.MaxAge : default);
                        var waitFor = CliRuntime.WasSpecified(parseResult, WaitFor) ? parseResult.GetValue(WaitFor) : (__requestBase is { } __WaitForBaseValue ? __WaitForBaseValue.Value2?.WaitFor : default);
                        var mobile = CliRuntime.WasSpecified(parseResult, Mobile) ? parseResult.GetValue(Mobile) : (__requestBase is { } __MobileBaseValue ? __MobileBaseValue.Value2?.Mobile : default);
                        var skipTlsVerification = CliRuntime.WasSpecified(parseResult, SkipTlsVerification) ? parseResult.GetValue(SkipTlsVerification) : (__requestBase is { } __SkipTlsVerificationBaseValue ? __SkipTlsVerificationBaseValue.Value2?.SkipTlsVerification : default);
                        var timeout = CliRuntime.WasSpecified(parseResult, Timeout) ? parseResult.GetValue(Timeout) : (__requestBase is { } __TimeoutBaseValue ? __TimeoutBaseValue.Value2?.Timeout : default);
                        var parsePDF = CliRuntime.WasSpecified(parseResult, ParsePDF) ? parseResult.GetValue(ParsePDF) : (__requestBase is { } __ParsePDFBaseValue ? __ParsePDFBaseValue.Value2?.ParsePDF : default);
                        var jsonOptionsSystemPrompt = CliRuntime.WasSpecified(parseResult, JsonOptionsSystemPrompt) ? parseResult.GetValue(JsonOptionsSystemPrompt) : (__requestBase is { } __JsonOptionsSystemPromptBaseValue ? __JsonOptionsSystemPromptBaseValue.Value2?.JsonOptions?.SystemPrompt : default);
                        var jsonOptionsPrompt = CliRuntime.WasSpecified(parseResult, JsonOptionsPrompt) ? parseResult.GetValue(JsonOptionsPrompt) : (__requestBase is { } __JsonOptionsPromptBaseValue ? __JsonOptionsPromptBaseValue.Value2?.JsonOptions?.Prompt : default);
                        var locationCountry = CliRuntime.WasSpecified(parseResult, LocationCountry) ? parseResult.GetValue(LocationCountry) : (__requestBase is { } __LocationCountryBaseValue ? __LocationCountryBaseValue.Value2?.Location?.Country : default);
                        var locationLanguages = CliRuntime.WasSpecified(parseResult, LocationLanguages) ? parseResult.GetValue(LocationLanguages) : (__requestBase is { } __LocationLanguagesBaseValue ? __LocationLanguagesBaseValue.Value2?.Location?.Languages : default);
                        var removeBase64Images = CliRuntime.WasSpecified(parseResult, RemoveBase64Images) ? parseResult.GetValue(RemoveBase64Images) : (__requestBase is { } __RemoveBase64ImagesBaseValue ? __RemoveBase64ImagesBaseValue.Value2?.RemoveBase64Images : default);
                        var blockAds = CliRuntime.WasSpecified(parseResult, BlockAds) ? parseResult.GetValue(BlockAds) : (__requestBase is { } __BlockAdsBaseValue ? __BlockAdsBaseValue.Value2?.BlockAds : default);
                        var proxy = CliRuntime.WasSpecified(parseResult, Proxy) ? parseResult.GetValue(Proxy) : (__requestBase is { } __ProxyBaseValue ? __ProxyBaseValue.Value2?.Proxy : default);
                        var changeTrackingOptionsModes = CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsModes) ? parseResult.GetValue(ChangeTrackingOptionsModes) : (__requestBase is { } __ChangeTrackingOptionsModesBaseValue ? __ChangeTrackingOptionsModesBaseValue.Value2?.ChangeTrackingOptions?.Modes : default);
                        var changeTrackingOptionsPrompt = CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsPrompt) ? parseResult.GetValue(ChangeTrackingOptionsPrompt) : (__requestBase is { } __ChangeTrackingOptionsPromptBaseValue ? __ChangeTrackingOptionsPromptBaseValue.Value2?.ChangeTrackingOptions?.Prompt : default);
                        var changeTrackingOptionsTag = CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsTag) ? parseResult.GetValue(ChangeTrackingOptionsTag) : (__requestBase is { } __ChangeTrackingOptionsTagBaseValue ? __ChangeTrackingOptionsTagBaseValue.Value2?.ChangeTrackingOptions?.Tag : default);
                        var storeInCache = CliRuntime.WasSpecified(parseResult, StoreInCache) ? parseResult.GetValue(StoreInCache) : (__requestBase is { } __StoreInCacheBaseValue ? __StoreInCacheBaseValue.Value2?.StoreInCache : default);
                        var __component1 = __requestBase.Value1 ?? new global::Firecrawl.ScrapeAndExtractFromUrlsRequest2 { Urls = urls! };
                        __component1.Urls = urls;
                        __component1.IgnoreInvalidURLs = ignoreInvalidURLs;

                        var __component2 = __requestBase.Value2 ?? new global::Firecrawl.ScrapeOptions();
                        __component2.Formats = formats;
                        __component2.OnlyMainContent = onlyMainContent;
                        __component2.IncludeTags = includeTags;
                        __component2.ExcludeTags = excludeTags;
                        __component2.MaxAge = maxAge;
                        __component2.WaitFor = waitFor;
                        __component2.Mobile = mobile;
                        __component2.SkipTlsVerification = skipTlsVerification;
                        __component2.Timeout = timeout;
                        __component2.ParsePDF = parsePDF;
                        __component2.RemoveBase64Images = removeBase64Images;
                        __component2.BlockAds = blockAds;
                        __component2.Proxy = proxy;
                        __component2.StoreInCache = storeInCache;
                        if (CliRuntime.WasSpecified(parseResult, JsonOptionsSystemPrompt) || CliRuntime.WasSpecified(parseResult, JsonOptionsPrompt))
                        {
                            __component2.JsonOptions ??= new global::Firecrawl.ScrapeOptionsJsonOptions();
                            if (CliRuntime.WasSpecified(parseResult, JsonOptionsSystemPrompt))
                            {
                                __component2.JsonOptions.SystemPrompt = jsonOptionsSystemPrompt;
                            }
                            if (CliRuntime.WasSpecified(parseResult, JsonOptionsPrompt))
                            {
                                __component2.JsonOptions.Prompt = jsonOptionsPrompt;
                            }
                        }
                        if (CliRuntime.WasSpecified(parseResult, LocationCountry) || CliRuntime.WasSpecified(parseResult, LocationLanguages))
                        {
                            __component2.Location ??= new global::Firecrawl.ScrapeOptionsLocation();
                            if (CliRuntime.WasSpecified(parseResult, LocationCountry))
                            {
                                __component2.Location.Country = locationCountry;
                            }
                            if (CliRuntime.WasSpecified(parseResult, LocationLanguages))
                            {
                                __component2.Location.Languages = locationLanguages;
                            }
                        }
                        if (CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsModes) || CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsPrompt) || CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsTag))
                        {
                            __component2.ChangeTrackingOptions ??= new global::Firecrawl.ScrapeOptionsChangeTrackingOptions();
                            if (CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsModes))
                            {
                                __component2.ChangeTrackingOptions.Modes = changeTrackingOptionsModes;
                            }
                            if (CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsPrompt))
                            {
                                __component2.ChangeTrackingOptions.Prompt = changeTrackingOptionsPrompt;
                            }
                            if (CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsTag))
                            {
                                __component2.ChangeTrackingOptions.Tag = changeTrackingOptionsTag;
                            }
                        }
                        if (CliRuntime.WasSpecified(parseResult, Formats))
                        {
                            __component1.AdditionalProperties?.Remove(@"formats");
                        }
                        if (CliRuntime.WasSpecified(parseResult, OnlyMainContent))
                        {
                            __component1.AdditionalProperties?.Remove(@"onlyMainContent");
                        }
                        if (CliRuntime.WasSpecified(parseResult, IncludeTags))
                        {
                            __component1.AdditionalProperties?.Remove(@"includeTags");
                        }
                        if (CliRuntime.WasSpecified(parseResult, ExcludeTags))
                        {
                            __component1.AdditionalProperties?.Remove(@"excludeTags");
                        }
                        if (CliRuntime.WasSpecified(parseResult, MaxAge))
                        {
                            __component1.AdditionalProperties?.Remove(@"maxAge");
                        }
                        if (CliRuntime.WasSpecified(parseResult, WaitFor))
                        {
                            __component1.AdditionalProperties?.Remove(@"waitFor");
                        }
                        if (CliRuntime.WasSpecified(parseResult, Mobile))
                        {
                            __component1.AdditionalProperties?.Remove(@"mobile");
                        }
                        if (CliRuntime.WasSpecified(parseResult, SkipTlsVerification))
                        {
                            __component1.AdditionalProperties?.Remove(@"skipTlsVerification");
                        }
                        if (CliRuntime.WasSpecified(parseResult, Timeout))
                        {
                            __component1.AdditionalProperties?.Remove(@"timeout");
                        }
                        if (CliRuntime.WasSpecified(parseResult, ParsePDF))
                        {
                            __component1.AdditionalProperties?.Remove(@"parsePDF");
                        }
                        if (CliRuntime.WasSpecified(parseResult, JsonOptionsSystemPrompt) || CliRuntime.WasSpecified(parseResult, JsonOptionsPrompt))
                        {
                            __component1.AdditionalProperties?.Remove(@"jsonOptions");
                        }
                        if (CliRuntime.WasSpecified(parseResult, LocationCountry) || CliRuntime.WasSpecified(parseResult, LocationLanguages))
                        {
                            __component1.AdditionalProperties?.Remove(@"location");
                        }
                        if (CliRuntime.WasSpecified(parseResult, RemoveBase64Images))
                        {
                            __component1.AdditionalProperties?.Remove(@"removeBase64Images");
                        }
                        if (CliRuntime.WasSpecified(parseResult, BlockAds))
                        {
                            __component1.AdditionalProperties?.Remove(@"blockAds");
                        }
                        if (CliRuntime.WasSpecified(parseResult, Proxy))
                        {
                            __component1.AdditionalProperties?.Remove(@"proxy");
                        }
                        if (CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsModes) || CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsPrompt) || CliRuntime.WasSpecified(parseResult, ChangeTrackingOptionsTag))
                        {
                            __component1.AdditionalProperties?.Remove(@"changeTrackingOptions");
                        }
                        if (CliRuntime.WasSpecified(parseResult, StoreInCache))
                        {
                            __component1.AdditionalProperties?.Remove(@"storeInCache");
                        }
                        if (CliRuntime.WasSpecified(parseResult, Urls))
                        {
                            __component2.AdditionalProperties?.Remove(@"urls");
                        }
                        if (CliRuntime.WasSpecified(parseResult, IgnoreInvalidURLs))
                        {
                            __component2.AdditionalProperties?.Remove(@"ignoreInvalidURLs");
                        }
                        var request = new global::Firecrawl.AllOf<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions>(
                            __component1, __component2);
          var wait = parseResult.GetValue(Wait);
          var pollInterval = wait ? CliRuntime.ParseDuration(parseResult.GetRequiredValue(PollInterval), PollInterval.Name) : default;
          var waitTimeout = wait ? CliRuntime.ParseDuration(parseResult.GetRequiredValue(WaitTimeout), WaitTimeout.Name) : default;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);

                                if (wait)
                                {
                                var createResponse = await client.Scraping.ScrapeAndExtractFromUrlsAsync(

                                    request: request,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);
                                    var resourceId = global::System.Convert.ToString(
                                        createResponse.Id,
                                        global::System.Globalization.CultureInfo.InvariantCulture);
                                    if (string.IsNullOrWhiteSpace(resourceId))
                                    {
                                        throw new CliException("The create response did not contain a job id.");
                                    }

                                    var waitResponse = await CliRuntime.PollUntilTerminalAsync(
                                        fetchAsync: token => client.Scraping.GetBatchScrapeStatusAsync(
                                            id: resourceId,
                                            cancellationToken: token),
                                        pollInterval: pollInterval,
                                        waitTimeout: waitTimeout,
                                        context: global::Firecrawl.SourceGenerationContext.Default,
                                        cancellationToken: cancellationToken).ConfigureAwait(false);
                                    await CliRuntime.WriteResponseAsync(
                                        parseResult,
                                        waitResponse,
                                        global::Firecrawl.SourceGenerationContext.Default,
                                        cancellationToken: cancellationToken).ConfigureAwait(false);
                                    return;
                                }

                                var response = await client.Scraping.ScrapeAndExtractFromUrlsAsync(

                                    request: request,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                if (!await CliRuntime.TryWriteOutputDirectoryAsync(
                                        parseResult,
                                        response,
                                        global::Firecrawl.SourceGenerationContext.Default,
                                        @"InvalidURLs",
                                        cancellationToken).ConfigureAwait(false))
                                {
                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Firecrawl.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
                                }
            }, cancellationToken).ConfigureAwait(false));
        CustomizeCommand(ref command);
        return command;
    }
}