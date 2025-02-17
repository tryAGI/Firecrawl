using System.CommandLine;

namespace Firecrawl.Cli.Commands;

internal sealed class ScrapeCommand : Command
{
    public ScrapeCommand() : base(
        name: "scrape",
        description: "Scrapes page and saves it as markdown")
    {
        var url = new Argument<string>(
            name: "url",
            getDefaultValue: () => string.Empty,
            description: "Input url");
        AddArgument(url);
        
        var outputPath = new Option<string>(
            aliases: ["--output", "-o"],
            getDefaultValue: () => "output.md",
            description: "Output path");
        AddOption(outputPath);
        
        this.SetHandler(
            HandleAsync,
            url,
            outputPath);
    }

    private static async Task HandleAsync(
        string url,
        string outputPath)
    {
        Console.WriteLine("Initializing...");
        
        var apiKey = await Helpers.GetApiKey().ConfigureAwait(false);
        using var api = new FirecrawlApp(apiKey);
        
        Console.WriteLine($"Scraping {url}...");

        var response = await api.Scraping.ScrapeAndExtractFromUrlAsync(url).ConfigureAwait(false);

        Console.WriteLine($"Success: {response.Success}");
        
        var fileInfo = new FileInfo(outputPath);
        await File.WriteAllTextAsync(fileInfo.FullName, response.Data?.Markdown).ConfigureAwait(false);
        Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
        
        Console.WriteLine("Done.");
    }
}