#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class SearchSearchAndScrapeCommandApiCommand
{
    private static Option<string> Query { get; } = new(
        name: @"--query")
    {
        Description = @"The search query",
        Required = true,
    };

    private static Option<int?> Limit { get; } = new(
        name: @"--limit")
    {
        Description = @"Maximum number of results to return",
    };

    private static Option<string?> Tbs { get; } = new(
        name: @"--tbs")
    {
        Description = @"Time-based search parameter",
    };

    private static Option<string?> Location { get; } = new(
        name: @"--location")
    {
        Description = @"Location parameter for search results",
    };

    private static Option<int?> Timeout { get; } = new(
        name: @"--timeout")
    {
        Description = @"Timeout in milliseconds",
    };

    private static Option<bool?> IgnoreInvalidURLs { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--ignore-invalid-urls",
        description: @"Excludes URLs from the search results that are invalid for other Firecrawl endpoints. This helps reduce errors if you are piping data from search into other Firecrawl API endpoints.");

    private static Option<global::Firecrawl.SearchAndScrapeRequestScrapeOptions?> ScrapeOptions { get; } = new(
        name: @"--scrape-options")
    {
        Description = @"Options for scraping search results",
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

                    private static string FormatResponse(ParseResult parseResult, global::Firecrawl.SearchAndScrapeResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Firecrawl.SearchAndScrapeResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"search-and-scrape", @"Search and optionally scrape search results");
                        command.Options.Add(Query);
                        command.Options.Add(Limit);
                        command.Options.Add(Tbs);
                        command.Options.Add(Location);
                        command.Options.Add(Timeout);
                        command.Options.Add(IgnoreInvalidURLs);
                        command.Options.Add(ScrapeOptions);
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

        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Firecrawl.SearchAndScrapeRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Firecrawl.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var query = parseResult.GetRequiredValue(Query);
                        var limit = CliRuntime.WasSpecified(parseResult, Limit) ? parseResult.GetValue(Limit) : (__requestBase is { } __LimitBaseValue ? __LimitBaseValue.Limit : default);
                        var tbs = CliRuntime.WasSpecified(parseResult, Tbs) ? parseResult.GetValue(Tbs) : (__requestBase is { } __TbsBaseValue ? __TbsBaseValue.Tbs : default);
                        var location = CliRuntime.WasSpecified(parseResult, Location) ? parseResult.GetValue(Location) : (__requestBase is { } __LocationBaseValue ? __LocationBaseValue.Location : default);
                        var timeout = CliRuntime.WasSpecified(parseResult, Timeout) ? parseResult.GetValue(Timeout) : (__requestBase is { } __TimeoutBaseValue ? __TimeoutBaseValue.Timeout : default);
                        var ignoreInvalidURLs = CliRuntime.WasSpecified(parseResult, IgnoreInvalidURLs) ? parseResult.GetValue(IgnoreInvalidURLs) : (__requestBase is { } __IgnoreInvalidURLsBaseValue ? __IgnoreInvalidURLsBaseValue.IgnoreInvalidURLs : default);
                        var scrapeOptions = CliRuntime.WasSpecified(parseResult, ScrapeOptions) ? parseResult.GetValue(ScrapeOptions) : (__requestBase is { } __ScrapeOptionsBaseValue ? __ScrapeOptionsBaseValue.ScrapeOptions : default);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Search.SearchAndScrapeAsync(
                                    query: query,
                                    limit: limit,
                                    tbs: tbs,
                                    location: location,
                                    timeout: timeout,
                                    ignoreInvalidURLs: ignoreInvalidURLs,
                                    scrapeOptions: scrapeOptions,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                if (!await CliRuntime.TryWriteOutputDirectoryAsync(
                                        parseResult,
                                        response,
                                        global::Firecrawl.SourceGenerationContext.Default,
                                        @"Data",
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