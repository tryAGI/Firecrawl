#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class CrawlingCrawlUrlsCommandApiCommand
{
    private static Argument<string> Url { get; } = new(
        name: @"url")
    {
        Description = @"The base URL to start crawling from",
    };

    private static Option<global::System.Collections.Generic.IList<string>?> ExcludePaths { get; } = new(
        name: @"--exclude-paths")
    {
        Description = @"URL pathname regex patterns that exclude matching URLs from the crawl. For example, if you set ""excludePaths"": [""blog/.*""] for the base URL firecrawl.dev, any results matching that pattern will be excluded, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.",
    };

    private static Option<global::System.Collections.Generic.IList<string>?> IncludePaths { get; } = new(
        name: @"--include-paths")
    {
        Description = @"URL pathname regex patterns that include matching URLs in the crawl. Only the paths that match the specified patterns will be included in the response. For example, if you set ""includePaths"": [""blog/.*""] for the base URL firecrawl.dev, only results matching that pattern will be included, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.",
    };

    private static Option<int?> MaxDepth { get; } = new(
        name: @"--max-depth")
    {
        Description = @"Maximum depth to crawl relative to the base URL. Basically, the max number of slashes the pathname of a scraped URL may contain.",
    };

    private static Option<int?> MaxDiscoveryDepth { get; } = new(
        name: @"--max-discovery-depth")
    {
        Description = @"Maximum depth to crawl based on discovery order. The root site and sitemapped pages has a discovery depth of 0. For example, if you set it to 1, and you set ignoreSitemap, you will only crawl the entered URL and all URLs that are linked on that page.",
    };

    private static Option<bool?> IgnoreSitemap { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--ignore-sitemap",
        description: @"Ignore the website sitemap when crawling");

    private static Option<bool?> IgnoreQueryParameters { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--ignore-query-parameters",
        description: @"Do not re-scrape the same path with different (or none) query parameters");

    private static Option<int?> Limit { get; } = new(
        name: @"--limit")
    {
        Description = @"Maximum number of pages to crawl. Default limit is 10000.",
    };

    private static Option<bool?> AllowBackwardLinks { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--allow-backward-links",
        description: @"Allows the crawler to follow internal links to sibling or parent URLs, not just child paths.

false: Only crawls deeper (child) URLs.
→ e.g. /features/feature-1 → /features/feature-1/tips ✅
→ Won't follow /pricing or / ❌

true: Crawls any internal links, including siblings and parents.
→ e.g. /features/feature-1 → /pricing, /, etc. ✅

Use true for broader internal coverage beyond nested paths.");

    private static Option<bool?> AllowExternalLinks { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--allow-external-links",
        description: @"Allows the crawler to follow links to external websites.");

    private static Option<double?> Delay { get; } = new(
        name: @"--delay")
    {
        Description = @"Delay in seconds between scrapes. This helps respect website rate limits.",
    };
    private static readonly ScrapeOptionsOptionSet ScrapeOptionsOptions = ScrapeOptionsOptionSet.Create(@"scrape");

    private static Option<string?> WebhookWebhookUrl { get; } = new(
        name: @"--webhook-url")
    {
        Description = "Webhook target URL.",
    };

    private static Option<string[]> WebhookWebhookHeader { get; } = new(
        name: @"--webhook-header")
    {
        Description = "Repeatable KEY=VALUE header to send with the webhook request.",
        AllowMultipleArgumentsPerToken = true,
    };

    private static Option<string[]> WebhookWebhookMetadata { get; } = new(
        name: @"--webhook-metadata")
    {
        Description = "Repeatable KEY=VALUE metadata entry attached to the webhook.",
        AllowMultipleArgumentsPerToken = true,
    };

    private static Option<string[]> WebhookWebhookEvent { get; } = new(
        name: @"--webhook-event")
    {
        Description = @"Repeatable event name. Allowed values: completed, page, failed, started.",
        AllowMultipleArgumentsPerToken = true,
    };
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

                    private static string FormatResponse(ParseResult parseResult, global::Firecrawl.CrawlResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Firecrawl.CrawlResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"crawl-urls", @"Crawl multiple URLs based on options");
                        command.Arguments.Add(Url);
                        command.Options.Add(ExcludePaths);
                        command.Options.Add(IncludePaths);
                        command.Options.Add(MaxDepth);
                        command.Options.Add(MaxDiscoveryDepth);
                        command.Options.Add(IgnoreSitemap);
                        command.Options.Add(IgnoreQueryParameters);
                        command.Options.Add(Limit);
                        command.Options.Add(AllowBackwardLinks);
                        command.Options.Add(AllowExternalLinks);
                        command.Options.Add(Delay);                        command.Options.Add(ScrapeOptionsOptions.Formats);
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
                        command.Options.Add(WebhookWebhookUrl);
                        command.Options.Add(WebhookWebhookHeader);
                        command.Options.Add(WebhookWebhookMetadata);
                        command.Options.Add(WebhookWebhookEvent);
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
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Firecrawl.CrawlUrlsRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Firecrawl.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var url = parseResult.GetRequiredValue(Url);
                        var excludePaths = parseResult.GetValue(ExcludePaths) ?? __requestBase?.ExcludePaths;
                        var includePaths = parseResult.GetValue(IncludePaths) ?? __requestBase?.IncludePaths;
                        var maxDepth = parseResult.GetValue(MaxDepth) ?? __requestBase?.MaxDepth;
                        var maxDiscoveryDepth = parseResult.GetValue(MaxDiscoveryDepth) ?? __requestBase?.MaxDiscoveryDepth;
                        var ignoreSitemap = parseResult.GetValue(IgnoreSitemap) ?? __requestBase?.IgnoreSitemap;
                        var ignoreQueryParameters = parseResult.GetValue(IgnoreQueryParameters) ?? __requestBase?.IgnoreQueryParameters;
                        var limit = parseResult.GetValue(Limit) ?? __requestBase?.Limit;
                        var allowBackwardLinks = parseResult.GetValue(AllowBackwardLinks) ?? __requestBase?.AllowBackwardLinks;
                        var allowExternalLinks = parseResult.GetValue(AllowExternalLinks) ?? __requestBase?.AllowExternalLinks;
                        var delay = parseResult.GetValue(Delay) ?? __requestBase?.Delay;
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

                        var webhookWebhookUrl = parseResult.GetValue(WebhookWebhookUrl) ?? __requestBase?.Webhook?.Url;
                        var __webhookHeadersSpecified = CliRuntime.WasSpecified(parseResult, WebhookWebhookHeader);
                        var webhookWebhookHeaders = __webhookHeadersSpecified
                            ? CliRuntime.DeserializeJsonValue<global::System.Collections.Generic.Dictionary<string, string>?>(
                                CliRuntime.SerializeKeyValuePairs(parseResult.GetValue(WebhookWebhookHeader) ?? Array.Empty<string>()),
                                global::Firecrawl.SourceGenerationContext.Default)
                            : __requestBase?.Webhook?.Headers;
                        var __webhookMetadataSpecified = CliRuntime.WasSpecified(parseResult, WebhookWebhookMetadata);
                        var webhookWebhookMetadata = __webhookMetadataSpecified
                            ? CliRuntime.DeserializeJsonValue<object?>(
                                CliRuntime.SerializeKeyValuePairs(parseResult.GetValue(WebhookWebhookMetadata) ?? Array.Empty<string>()),
                                global::Firecrawl.SourceGenerationContext.Default)
                            : __requestBase?.Webhook?.Metadata;
                        var __webhookEventsSpecified = CliRuntime.WasSpecified(parseResult, WebhookWebhookEvent);
                        var webhookWebhookEvents = __webhookEventsSpecified
                            ? CliRuntime.DeserializeJsonValue<global::System.Collections.Generic.IList<global::Firecrawl.CrawlUrlsRequestWebhookEvent>?>(
                                CliRuntime.SerializeStringArray(parseResult.GetValue(WebhookWebhookEvent) ?? Array.Empty<string>()),
                                global::Firecrawl.SourceGenerationContext.Default)
                            : __requestBase?.Webhook?.Events;
                        var __webhookSpecified = CliRuntime.WasSpecified(parseResult, WebhookWebhookUrl) || __webhookHeadersSpecified || __webhookMetadataSpecified || __webhookEventsSpecified;
                        if (__webhookSpecified && string.IsNullOrWhiteSpace(webhookWebhookUrl))
                        {
                            throw new CliException("Specify --webhook-url or include it in the base request body before using other --webhook-* options.");
                        }

                        var __webhookWebhookUrlRequired =
                            webhookWebhookUrl ??
                            throw new CliException("Specify --webhook-url or include it in the base request body before using other --webhook-* options.");

                        var webhook =
                            __webhookSpecified || __requestBase?.Webhook is not null
                                ? new global::Firecrawl.CrawlUrlsRequestWebhook
                                {

                                Url = __webhookWebhookUrlRequired,
                                Headers = webhookWebhookHeaders,
                                Metadata = webhookWebhookMetadata,
                                Events = webhookWebhookEvents,
                                }
                                : __requestBase?.Webhook;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Crawling.CrawlUrlsAsync(
                                    url: url,
                                    excludePaths: excludePaths,
                                    includePaths: includePaths,
                                    maxDepth: maxDepth,
                                    maxDiscoveryDepth: maxDiscoveryDepth,
                                    ignoreSitemap: ignoreSitemap,
                                    ignoreQueryParameters: ignoreQueryParameters,
                                    limit: limit,
                                    allowBackwardLinks: allowBackwardLinks,
                                    allowExternalLinks: allowExternalLinks,
                                    delay: delay,
                                    scrapeOptions: scrapeOptions,
                                    webhook: webhook,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Firecrawl.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}