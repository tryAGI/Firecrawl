using System.CommandLine;

namespace Firecrawl.Cli;

internal static partial class CliCommands
{
    public static Command CreateScrapeCommand()
    {
        var urlArgument = new Argument<string>("url")
        {
            Description = "The URL to scrape.",
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var scrapeOptions = CliOptions.CreateScrapeOptionSet();

        var command = new Command("scrape", "Scrape a single URL and optionally extract information using an LLM.");
        command.Arguments.Add(urlArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        AddScrapeOptions(command, scrapeOptions);
        command.SetAction(async parseResult =>
        {
            var url = CliRuntime.GetRequiredValue(parseResult, urlArgument);
            var loadedRequest = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => AllOf<ScrapeAndExtractFromUrlRequest2, ScrapeOptions>.FromJson(json, context)).ConfigureAwait(false);

            var requestBody = loadedRequest?.Value1 ?? new ScrapeAndExtractFromUrlRequest2
            {
                Url = url,
            };
            var optionsBody = loadedRequest?.Value2 ?? new ScrapeOptions();

            requestBody.Url = url;
            CliRuntime.ApplyScrapeOptions(parseResult, scrapeOptions, optionsBody);

            var request = new AllOf<ScrapeAndExtractFromUrlRequest2, ScrapeOptions>(requestBody, optionsBody);

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Scraping.ScrapeAndExtractFromUrlAsync(request).ConfigureAwait(false);

            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatScrapeResponse(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    public static Command CreateBatchScrapeCommand()
    {
        var batchScrape = new Command("batch-scrape", "Scrape multiple URLs and manage batch scrape jobs.");
        batchScrape.Subcommands.Add(CreateBatchScrapeStartCommand());
        batchScrape.Subcommands.Add(CreateBatchScrapeStatusCommand());
        batchScrape.Subcommands.Add(CreateBatchScrapeCancelCommand());
        batchScrape.Subcommands.Add(CreateBatchScrapeErrorsCommand());
        return batchScrape;
    }

    private static Command CreateBatchScrapeStartCommand()
    {
        var urlsArgument = new Argument<string[]>("url")
        {
            Description = "One or more URLs to scrape.",
            Arity = ArgumentArity.OneOrMore,
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var waitOption = CliOptions.CreateWaitOption();
        var pollIntervalOption = CliOptions.CreatePollIntervalOption();
        var waitTimeoutOption = CliOptions.CreateWaitTimeoutOption();
        var scrapeOptions = CliOptions.CreateScrapeOptionSet();
        var webhookOptions = CliOptions.CreateBatchWebhookOptionSet();
        var ignoreInvalidUrlsOption = CliOptions.CreateNullableBoolOption("--ignore-invalid-urls", "Ignore invalid URLs instead of failing the full request.");

        var command = new Command("start", "Start a batch scrape job.");
        command.Arguments.Add(urlsArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        command.Options.Add(waitOption);
        command.Options.Add(pollIntervalOption);
        command.Options.Add(waitTimeoutOption);
        command.Options.Add(ignoreInvalidUrlsOption);
        AddScrapeOptions(command, scrapeOptions);
        AddWebhookOptions(command, webhookOptions);
        command.SetAction(async parseResult =>
        {
            var urls = CliRuntime.GetRequiredValue(parseResult, urlsArgument);
            var loadedRequest = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => AllOf<ScrapeAndExtractFromUrlsRequest2, ScrapeOptions>.FromJson(json, context)).ConfigureAwait(false);

            var requestBody = loadedRequest?.Value1 ?? new ScrapeAndExtractFromUrlsRequest2
            {
                Urls = urls,
            };
            var optionsBody = loadedRequest?.Value2 ?? new ScrapeOptions();

            requestBody.Urls = urls;
            if (CliRuntime.WasSpecified(parseResult, ignoreInvalidUrlsOption))
            {
                requestBody.IgnoreInvalidURLs = parseResult.GetValue(ignoreInvalidUrlsOption);
            }

            requestBody.Webhook = await BuildBatchWebhookAsync(parseResult, webhookOptions).ConfigureAwait(false) ?? requestBody.Webhook;
            CliRuntime.ApplyScrapeOptions(parseResult, scrapeOptions, optionsBody);

            var request = new AllOf<ScrapeAndExtractFromUrlsRequest2, ScrapeOptions>(requestBody, optionsBody);

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Scraping.ScrapeAndExtractFromUrlsAsync(request).ConfigureAwait(false);
            if (parseResult.GetValue(waitOption) && !string.IsNullOrWhiteSpace(response.Id))
            {
                var status = await CliRuntime.PollAsync(
                    fetchAsync: () => client.Scraping.GetBatchScrapeStatusAsync(response.Id!),
                    isComplete: static result => string.Equals(result.Status, "completed", StringComparison.OrdinalIgnoreCase) ||
                                                string.Equals(result.Status, "failed", StringComparison.OrdinalIgnoreCase) ||
                                                string.Equals(result.Status, "cancelled", StringComparison.OrdinalIgnoreCase),
                    pollInterval: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, pollIntervalOption), pollIntervalOption.Name),
                    waitTimeout: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, waitTimeoutOption), waitTimeoutOption.Name)).ConfigureAwait(false);

                await CliRuntime.WriteOutputAsync(
                    parseResult,
                    status,
                    CliRuntime.FormatBatchScrapeStatus(status),
                    parseResult.GetValue(outputOption)).ConfigureAwait(false);
                return;
            }

            var nextCommand = response.Id is null
                ? "firecrawl batch-scrape status <id>"
                : CliRuntime.BuildNextCommand("batch-scrape status", response.Id);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatStartResult("batch-scrape", response.Success, response.Id, nextCommand, invalidUrls: response.InvalidURLs),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateBatchScrapeStatusCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The batch scrape job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();
        var outputDirectoryOption = CliOptions.CreateOutputDirectoryOption();

        var command = new Command("status", "Get the status of a batch scrape job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.Options.Add(outputDirectoryOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Scraping.GetBatchScrapeStatusAsync(id).ConfigureAwait(false);

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
                CliRuntime.FormatBatchScrapeStatus(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateBatchScrapeCancelCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The batch scrape job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("cancel", "Cancel a batch scrape job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Scraping.CancelBatchScrapeAsync(id).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                $"success: {response.Success}{Environment.NewLine}message: {response.Message}",
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateBatchScrapeErrorsCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The batch scrape job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("errors", "Get the errors for a batch scrape job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Scraping.GetBatchScrapeErrorsAsync(id).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatErrors(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static async Task<ScrapeAndExtractFromUrlsRequestWebhook?> BuildBatchWebhookAsync(ParseResult parseResult, WebhookOptionSet options)
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
            throw new CliException("--webhook-url is required when any batch webhook option is used.");
        }

        var metadataJson = await CliRuntime.ReadJsonValueAsync(parseResult, options.MetadataJson, options.MetadataFile).ConfigureAwait(false);
        var metadata = CliRuntime.BuildObjectFromPairsOrJson(
            CliRuntime.ReadKeyValuePairs(parseResult, options.MetadataPairs),
            metadataJson);

        return new ScrapeAndExtractFromUrlsRequestWebhook
        {
            Url = url,
            Headers = CliRuntime.ReadKeyValuePairs(parseResult, options.Headers),
            Metadata = metadata,
            Events = CliRuntime.WasSpecified(parseResult, options.Events)
                ? CliRuntime.GetValues(parseResult, options.Events).Select(CliRuntime.ParseBatchWebhookEvent).ToList()
                : null,
        };
    }

    private static void AddScrapeOptions(Command command, ScrapeOptionSet options)
    {
        command.Options.Add(options.Formats);
        command.Options.Add(options.OnlyMainContent);
        command.Options.Add(options.IncludeTags);
        command.Options.Add(options.ExcludeTags);
        command.Options.Add(options.MaxAge);
        command.Options.Add(options.Headers);
        command.Options.Add(options.WaitFor);
        command.Options.Add(options.Mobile);
        command.Options.Add(options.SkipTlsVerification);
        command.Options.Add(options.Timeout);
        command.Options.Add(options.ParsePdf);
        command.Options.Add(options.JsonPrompt);
        command.Options.Add(options.JsonSystemPrompt);
        command.Options.Add(options.JsonSchemaJson);
        command.Options.Add(options.JsonSchemaFile);
        command.Options.Add(options.ActionJson);
        command.Options.Add(options.ActionFile);
        command.Options.Add(options.LocationCountry);
        command.Options.Add(options.LocationLanguage);
        command.Options.Add(options.RemoveBase64Images);
        command.Options.Add(options.BlockAds);
        command.Options.Add(options.Proxy);
        command.Options.Add(options.ChangeMode);
        command.Options.Add(options.ChangePrompt);
        command.Options.Add(options.ChangeTag);
        command.Options.Add(options.ChangeSchemaJson);
        command.Options.Add(options.ChangeSchemaFile);
        command.Options.Add(options.StoreInCache);
    }

    private static void AddWebhookOptions(Command command, WebhookOptionSet options)
    {
        command.Options.Add(options.Url);
        command.Options.Add(options.Headers);
        command.Options.Add(options.MetadataPairs);
        command.Options.Add(options.MetadataJson);
        command.Options.Add(options.MetadataFile);
        command.Options.Add(options.Events);
    }
}
