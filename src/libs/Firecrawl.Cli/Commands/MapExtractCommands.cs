using System.CommandLine;

namespace Firecrawl.Cli;

internal static partial class CliCommands
{
    public static Command CreateMapCommand()
    {
        var urlArgument = new Argument<string>("url")
        {
            Description = "The base URL to map.",
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var searchOption = new Option<string>("--search") { Description = "Search query to use for mapping." };
        var ignoreSitemapOption = CliOptions.CreateNullableBoolOption("--ignore-sitemap", "Ignore the website sitemap.");
        var sitemapOnlyOption = CliOptions.CreateNullableBoolOption("--sitemap-only", "Only return links from the sitemap.");
        var includeSubdomainsOption = CliOptions.CreateNullableBoolOption("--include-subdomains", "Include subdomains in the mapping.");
        var limitOption = new Option<int?>("--limit") { Description = "Maximum number of links to return." };
        var timeoutOption = new Option<int?>("--timeout") { Description = "Timeout in milliseconds." };

        var command = new Command("map", "Map multiple URLs based on options.");
        command.Arguments.Add(urlArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        command.Options.Add(searchOption);
        command.Options.Add(ignoreSitemapOption);
        command.Options.Add(sitemapOnlyOption);
        command.Options.Add(includeSubdomainsOption);
        command.Options.Add(limitOption);
        command.Options.Add(timeoutOption);
        command.SetAction(async parseResult =>
        {
            var url = CliRuntime.GetRequiredValue(parseResult, urlArgument);
            var request = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => MapUrlsRequest.FromJson(json, context)).ConfigureAwait(false)
                ?? new MapUrlsRequest
                {
                    Url = url,
                };

            request.Url = url;
            if (CliRuntime.WasSpecified(parseResult, searchOption))
            {
                request.Search = CliRuntime.GetRequiredValue(parseResult, searchOption);
            }

            if (CliRuntime.WasSpecified(parseResult, ignoreSitemapOption))
            {
                request.IgnoreSitemap = parseResult.GetValue(ignoreSitemapOption);
            }

            if (CliRuntime.WasSpecified(parseResult, sitemapOnlyOption))
            {
                request.SitemapOnly = parseResult.GetValue(sitemapOnlyOption);
            }

            if (CliRuntime.WasSpecified(parseResult, includeSubdomainsOption))
            {
                request.IncludeSubdomains = parseResult.GetValue(includeSubdomainsOption);
            }

            if (CliRuntime.WasSpecified(parseResult, limitOption))
            {
                request.Limit = parseResult.GetValue(limitOption);
            }

            if (CliRuntime.WasSpecified(parseResult, timeoutOption))
            {
                request.Timeout = parseResult.GetValue(timeoutOption);
            }

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Mapping.MapUrlsAsync(request).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatMapResponse(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    public static Command CreateExtractCommand()
    {
        var extract = new Command("extract", "Start and inspect structured extraction jobs.");
        extract.Subcommands.Add(CreateExtractStartCommand());
        extract.Subcommands.Add(CreateExtractStatusCommand());
        return extract;
    }

    private static Command CreateExtractStartCommand()
    {
        var urlsArgument = new Argument<string[]>("url")
        {
            Description = "One or more URLs or URL globs to extract from.",
            Arity = ArgumentArity.OneOrMore,
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var waitOption = CliOptions.CreateWaitOption();
        var pollIntervalOption = CliOptions.CreatePollIntervalOption();
        var waitTimeoutOption = CliOptions.CreateWaitTimeoutOption();
        var scrapeOptions = CliOptions.CreateScrapeOptionSet("scrape");
        var promptOption = new Option<string>("--prompt") { Description = "Prompt to guide the extraction process." };
        var schemaJsonOption = new Option<string>("--schema-json") { Description = "Inline JSON Schema for the extracted data." };
        var schemaFileOption = new Option<string>("--schema-file") { Description = "Path to a JSON Schema file for the extracted data." };
        var enableWebSearchOption = CliOptions.CreateNullableBoolOption("--enable-web-search", "Use web search to find additional data.");
        var ignoreSitemapOption = CliOptions.CreateNullableBoolOption("--ignore-sitemap", "Ignore sitemap.xml files.");
        var includeSubdomainsOption = CliOptions.CreateNullableBoolOption("--include-subdomains", "Include subdomains of the provided URLs.");
        var showSourcesOption = CliOptions.CreateNullableBoolOption("--show-sources", "Include source URLs in the response.");
        var ignoreInvalidUrlsOption = CliOptions.CreateNullableBoolOption("--ignore-invalid-urls", "Ignore invalid URLs instead of failing the request.");

        var command = new Command("start", "Start an extraction job.");
        command.Arguments.Add(urlsArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        command.Options.Add(waitOption);
        command.Options.Add(pollIntervalOption);
        command.Options.Add(waitTimeoutOption);
        command.Options.Add(promptOption);
        command.Options.Add(schemaJsonOption);
        command.Options.Add(schemaFileOption);
        command.Options.Add(enableWebSearchOption);
        command.Options.Add(ignoreSitemapOption);
        command.Options.Add(includeSubdomainsOption);
        command.Options.Add(showSourcesOption);
        command.Options.Add(ignoreInvalidUrlsOption);
        AddScrapeOptions(command, scrapeOptions);
        command.SetAction(async parseResult =>
        {
            var urls = CliRuntime.GetRequiredValue(parseResult, urlsArgument);
            var request = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => ExtractDataRequest.FromJson(json, context)).ConfigureAwait(false)
                ?? new ExtractDataRequest
                {
                    Urls = urls,
                };

            request.Urls = urls;
            if (CliRuntime.WasSpecified(parseResult, promptOption))
            {
                request.Prompt = CliRuntime.GetRequiredValue(parseResult, promptOption);
            }

            var schema = await CliRuntime.ReadJsonValueAsync(parseResult, schemaJsonOption, schemaFileOption).ConfigureAwait(false);
            if (schema is not null)
            {
                request.Schema = schema;
            }

            if (CliRuntime.WasSpecified(parseResult, enableWebSearchOption))
            {
                request.EnableWebSearch = parseResult.GetValue(enableWebSearchOption);
            }

            if (CliRuntime.WasSpecified(parseResult, ignoreSitemapOption))
            {
                request.IgnoreSitemap = parseResult.GetValue(ignoreSitemapOption);
            }

            if (CliRuntime.WasSpecified(parseResult, includeSubdomainsOption))
            {
                request.IncludeSubdomains = parseResult.GetValue(includeSubdomainsOption);
            }

            if (CliRuntime.WasSpecified(parseResult, showSourcesOption))
            {
                request.ShowSources = parseResult.GetValue(showSourcesOption);
            }

            if (CliRuntime.WasSpecified(parseResult, ignoreInvalidUrlsOption))
            {
                request.IgnoreInvalidURLs = parseResult.GetValue(ignoreInvalidUrlsOption);
            }

            request.ScrapeOptions ??= new ScrapeOptions();
            CliRuntime.ApplyScrapeOptions(parseResult, scrapeOptions, request.ScrapeOptions);

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Extraction.ExtractDataAsync(request).ConfigureAwait(false);
            if (parseResult.GetValue(waitOption) && !string.IsNullOrWhiteSpace(response.Id))
            {
                var status = await CliRuntime.PollAsync(
                    fetchAsync: () => client.Extraction.GetExtractStatusAsync(response.Id!),
                    isComplete: static result => result.Status is ExtractStatusResponseStatus.Completed or ExtractStatusResponseStatus.Failed or ExtractStatusResponseStatus.Cancelled,
                    pollInterval: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, pollIntervalOption), pollIntervalOption.Name),
                    waitTimeout: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, waitTimeoutOption), waitTimeoutOption.Name)).ConfigureAwait(false);

                await CliRuntime.WriteOutputAsync(
                    parseResult,
                    status,
                    CliRuntime.FormatExtractStatus(status),
                    parseResult.GetValue(outputOption)).ConfigureAwait(false);
                return;
            }

            var nextCommand = response.Id is null
                ? "firecrawl extract status <id>"
                : CliRuntime.BuildNextCommand("extract status", response.Id);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatStartResult("extract", response.Success, response.Id, nextCommand, invalidUrls: response.InvalidURLs),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateExtractStatusCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The extract job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("status", "Get the status of an extraction job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Extraction.GetExtractStatusAsync(id).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatExtractStatus(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }
}
