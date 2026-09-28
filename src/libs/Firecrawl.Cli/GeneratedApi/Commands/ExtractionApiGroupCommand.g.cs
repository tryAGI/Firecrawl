#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class ExtractionApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"extraction", @"Extraction endpoint commands.");
                         command.Subcommands.Add(ExtractionExtractDataCommandApiCommand.Create());
                         command.Subcommands.Add(ExtractionGetExtractStatusCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}