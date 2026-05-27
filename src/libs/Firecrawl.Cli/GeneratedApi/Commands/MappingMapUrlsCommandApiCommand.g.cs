#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class MappingMapUrlsCommandApiCommand
{
    private static Argument<string> Url { get; } = new(
        name: @"url")
    {
        Description = @"The base URL to start crawling from",
    };

    private static Option<string?> Search { get; } = new(
        name: @"--search")
    {
        Description = @"Search query to use for mapping. During the Alpha phase, the 'smart' part of the search functionality is limited to 1000 search results. However, if map finds more results, there is no limit applied.",
    };

    private static Option<bool?> IgnoreSitemap { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--ignore-sitemap",
        description: @"Ignore the website sitemap when crawling.");

    private static Option<bool?> SitemapOnly { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--sitemap-only",
        description: @"Only return links found in the website sitemap");

    private static Option<bool?> IncludeSubdomains { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--include-subdomains",
        description: @"Include subdomains of the website");

    private static Option<int?> Limit { get; } = new(
        name: @"--limit")
    {
        Description = @"Maximum number of links to return",
    };

    private static Option<int?> Timeout { get; } = new(
        name: @"--timeout")
    {
        Description = @"Timeout in milliseconds. There is no timeout by default.",
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

                    private static string FormatResponse(ParseResult parseResult, global::Firecrawl.MapResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Firecrawl.MapResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"map-urls", @"Map multiple URLs based on options");
                        command.Arguments.Add(Url);
                        command.Options.Add(Search);
                        command.Options.Add(IgnoreSitemap);
                        command.Options.Add(SitemapOnly);
                        command.Options.Add(IncludeSubdomains);
                        command.Options.Add(Limit);
                        command.Options.Add(Timeout);
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
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Firecrawl.MapUrlsRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Firecrawl.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var url = parseResult.GetRequiredValue(Url);
                        var search = parseResult.GetValue(Search) ?? __requestBase?.Search;
                        var ignoreSitemap = parseResult.GetValue(IgnoreSitemap) ?? __requestBase?.IgnoreSitemap;
                        var sitemapOnly = parseResult.GetValue(SitemapOnly) ?? __requestBase?.SitemapOnly;
                        var includeSubdomains = parseResult.GetValue(IncludeSubdomains) ?? __requestBase?.IncludeSubdomains;
                        var limit = parseResult.GetValue(Limit) ?? __requestBase?.Limit;
                        var timeout = parseResult.GetValue(Timeout) ?? __requestBase?.Timeout;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Mapping.MapUrlsAsync(
                                    url: url,
                                    search: search,
                                    ignoreSitemap: ignoreSitemap,
                                    sitemapOnly: sitemapOnly,
                                    includeSubdomains: includeSubdomains,
                                    limit: limit,
                                    timeout: timeout,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                if (!await CliRuntime.TryWriteOutputDirectoryAsync(
                                        parseResult,
                                        response,
                                        global::Firecrawl.SourceGenerationContext.Default,
                                        @"Links",
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