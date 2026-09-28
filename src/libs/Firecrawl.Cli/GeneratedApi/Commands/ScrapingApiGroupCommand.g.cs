#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class ScrapingApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"scraping", @"Scraping endpoint commands.");
                         command.Subcommands.Add(ScrapingCancelBatchScrapeCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingGetBatchScrapeErrorsCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingGetBatchScrapeStatusCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingScrapeAndExtractFromUrlCommandApiCommand.Create());
                         command.Subcommands.Add(ScrapingScrapeAndExtractFromUrlsCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}