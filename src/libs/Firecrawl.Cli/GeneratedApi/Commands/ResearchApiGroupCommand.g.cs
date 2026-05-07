#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class ResearchApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"research", @"Research endpoint commands.");
                         command.Subcommands.Add(ResearchGetDeepResearchStatusCommandApiCommand.Create());
                         command.Subcommands.Add(ResearchStartDeepResearchCommandApiCommand.Create());
        return command;
    }
}