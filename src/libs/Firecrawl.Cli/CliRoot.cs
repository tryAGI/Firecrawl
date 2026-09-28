using System.CommandLine;

namespace Firecrawl.Cli;

internal static class CliRoot
{
    public static IReadOnlyList<string> SupportedOperationIds { get; } =
    [
        "scrapeAndExtractFromUrl",
        "scrapeAndExtractFromUrls",
        "getBatchScrapeStatus",
        "cancelBatchScrape",
        "getBatchScrapeErrors",
        "getCrawlStatus",
        "cancelCrawl",
        "getCrawlErrors",
        "crawlUrls",
        "mapUrls",
        "extractData",
        "getExtractStatus",
        "getActiveCrawls",
        "startDeepResearch",
        "getDeepResearchStatus",
        "getCreditUsage",
        "getTokenUsage",
        "searchAndScrape",
        "generateLLMsTxt",
        "getLLMsTxtStatus",
    ];

    public static RootCommand CreateRootCommand()
    {
        // The generated API group releases its shared options in its partial hook before
        // the root attaches them, so both handwritten and generated commands read one symbol.
        var apiCommand = GeneratedApi.Commands.ApiCommand.Create();
        var rootCommand = new RootCommand("First-class CLI for the Firecrawl API");
        rootCommand.Options.Add(CliOptions.ApiKey);
        rootCommand.Options.Add(CliOptions.BaseUrl);
        rootCommand.Options.Add(CliOptions.Json);

        rootCommand.Subcommands.Add(CliCommands.CreateAuthCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateScrapeCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateBatchScrapeCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateCrawlCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateMapCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateExtractCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateDeepResearchCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateTeamCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateSearchCommand());
        rootCommand.Subcommands.Add(CliCommands.CreateLlmstxtCommand());
        rootCommand.Subcommands.Add(apiCommand);

        return rootCommand;
    }
}

internal static partial class CliCommands
{
}
