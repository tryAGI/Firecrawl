#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal static partial class CrawlingApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"crawling", @"Crawling endpoint commands.");
                         command.Subcommands.Add(CrawlingCancelCrawlCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingCrawlUrlsCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingGetActiveCrawlsCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingGetCrawlErrorsCommandApiCommand.Create());
                         command.Subcommands.Add(CrawlingGetCrawlStatusCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}