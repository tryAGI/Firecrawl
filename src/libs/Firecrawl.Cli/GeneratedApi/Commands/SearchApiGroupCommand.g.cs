#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class SearchApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"search", @"Search endpoint commands.");
                         command.Subcommands.Add(SearchSearchAndScrapeCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}