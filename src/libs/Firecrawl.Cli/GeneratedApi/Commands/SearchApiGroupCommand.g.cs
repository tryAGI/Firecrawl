#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class SearchApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"search", @"Search endpoint commands.");
                         command.Subcommands.Add(SearchSearchAndScrapeCommandApiCommand.Create());
        return command;
    }
}