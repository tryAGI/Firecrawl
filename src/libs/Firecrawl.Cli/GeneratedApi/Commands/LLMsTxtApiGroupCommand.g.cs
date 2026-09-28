#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class LLMsTxtApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"llms-txt", @"LLMs.txt endpoint commands.");
                         command.Subcommands.Add(LLMsTxtGenerateLLMsTxtCommandApiCommand.Create());
                         command.Subcommands.Add(LLMsTxtGetLLMsTxtStatusCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}