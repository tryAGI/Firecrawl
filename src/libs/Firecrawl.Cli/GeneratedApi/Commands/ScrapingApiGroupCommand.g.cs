#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class ScrapingApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"scraping", @"Scraping endpoint commands.");
                         command.Subcommands.Add(ScrapingCancelBatchScrapeCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingGetBatchScrapeErrorsCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingGetBatchScrapeStatusCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingScrapeAndExtractFromUrlCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingScrapeAndExtractFromUrlsCommandApiCommand.Create());
        return command;
    }
}