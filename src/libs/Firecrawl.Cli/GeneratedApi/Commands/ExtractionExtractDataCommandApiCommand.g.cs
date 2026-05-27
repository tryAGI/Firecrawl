#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class ExtractionExtractDataCommandApiCommand
{
    private static Option<global::System.Collections.Generic.IList<string>> Urls { get; } = new(
        name: @"--urls")
    {
        Description = @"",
        Required = true,
    };

    private static Option<string?> Prompt { get; } = new(
        name: @"--prompt")
    {
        Description = @"Prompt to guide the extraction process",
    };

    private static Option<object?> Schema { get; } = new(
        name: @"--schema")
    {
        Description = @"Schema to define the structure of the extracted data. Must conform to [JSON Schema](https://json-schema.org/).",
    };

    private static Option<bool?> EnableWebSearch { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--enable-web-search",
        description: @"When true, the extraction will use web search to find additional data");

    private static Option<bool?> IgnoreSitemap { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--ignore-sitemap",
        description: @"When true, sitemap.xml files will be ignored during website scanning");

    private static Option<bool?> IncludeSubdomains { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--include-subdomains",
        description: @"When true, subdomains of the provided URLs will also be scanned");

    private static Option<bool?> ShowSources { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--show-sources",
        description: @"When true, the sources used to extract the data will be included in the response as `sources` key");

    private static Option<bool?> IgnoreInvalidURLs { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--ignore-invalid-urls",
        description: @"If invalid URLs are specified in the urls array, they will be ignored. Instead of them failing the entire request, an extract using the remaining valid URLs will be performed, and the invalid URLs will be returned in the invalidURLs field of the response.");
    private static readonly ScrapeOptionsOptionSet ScrapeOptionsOptions = ScrapeOptionsOptionSet.Create(@"scrape");
      private static Option<string?> Input { get; } = new("--input")
      {
          Description = "Load request JSON from a file path, '-' for stdin, or an inline JSON object/array string.",
      };

      private static Option<string?> RequestJson { get; } = new("--request-json")
      {
          Description = "Request body as JSON.",
          Hidden = true,
      };

      private static Option<string?> RequestFile { get; } = new("--request-file")
      {
          Description = "Path to a JSON request file, or '-' for stdin.",
          Hidden = true,
      };

                    private static string FormatResponse(ParseResult parseResult, global::Firecrawl.ExtractResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Firecrawl.ExtractResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"extract-data", @"Extract structured data from pages using LLMs");
                        command.Options.Add(Urls);
                        command.Options.Add(Prompt);
                        command.Options.Add(Schema);
                        command.Options.Add(EnableWebSearch);
                        command.Options.Add(IgnoreSitemap);
                        command.Options.Add(IncludeSubdomains);
                        command.Options.Add(ShowSources);
                        command.Options.Add(IgnoreInvalidURLs);                        command.Options.Add(ScrapeOptionsOptions.Formats);
                        command.Options.Add(ScrapeOptionsOptions.OnlyMainContent);
                        command.Options.Add(ScrapeOptionsOptions.IncludeTags);
                        command.Options.Add(ScrapeOptionsOptions.ExcludeTags);
                        command.Options.Add(ScrapeOptionsOptions.MaxAge);
                        command.Options.Add(ScrapeOptionsOptions.WaitFor);
                        command.Options.Add(ScrapeOptionsOptions.Mobile);
                        command.Options.Add(ScrapeOptionsOptions.SkipTlsVerification);
                        command.Options.Add(ScrapeOptionsOptions.Timeout);
                        command.Options.Add(ScrapeOptionsOptions.ParsePDF);
                        command.Options.Add(ScrapeOptionsOptions.RemoveBase64Images);
                        command.Options.Add(ScrapeOptionsOptions.BlockAds);
                        command.Options.Add(ScrapeOptionsOptions.Proxy);
                        command.Options.Add(ScrapeOptionsOptions.StoreInCache);
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
                  result.AddError("Specify at most one of --input, --request-json, or --request-file.");
              }
          });

        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Firecrawl.ExtractDataRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Firecrawl.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var urls = parseResult.GetRequiredValue(Urls);
                        var prompt = parseResult.GetValue(Prompt) ?? __requestBase?.Prompt;
                        var schema = parseResult.GetValue(Schema) ?? __requestBase?.Schema;
                        var enableWebSearch = parseResult.GetValue(EnableWebSearch) ?? __requestBase?.EnableWebSearch;
                        var ignoreSitemap = parseResult.GetValue(IgnoreSitemap) ?? __requestBase?.IgnoreSitemap;
                        var includeSubdomains = parseResult.GetValue(IncludeSubdomains) ?? __requestBase?.IncludeSubdomains;
                        var showSources = parseResult.GetValue(ShowSources) ?? __requestBase?.ShowSources;
                        var ignoreInvalidURLs = parseResult.GetValue(IgnoreInvalidURLs) ?? __requestBase?.IgnoreInvalidURLs;
                        var scrapeOptionsFormats = parseResult.GetValue(ScrapeOptionsOptions.Formats) ?? __requestBase?.ScrapeOptions?.Formats;
                        var scrapeOptionsOnlyMainContent = parseResult.GetValue(ScrapeOptionsOptions.OnlyMainContent) ?? __requestBase?.ScrapeOptions?.OnlyMainContent;
                        var scrapeOptionsIncludeTags = parseResult.GetValue(ScrapeOptionsOptions.IncludeTags) ?? __requestBase?.ScrapeOptions?.IncludeTags;
                        var scrapeOptionsExcludeTags = parseResult.GetValue(ScrapeOptionsOptions.ExcludeTags) ?? __requestBase?.ScrapeOptions?.ExcludeTags;
                        var scrapeOptionsMaxAge = parseResult.GetValue(ScrapeOptionsOptions.MaxAge) ?? __requestBase?.ScrapeOptions?.MaxAge;
                        var scrapeOptionsWaitFor = parseResult.GetValue(ScrapeOptionsOptions.WaitFor) ?? __requestBase?.ScrapeOptions?.WaitFor;
                        var scrapeOptionsMobile = parseResult.GetValue(ScrapeOptionsOptions.Mobile) ?? __requestBase?.ScrapeOptions?.Mobile;
                        var scrapeOptionsSkipTlsVerification = parseResult.GetValue(ScrapeOptionsOptions.SkipTlsVerification) ?? __requestBase?.ScrapeOptions?.SkipTlsVerification;
                        var scrapeOptionsTimeout = parseResult.GetValue(ScrapeOptionsOptions.Timeout) ?? __requestBase?.ScrapeOptions?.Timeout;
                        var scrapeOptionsParsePDF = parseResult.GetValue(ScrapeOptionsOptions.ParsePDF) ?? __requestBase?.ScrapeOptions?.ParsePDF;
                        var scrapeOptionsRemoveBase64Images = parseResult.GetValue(ScrapeOptionsOptions.RemoveBase64Images) ?? __requestBase?.ScrapeOptions?.RemoveBase64Images;
                        var scrapeOptionsBlockAds = parseResult.GetValue(ScrapeOptionsOptions.BlockAds) ?? __requestBase?.ScrapeOptions?.BlockAds;
                        var scrapeOptionsProxy = parseResult.GetValue(ScrapeOptionsOptions.Proxy) ?? __requestBase?.ScrapeOptions?.Proxy;
                        var scrapeOptionsStoreInCache = parseResult.GetValue(ScrapeOptionsOptions.StoreInCache) ?? __requestBase?.ScrapeOptions?.StoreInCache;
                        var __scrapeOptionsSpecified = CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.Formats) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.OnlyMainContent) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.IncludeTags) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.ExcludeTags) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.MaxAge) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.WaitFor) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.Mobile) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.SkipTlsVerification) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.Timeout) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.ParsePDF) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.RemoveBase64Images) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.BlockAds) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.Proxy) || CliRuntime.WasSpecified(parseResult, ScrapeOptionsOptions.StoreInCache);
                        var scrapeOptions =
                            __scrapeOptionsSpecified || __requestBase?.ScrapeOptions is not null
                                ? new global::Firecrawl.ScrapeOptions
                                {
                                Formats = scrapeOptionsFormats,
                                OnlyMainContent = scrapeOptionsOnlyMainContent,
                                IncludeTags = scrapeOptionsIncludeTags,
                                ExcludeTags = scrapeOptionsExcludeTags,
                                MaxAge = scrapeOptionsMaxAge,
                                WaitFor = scrapeOptionsWaitFor,
                                Mobile = scrapeOptionsMobile,
                                SkipTlsVerification = scrapeOptionsSkipTlsVerification,
                                Timeout = scrapeOptionsTimeout,
                                ParsePDF = scrapeOptionsParsePDF,
                                RemoveBase64Images = scrapeOptionsRemoveBase64Images,
                                BlockAds = scrapeOptionsBlockAds,
                                Proxy = scrapeOptionsProxy,
                                StoreInCache = scrapeOptionsStoreInCache,
                                }
                                : __requestBase?.ScrapeOptions;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Extraction.ExtractDataAsync(
                                    urls: urls,
                                    prompt: prompt,
                                    schema: schema,
                                    enableWebSearch: enableWebSearch,
                                    ignoreSitemap: ignoreSitemap,
                                    includeSubdomains: includeSubdomains,
                                    showSources: showSources,
                                    ignoreInvalidURLs: ignoreInvalidURLs,
                                    scrapeOptions: scrapeOptions,
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
        return command;
    }
}