using System.CommandLine;
using Firecrawl.Cli.Commands;

var rootCommand = new RootCommand(
    description: "CLI tool to use Firecrawl API");
rootCommand.Subcommands.Add(new AuthCommand());
rootCommand.Subcommands.Add(new ScrapeCommand());
rootCommand.Subcommands.Add(new CrawlCommand());
rootCommand.Subcommands.Add(new MapCommand());

return await rootCommand.Parse(args).InvokeAsync().ConfigureAwait(false);