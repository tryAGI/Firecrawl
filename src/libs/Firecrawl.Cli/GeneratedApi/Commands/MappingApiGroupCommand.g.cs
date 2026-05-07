#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class MappingApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"mapping", @"Mapping endpoint commands.");
                         command.Subcommands.Add(MappingMapUrlsCommandApiCommand.Create());
        return command;
    }
}