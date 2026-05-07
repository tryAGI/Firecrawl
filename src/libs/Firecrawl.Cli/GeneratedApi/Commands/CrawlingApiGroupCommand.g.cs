#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static class CrawlingApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"crawling", @"Crawling endpoint commands.");
                         command.Subcommands.Add(CrawlingCancelCrawlCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingCrawlUrlsCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingGetActiveCrawlsCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingGetCrawlErrorsCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingGetCrawlStatusCommandApiCommand.Create());
        return command;
    }
}