using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class ApiCommand
{
    static partial void CustomizeCommand(ref Command command)
    {
        // CliRoot owns these recursive symbols for both the handwritten and generated commands.
        command.Options.Remove(global::Firecrawl.Cli.GeneratedApi.CliOptions.ApiKey);
        command.Options.Remove(global::Firecrawl.Cli.GeneratedApi.CliOptions.BaseUrl);
        command.Options.Remove(global::Firecrawl.Cli.GeneratedApi.CliOptions.Json);
        command.Options.Remove(global::Firecrawl.Cli.GeneratedApi.CliOptions.Output);
    }
}
