using System.CommandLine;

namespace Firecrawl.Cli;

internal static partial class CliCommands
{
    public static Command CreateCrawlCommand()
    {
        var crawl = new Command("crawl", "Start and manage crawl jobs.");
        crawl.Subcommands.Add(CreateCrawlStartCommand());
        crawl.Subcommands.Add(CreateCrawlStatusCommand());
        crawl.Subcommands.Add(CreateCrawlCancelCommand());
        crawl.Subcommands.Add(CreateCrawlErrorsCommand());
        crawl.Subcommands.Add(CreateCrawlActiveCommand());
        return crawl;
    }

    private static Command CreateCrawlStartCommand()
    {
        var urlArgument = new Argument<string>("url")
        {
            Description = "The base URL to crawl.",
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var waitOption = CliOptions.CreateWaitOption();
        var pollIntervalOption = CliOptions.CreatePollIntervalOption();
        var waitTimeoutOption = CliOptions.CreateWaitTimeoutOption();
        var scrapeOptions = CliOptions.CreateScrapeOptionSet("scrape");
        var webhookOptions = CliOptions.CreateCrawlWebhookOptionSet();
        var excludePathsOption = CliOptions.CreateStringListOption("--exclude-path", "URL pathname regex patterns to exclude.");
        var includePathsOption = CliOptions.CreateStringListOption("--include-path", "URL pathname regex patterns to include.");
        var maxDepthOption = new Option<int?>("--max-depth") { Description = "Maximum crawl depth relative to the base URL." };
        var maxDiscoveryDepthOption = new Option<int?>("--max-discovery-depth") { Description = "Maximum crawl depth based on discovery order." };
        var ignoreSitemapOption = CliOptions.CreateNullableBoolOption("--ignore-sitemap", "Ignore the website sitemap.");
        var ignoreQueryParametersOption = CliOptions.CreateNullableBoolOption("--ignore-query-parameters", "Ignore query parameters when deduplicating URLs.");
        var limitOption = new Option<int?>("--limit") { Description = "Maximum number of pages to crawl." };
        var allowBackwardLinksOption = CliOptions.CreateNullableBoolOption("--allow-backward-links", "Allow sibling and parent links.");
        var allowExternalLinksOption = CliOptions.CreateNullableBoolOption("--allow-external-links", "Allow links to external websites.");
        var delayOption = new Option<double?>("--delay") { Description = "Delay in seconds between scrapes." };

        var command = new Command("start", "Start a crawl job.");
        command.Arguments.Add(urlArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        command.Options.Add(waitOption);
        command.Options.Add(pollIntervalOption);
        command.Options.Add(waitTimeoutOption);
        command.Options.Add(excludePathsOption);
        command.Options.Add(includePathsOption);
        command.Options.Add(maxDepthOption);
        command.Options.Add(maxDiscoveryDepthOption);
        command.Options.Add(ignoreSitemapOption);
        command.Options.Add(ignoreQueryParametersOption);
        command.Options.Add(limitOption);
        command.Options.Add(allowBackwardLinksOption);
        command.Options.Add(allowExternalLinksOption);
        command.Options.Add(delayOption);
        AddScrapeOptions(command, scrapeOptions);
        AddWebhookOptions(command, webhookOptions);
        command.SetAction(async parseResult =>
        {
            var url = CliRuntime.GetRequiredValue(parseResult, urlArgument);
            var request = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => CrawlUrlsRequest.FromJson(json, context)).ConfigureAwait(false)
                ?? new CrawlUrlsRequest
                {
                    Url = url,
                };

            request.Url = url;
            if (CliRuntime.WasSpecified(parseResult, excludePathsOption))
            {
                request.ExcludePaths = CliRuntime.GetValues(parseResult, excludePathsOption);
            }

            if (CliRuntime.WasSpecified(parseResult, includePathsOption))
            {
                request.IncludePaths = CliRuntime.GetValues(parseResult, includePathsOption);
            }

            if (CliRuntime.WasSpecified(parseResult, maxDepthOption))
            {
                request.MaxDepth = parseResult.GetValue(maxDepthOption);
            }

            if (CliRuntime.WasSpecified(parseResult, maxDiscoveryDepthOption))
            {
                request.MaxDiscoveryDepth = parseResult.GetValue(maxDiscoveryDepthOption);
            }

            if (CliRuntime.WasSpecified(parseResult, ignoreSitemapOption))
            {
                request.IgnoreSitemap = parseResult.GetValue(ignoreSitemapOption);
            }

            if (CliRuntime.WasSpecified(parseResult, ignoreQueryParametersOption))
            {
                request.IgnoreQueryParameters = parseResult.GetValue(ignoreQueryParametersOption);
            }

            if (CliRuntime.WasSpecified(parseResult, limitOption))
            {
                request.Limit = parseResult.GetValue(limitOption);
            }

            if (CliRuntime.WasSpecified(parseResult, allowBackwardLinksOption))
            {
                request.AllowBackwardLinks = parseResult.GetValue(allowBackwardLinksOption);
            }

            if (CliRuntime.WasSpecified(parseResult, allowExternalLinksOption))
            {
                request.AllowExternalLinks = parseResult.GetValue(allowExternalLinksOption);
            }

            if (CliRuntime.WasSpecified(parseResult, delayOption))
            {
                request.Delay = parseResult.GetValue(delayOption);
            }

            request.Webhook = await BuildCrawlWebhookAsync(parseResult, webhookOptions).ConfigureAwait(false) ?? request.Webhook;
            request.ScrapeOptions ??= new ScrapeOptions();
            CliRuntime.ApplyScrapeOptions(parseResult, scrapeOptions, request.ScrapeOptions);

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Crawling.CrawlUrlsAsync(request).ConfigureAwait(false);

            if (parseResult.GetValue(waitOption) && !string.IsNullOrWhiteSpace(response.Id))
            {
                var status = await CliRuntime.PollAsync(
                    fetchAsync: () => client.Crawling.GetCrawlStatusAsync(response.Id!),
                    isComplete: static result => string.Equals(result.Status, "completed", StringComparison.OrdinalIgnoreCase) ||
                                                string.Equals(result.Status, "failed", StringComparison.OrdinalIgnoreCase) ||
                                                string.Equals(result.Status, "cancelled", StringComparison.OrdinalIgnoreCase),
                    pollInterval: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, pollIntervalOption), pollIntervalOption.Name),
                    waitTimeout: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, waitTimeoutOption), waitTimeoutOption.Name)).ConfigureAwait(false);

                await CliRuntime.WriteOutputAsync(
                    parseResult,
                    status,
                    CliRuntime.FormatCrawlStatus(status),
                    parseResult.GetValue(outputOption)).ConfigureAwait(false);
                return;
            }

