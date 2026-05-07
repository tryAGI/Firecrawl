#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class ApiCommand
{
    public static Command Create()
    {
        var command = new Command("api", "Generated endpoint commands.");
          command.Options.Add(CliOptions.ApiKey);
          command.Options.Add(CliOptions.BaseUrl);
          command.Options.Add(CliOptions.Output);
                         command.Subcommands.Add(BillingApiGroupCommand.Create());
                         command.Subcommands.Add(CrawlingApiGroupCommand.Create());
                         command.Subcommands.Add(ExtractionApiGroupCommand.Create());
                         command.Subcommands.Add(LLMsTxtApiGroupCommand.Create());
                         command.Subcommands.Add(MappingApiGroupCommand.Create());
                         command.Subcommands.Add(ResearchApiGroupCommand.Create());
                         command.Subcommands.Add(ScrapingApiGroupCommand.Create());
                         command.Subcommands.Add(SearchApiGroupCommand.Create());
        return command;
    }
}