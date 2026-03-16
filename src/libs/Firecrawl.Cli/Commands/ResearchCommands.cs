using System.CommandLine;

namespace Firecrawl.Cli;

internal static partial class CliCommands
{
    public static Command CreateDeepResearchCommand()
    {
        var deepResearch = new Command("deep-research", "Start and inspect deep research jobs.");
        deepResearch.Subcommands.Add(CreateDeepResearchStartCommand());
        deepResearch.Subcommands.Add(CreateDeepResearchStatusCommand());
        return deepResearch;
    }

    public static Command CreateTeamCommand()
    {
        var team = new Command("team", "Inspect team usage endpoints.");
        team.Subcommands.Add(CreateCreditUsageCommand());
        team.Subcommands.Add(CreateTokenUsageCommand());
        return team;
    }

    public static Command CreateSearchCommand()
    {
        var queryArgument = new Argument<string>("query")
        {
            Description = "The search query.",
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var limitOption = new Option<int?>("--limit") { Description = "Maximum number of results to return." };
        var tbsOption = new Option<string>("--tbs") { Description = "Time-based search parameter." };
        var locationOption = new Option<string>("--location") { Description = "Location parameter for search results." };
        var timeoutOption = new Option<int?>("--timeout") { Description = "Timeout in milliseconds." };
        var ignoreInvalidUrlsOption = CliOptions.CreateNullableBoolOption("--ignore-invalid-urls", "Exclude URLs invalid for other Firecrawl endpoints.");
        var scrapeFormatOption = CliOptions.CreateStringListOption("--scrape-format", "Formats to scrape for each search result.");

        var command = new Command("search", "Search and optionally scrape search results.");
        command.Arguments.Add(queryArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        command.Options.Add(limitOption);
        command.Options.Add(tbsOption);
        command.Options.Add(locationOption);
        command.Options.Add(timeoutOption);
        command.Options.Add(ignoreInvalidUrlsOption);
        command.Options.Add(scrapeFormatOption);
        command.SetAction(async parseResult =>
        {
            var query = CliRuntime.GetRequiredValue(parseResult, queryArgument);
            var request = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => SearchAndScrapeRequest.FromJson(json, context)).ConfigureAwait(false)
                ?? new SearchAndScrapeRequest
                {
                    Query = query,
                };

            request.Query = query;
            if (CliRuntime.WasSpecified(parseResult, limitOption))
            {
                request.Limit = parseResult.GetValue(limitOption);
            }

            if (CliRuntime.WasSpecified(parseResult, tbsOption))
            {
                request.Tbs = CliRuntime.GetRequiredValue(parseResult, tbsOption);
            }

            if (CliRuntime.WasSpecified(parseResult, locationOption))
            {
                request.Location = CliRuntime.GetRequiredValue(parseResult, locationOption);
            }

            if (CliRuntime.WasSpecified(parseResult, timeoutOption))
            {
                request.Timeout = parseResult.GetValue(timeoutOption);
            }

            if (CliRuntime.WasSpecified(parseResult, ignoreInvalidUrlsOption))
            {
                request.IgnoreInvalidURLs = parseResult.GetValue(ignoreInvalidUrlsOption);
            }

            request.ScrapeOptions = CliRuntime.BuildSearchScrapeOptions(parseResult, scrapeFormatOption) ?? request.ScrapeOptions;

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Search.SearchAndScrapeAsync(request).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatSearchResponse(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    public static Command CreateLlmstxtCommand()
    {
        var llmstxt = new Command("llmstxt", "Generate and inspect LLMs.txt jobs.");
        llmstxt.Subcommands.Add(CreateLlmstxtGenerateCommand());
        llmstxt.Subcommands.Add(CreateLlmstxtStatusCommand());
        return llmstxt;
    }

    private static Command CreateDeepResearchStartCommand()
    {
        var queryArgument = new Argument<string>("query")
        {
            Description = "The query to research.",
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var waitOption = CliOptions.CreateWaitOption();
        var pollIntervalOption = CliOptions.CreatePollIntervalOption();
        var waitTimeoutOption = CliOptions.CreateWaitTimeoutOption();
        var maxDepthOption = new Option<int?>("--max-depth") { Description = "Maximum depth of research iterations." };
        var timeLimitOption = new Option<int?>("--time-limit") { Description = "Time limit in seconds." };
        var maxUrlsOption = new Option<int?>("--max-urls") { Description = "Maximum number of URLs to analyze." };
        var analysisPromptOption = new Option<string>("--analysis-prompt") { Description = "Prompt for the final analysis." };
        var systemPromptOption = new Option<string>("--system-prompt") { Description = "System prompt for the research agent." };
        var formatOption = CliOptions.CreateStringListOption("--format", "Formats to request: markdown, json, branding.");
        var jsonPromptOption = new Option<string>("--json-prompt") { Description = "Prompt for JSON output." };
        var jsonSystemPromptOption = new Option<string>("--json-system-prompt") { Description = "System prompt for JSON output." };
        var jsonSchemaJsonOption = new Option<string>("--json-schema-json") { Description = "Inline JSON Schema for JSON output." };
        var jsonSchemaFileOption = new Option<string>("--json-schema-file") { Description = "Path to a JSON Schema file for JSON output." };

        var command = new Command("start", "Start a deep research job.");
        command.Arguments.Add(queryArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        command.Options.Add(waitOption);
        command.Options.Add(pollIntervalOption);
        command.Options.Add(waitTimeoutOption);
        command.Options.Add(maxDepthOption);
        command.Options.Add(timeLimitOption);
        command.Options.Add(maxUrlsOption);
        command.Options.Add(analysisPromptOption);
        command.Options.Add(systemPromptOption);
        command.Options.Add(formatOption);
        command.Options.Add(jsonPromptOption);
        command.Options.Add(jsonSystemPromptOption);
        command.Options.Add(jsonSchemaJsonOption);
        command.Options.Add(jsonSchemaFileOption);
        command.SetAction(async parseResult =>
        {
            var query = CliRuntime.GetRequiredValue(parseResult, queryArgument);
            var request = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => StartDeepResearchRequest.FromJson(json, context)).ConfigureAwait(false)
                ?? new StartDeepResearchRequest
                {
                    Query = query,
                };

            request.Query = query;
            if (CliRuntime.WasSpecified(parseResult, maxDepthOption))
            {
                request.MaxDepth = parseResult.GetValue(maxDepthOption);
            }

            if (CliRuntime.WasSpecified(parseResult, timeLimitOption))
            {
                request.TimeLimit = parseResult.GetValue(timeLimitOption);
            }

            if (CliRuntime.WasSpecified(parseResult, maxUrlsOption))
            {
                request.MaxUrls = parseResult.GetValue(maxUrlsOption);
            }

            if (CliRuntime.WasSpecified(parseResult, analysisPromptOption))
            {
                request.AnalysisPrompt = CliRuntime.GetRequiredValue(parseResult, analysisPromptOption);
            }

            if (CliRuntime.WasSpecified(parseResult, systemPromptOption))
            {
                request.SystemPrompt = CliRuntime.GetRequiredValue(parseResult, systemPromptOption);
            }

            if (CliRuntime.WasSpecified(parseResult, formatOption))
            {
                request.Formats = CliRuntime.GetValues(parseResult, formatOption).Select(CliRuntime.ParseResearchFormat).ToList();
            }

            if (CliRuntime.WasSpecified(parseResult, jsonPromptOption) ||
                CliRuntime.WasSpecified(parseResult, jsonSystemPromptOption) ||
                CliRuntime.WasSpecified(parseResult, jsonSchemaJsonOption) ||
                CliRuntime.WasSpecified(parseResult, jsonSchemaFileOption))
            {
                request.JsonOptions ??= new StartDeepResearchRequestJsonOptions();
                if (CliRuntime.WasSpecified(parseResult, jsonPromptOption))
                {
                    request.JsonOptions.Prompt = CliRuntime.GetRequiredValue(parseResult, jsonPromptOption);
                }

                if (CliRuntime.WasSpecified(parseResult, jsonSystemPromptOption))
                {
                    request.JsonOptions.SystemPrompt = CliRuntime.GetRequiredValue(parseResult, jsonSystemPromptOption);
                }

                var schema = await CliRuntime.ReadJsonValueAsync(parseResult, jsonSchemaJsonOption, jsonSchemaFileOption).ConfigureAwait(false);
                if (schema is not null)
                {
                    request.JsonOptions.Schema = schema;
                }
            }

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Research.StartDeepResearchAsync(request).ConfigureAwait(false);
            var responseId = response.Id?.ToString();
            if (parseResult.GetValue(waitOption) && !string.IsNullOrWhiteSpace(responseId))
            {
                var status = await CliRuntime.PollAsync(
                    fetchAsync: () => client.Research.GetDeepResearchStatusAsync(responseId),
                    isComplete: static result => result.Data?.Status is GetDeepResearchStatusResponseDataStatus.Completed or GetDeepResearchStatusResponseDataStatus.Failed,
                    pollInterval: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, pollIntervalOption), pollIntervalOption.Name),
                    waitTimeout: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, waitTimeoutOption), waitTimeoutOption.Name)).ConfigureAwait(false);

                await CliRuntime.WriteOutputAsync(
                    parseResult,
                    status,
                    CliRuntime.FormatDeepResearchStatus(status),
                    parseResult.GetValue(outputOption)).ConfigureAwait(false);
                return;
            }

            var nextCommand = response.Id is null
                ? "firecrawl deep-research status <id>"
                : CliRuntime.BuildNextCommand("deep-research status", responseId!);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatStartResult("deep-research", response.Success, responseId, nextCommand),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateDeepResearchStatusCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The deep research job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("status", "Get the status of a deep research job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Research.GetDeepResearchStatusAsync(id).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatDeepResearchStatus(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateCreditUsageCommand()
    {
        var outputOption = CliOptions.CreateOutputOption();
        var command = new Command("credit-usage", "Get remaining credits for the authenticated team.");
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Billing.GetCreditUsageAsync().ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatCreditUsage(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateTokenUsageCommand()
    {
        var outputOption = CliOptions.CreateOutputOption();
        var command = new Command("token-usage", "Get remaining tokens for the authenticated team.");
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.Billing.GetTokenUsageAsync().ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatTokenUsage(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateLlmstxtGenerateCommand()
    {
        var urlArgument = new Argument<string>("url")
        {
            Description = "The URL to generate LLMs.txt from.",
        };
        var inputOption = CliOptions.CreateInputOption();
        var outputOption = CliOptions.CreateOutputOption();
        var waitOption = CliOptions.CreateWaitOption();
        var pollIntervalOption = CliOptions.CreatePollIntervalOption();
        var waitTimeoutOption = CliOptions.CreateWaitTimeoutOption();
        var maxUrlsOption = new Option<int?>("--max-urls") { Description = "Maximum number of URLs to analyze." };
        var showFullTextOption = CliOptions.CreateNullableBoolOption("--show-full-text", "Include full text content in the response.");

        var command = new Command("generate", "Generate an LLMs.txt job.");
        command.Arguments.Add(urlArgument);
        command.Options.Add(inputOption);
        command.Options.Add(outputOption);
        command.Options.Add(waitOption);
        command.Options.Add(pollIntervalOption);
        command.Options.Add(waitTimeoutOption);
        command.Options.Add(maxUrlsOption);
        command.Options.Add(showFullTextOption);
        command.SetAction(async parseResult =>
        {
            var url = CliRuntime.GetRequiredValue(parseResult, urlArgument);
            var request = await CliRuntime.LoadInputAsync(
                parseResult,
                inputOption,
                static (json, context) => GenerateLLMsTxtRequest.FromJson(json, context)).ConfigureAwait(false)
                ?? new GenerateLLMsTxtRequest
                {
                    Url = url,
                };

            request.Url = url;
            if (CliRuntime.WasSpecified(parseResult, maxUrlsOption))
            {
                request.MaxUrls = parseResult.GetValue(maxUrlsOption);
            }

            if (CliRuntime.WasSpecified(parseResult, showFullTextOption))
            {
                request.ShowFullText = parseResult.GetValue(showFullTextOption);
            }

            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.LLMsTxt.GenerateLLMsTxtAsync(request).ConfigureAwait(false);
            var responseId = response.Id?.ToString();
            if (parseResult.GetValue(waitOption) && !string.IsNullOrWhiteSpace(responseId))
            {
                var status = await CliRuntime.PollAsync(
                    fetchAsync: () => client.LLMsTxt.GetLLMsTxtStatusAsync(responseId),
                    isComplete: static result => result.Status is GetLLMsTxtStatusResponseStatus.Completed or GetLLMsTxtStatusResponseStatus.Failed,
                    pollInterval: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, pollIntervalOption), pollIntervalOption.Name),
                    waitTimeout: CliRuntime.ParseDuration(CliRuntime.GetRequiredValue(parseResult, waitTimeoutOption), waitTimeoutOption.Name)).ConfigureAwait(false);

                await CliRuntime.WriteOutputAsync(
                    parseResult,
                    status,
                    CliRuntime.FormatLlmstxtStatus(status),
                    parseResult.GetValue(outputOption)).ConfigureAwait(false);
                return;
            }

            var nextCommand = response.Id is null
                ? "firecrawl llmstxt status <id>"
                : CliRuntime.BuildNextCommand("llmstxt status", responseId!);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatStartResult("llmstxt", response.Success, responseId, nextCommand),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateLlmstxtStatusCommand()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The LLMs.txt job id.",
        };
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("status", "Get the status of an LLMs.txt job.");
        command.Arguments.Add(idArgument);
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var id = CliRuntime.GetRequiredValue(parseResult, idArgument);
            using var client = await CliRuntime.CreateClientAsync(parseResult).ConfigureAwait(false);
            var response = await client.LLMsTxt.GetLLMsTxtStatusAsync(id).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                response,
                CliRuntime.FormatLlmstxtStatus(response),
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }
}