            var nextCommand = response.Id is null
                ? "firecrawl crawl status <id>"
                : CliRuntime.BuildNextCommand("crawl status", response.Id);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatStartResult("crawl", response.Success, response.Id, nextCommand, response.Url),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateCrawlStatusCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The crawl job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();
        var outputDirectoryOption = CliOptions.CreateOutputDirectoryOption();

        var command = new Command("status", "Get the status of a crawl job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.Options.Add(outputDirectoryOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Crawling.GetCrawlStatusAsync(id).ConfigureAwait(false);

            var outputDirectory = parseResult.GetValue(outputDirectoryOption);
            if (!string.IsNullOrWhiteSpace(outputDirectory))
            {
                await CliRuntime.WritePageResultFilesAsync(
                    outputDirectory,
                    response.Data?.Select(static item => new SavedPageResult(
                        item.Metadata?.SourceURL,
                        item.Markdown,
                        item.Html,
                        item.RawHtml,
                        item.Links,
                        item.Screenshot,
                        item.Metadata)) ?? []).ConfigureAwait(false);
            }

            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatCrawlStatus(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateCrawlCancelCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The crawl job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("cancel", "Cancel a crawl job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Crawling.CancelCrawlAsync(id).ConfigureAwait(false);
            var human = $"status: {response.Status?.ToValueString()}";
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                human,
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateCrawlErrorsCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The crawl job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("errors", "Get the errors for a crawl job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Crawling.GetCrawlErrorsAsync(id).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatErrors(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateCrawlActiveCommand()
    {
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("active", "Get all active crawls for the authenticated team.");
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Crawling.GetActiveCrawlsAsync().ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatActiveCrawls(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static async Task<CrawlUrlsRequestWebhook?> BuildCrawlWebhookAsync(ParseResult parseResult, WebhookOptionSet options)
    {
        if (!CliRuntime.WasSpecified(parseResult, options.Url) &&
            !CliRuntime.WasSpecified(parseResult, options.Headers) &&
            !CliRuntime.WasSpecified(parseResult, options.MetadataPairs) &&
            !CliRuntime.WasSpecified(parseResult, options.MetadataJson) &&
            !CliRuntime.WasSpecified(parseResult, options.MetadataFile) &&
            !CliRuntime.WasSpecified(parseResult, options.Events))
        {
            return null;
        }

        var url = parseResult.GetValue(options.Url);
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new CliException("--webhook-url is required when any crawl webhook option is used.");
        }

        var metadataJson = await CliRuntime.ReadJsonValueAsync(parseResult, options.MetadataJson, options.MetadataFile).ConfigureAwait(false);
        var metadata = CliRuntime.BuildObjectFromPairsOrJson(
            CliRuntime.ReadKeyValuePairs(parseResult, options.MetadataPairs),
            metadataJson);

        return new CrawlUrlsRequestWebhook
        {
            Url = url,
            Headers = CliRuntime.ReadKeyValuePairs(parseResult, options.Headers),
            Metadata = metadata,
            Events = CliRuntime.WasSpecified(parseResult, options.Events)
                ? CliRuntime.GetValues(parseResult, options.Events).Select(CliRuntime.ParseCrawlWebhookEvent).ToList()
                : null,
        };
    }
}
