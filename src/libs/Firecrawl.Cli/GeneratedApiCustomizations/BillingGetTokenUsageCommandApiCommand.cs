using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class BillingGetTokenUsageCommandApiCommand
{
    static partial void CustomizeResponseText(
        ParseResult parseResult,
        global::Firecrawl.GetTokenUsageResponse value,
        ref string? text)
    {
        text = global::Firecrawl.Cli.CliRuntime.FormatTokenUsage(value);
    }
}
