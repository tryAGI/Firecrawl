using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class CrawlingGetActiveCrawlsCommandApiCommand
{
    static partial void CustomizeResponseText(
        ParseResult parseResult,
        global::Firecrawl.GetActiveCrawlsResponse value,
        ref string? text)
    {
        text = global::Firecrawl.Cli.CliRuntime.FormatActiveCrawls(value);
    }
}
