using System.CommandLine;

namespace Firecrawl.Cli.Commands;

internal sealed class ScrapeCommand : Command
{
    private Argument<string> Url { get; } = new(
        name: "url")
    {
        DefaultValueFactory = _ => string.Empty,
        Description = "Input url",
    };
    
    private Option<string> OutputPath { get; } = new(
        name: "--output",
        aliases: ["-o"])
    {
        DefaultValueFactory = _ => "output.md",
        Description = "Output path",
    };
    
    public ScrapeCommand() : base(
        name: "scrape",
        description: "Scrapes page and saves it as markdown")
    {
        Arguments.Add(Url);
        Options.Add(OutputPath);
        
        SetAction(HandleAsync);
    }

    private async Task HandleAsync(
        ParseResult parseResult)
    {
        var url = parseResult.GetRequiredValue(Url);
        var outputPath = parseResult.GetRequiredValue(OutputPath);

        Console.WriteLine("Initializing...");
        
        var apiKey = await Helpers.GetApiKey().ConfigureAwait(false);
        using var api = new FirecrawlApp(apiKey);
        
        Console.WriteLine($"Scraping {url}...");

        var response = await api.Scraping.ScrapeAndExtractFromUrlAsync(new AllOf<ScrapeAndExtractFromUrlRequest2, ScrapeOptions>
        {
            Value1 = new ScrapeAndExtractFromUrlRequest2
            {
                Url = url,
            }
        }).ConfigureAwait(false);

        Console.WriteLine($"Success: {response.Success}");
        
        var fileInfo = new FileInfo(outputPath);
        await File.WriteAllTextAsync(fileInfo.FullName, response.Data?.Markdown).ConfigureAwait(false);
        Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
        
        Console.WriteLine("Done.");
    }
}