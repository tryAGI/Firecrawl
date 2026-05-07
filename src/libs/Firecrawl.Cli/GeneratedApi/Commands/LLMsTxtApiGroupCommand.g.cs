#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class LLMsTxtApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"llms-txt", @"LLMs.txt endpoint commands.");
                         command.Subcommands.Add(LLMsTxtGenerateLLMsTxtCommandApiCommand.Create());
                         command.Subcommands.Add(LLMsTxtGetLLMsTxtStatusCommandApiCommand.Create());
        return command;
    }
}