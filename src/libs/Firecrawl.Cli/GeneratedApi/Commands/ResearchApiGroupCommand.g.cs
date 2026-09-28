#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class ResearchApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"research", @"Research endpoint commands.");
                         command.Subcommands.Add(ResearchGetDeepResearchStatusCommandApiCommand.Create());
                         command.Subcommands.Add(ResearchStartDeepResearchCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}