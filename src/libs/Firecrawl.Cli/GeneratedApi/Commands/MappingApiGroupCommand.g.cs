#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class MappingApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"mapping", @"Mapping endpoint commands.");
                         command.Subcommands.Add(MappingMapUrlsCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}