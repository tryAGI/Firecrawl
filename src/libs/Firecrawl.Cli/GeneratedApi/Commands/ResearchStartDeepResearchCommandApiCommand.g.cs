#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class ResearchStartDeepResearchCommandApiCommand
{
    private static Option<string> Query { get; } = new(
        name: @"--query")
    {
        Description = @"The query to research",
        Required = true,
    };

    private static Option<int?> MaxDepth { get; } = new(
        name: @"--max-depth")
    {
        Description = @"Maximum depth of research iterations",
    };

    private static Option<int?> TimeLimit { get; } = new(
        name: @"--time-limit")
    {
        Description = @"Time limit in seconds",
    };

    private static Option<int?> MaxUrls { get; } = new(
        name: @"--max-urls")
    {
        Description = @"Maximum number of URLs to analyze",
    };

    private static Option<string?> AnalysisPrompt { get; } = new(
        name: @"--analysis-prompt")
    {
        Description = @"The prompt to use for the final analysis. Useful to format the final analysis markdown in a specific way.",
    };

    private static Option<string?> SystemPrompt { get; } = new(
        name: @"--system-prompt")
    {
        Description = @"The system prompt to use for the research agent. Useful to steer the research agent to a specific direction.",
    };

    private static Option<global::System.Collections.Generic.IList<global::Firecrawl.StartDeepResearchRequestFormat>?> Formats { get; } = new(
        name: @"--formats")
    {
        Description = @"",
    };

    private static Option<global::Firecrawl.StartDeepResearchRequestJsonOptions?> JsonOptions { get; } = new(
        name: @"--json-options")
    {
        Description = @"Options for JSON output",
    };
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

                    private static string FormatResponse(ParseResult parseResult, global::Firecrawl.StartDeepResearchResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Firecrawl.StartDeepResearchResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    static partial void CustomizeCommand(ref Command command);

    public static Command Create(string? commandName = null)
    {
        var command = new Command(commandName ?? @"start-deep-research", @"Start a deep research operation on a query");
                        command.Options.Add(Query);
                        command.Options.Add(MaxDepth);
                        command.Options.Add(TimeLimit);
                        command.Options.Add(MaxUrls);
                        command.Options.Add(AnalysisPrompt);
                        command.Options.Add(SystemPrompt);
                        command.Options.Add(Formats);
                        command.Options.Add(JsonOptions);
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
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Firecrawl.StartDeepResearchRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Firecrawl.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var query = parseResult.GetRequiredValue(Query);
                        var maxDepth = CliRuntime.WasSpecified(parseResult, MaxDepth) ? parseResult.GetValue(MaxDepth) : (__requestBase is { } __MaxDepthBaseValue ? __MaxDepthBaseValue.MaxDepth : default);
                        var timeLimit = CliRuntime.WasSpecified(parseResult, TimeLimit) ? parseResult.GetValue(TimeLimit) : (__requestBase is { } __TimeLimitBaseValue ? __TimeLimitBaseValue.TimeLimit : default);
                        var maxUrls = CliRuntime.WasSpecified(parseResult, MaxUrls) ? parseResult.GetValue(MaxUrls) : (__requestBase is { } __MaxUrlsBaseValue ? __MaxUrlsBaseValue.MaxUrls : default);
                        var analysisPrompt = CliRuntime.WasSpecified(parseResult, AnalysisPrompt) ? parseResult.GetValue(AnalysisPrompt) : (__requestBase is { } __AnalysisPromptBaseValue ? __AnalysisPromptBaseValue.AnalysisPrompt : default);
                        var systemPrompt = CliRuntime.WasSpecified(parseResult, SystemPrompt) ? parseResult.GetValue(SystemPrompt) : (__requestBase is { } __SystemPromptBaseValue ? __SystemPromptBaseValue.SystemPrompt : default);
                        var formats = CliRuntime.WasSpecified(parseResult, Formats) ? parseResult.GetValue(Formats) : (__requestBase is { } __FormatsBaseValue ? __FormatsBaseValue.Formats : default);
                        var jsonOptions = CliRuntime.WasSpecified(parseResult, JsonOptions) ? parseResult.GetValue(JsonOptions) : (__requestBase is { } __JsonOptionsBaseValue ? __JsonOptionsBaseValue.JsonOptions : default);          var wait = parseResult.GetValue(Wait);
          var pollInterval = wait ? CliRuntime.ParseDuration(parseResult.GetRequiredValue(PollInterval), PollInterval.Name) : default;
          var waitTimeout = wait ? CliRuntime.ParseDuration(parseResult.GetRequiredValue(WaitTimeout), WaitTimeout.Name) : default;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);

                                if (wait)
                                {
                                var createResponse = await client.Research.StartDeepResearchAsync(
                                    query: query,
                                    maxDepth: maxDepth,
                                    timeLimit: timeLimit,
                                    maxUrls: maxUrls,
                                    analysisPrompt: analysisPrompt,
                                    systemPrompt: systemPrompt,
                                    formats: formats,
                                    jsonOptions: jsonOptions,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);
                                    var resourceId = global::System.Convert.ToString(
                                        createResponse.Id,
                                        global::System.Globalization.CultureInfo.InvariantCulture);
                                    if (string.IsNullOrWhiteSpace(resourceId))
                                    {
                                        throw new CliException("The create response did not contain a job id.");
                                    }

                                    var waitResponse = await CliRuntime.PollUntilTerminalAsync(
                                        fetchAsync: token => client.Research.GetDeepResearchStatusAsync(
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

                                var response = await client.Research.StartDeepResearchAsync(
                                    query: query,
                                    maxDepth: maxDepth,
                                    timeLimit: timeLimit,
                                    maxUrls: maxUrls,
                                    analysisPrompt: analysisPrompt,
                                    systemPrompt: systemPrompt,
                                    formats: formats,
                                    jsonOptions: jsonOptions,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Firecrawl.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        CustomizeCommand(ref command);
        return command;
    }
}