#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class ExtractionApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"extraction", @"Extraction endpoint commands.");
                         command.Subcommands.Add(ExtractionExtractDataCommandApiCommand.Create());
                         command.Subcommands.Add(ExtractionGetExtractStatusCommandApiCommand.Create());
        return command;
    }
}