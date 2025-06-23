using System.CommandLine;

namespace Firecrawl.Cli.Commands;

internal sealed class CrawlCommand : Command
{
    private Argument<string> Url { get; } = new(name: "url")
    {
        DefaultValueFactory = _ => string.Empty,
        Description = "Input url",
    };
    
    private Option<string> OutputPath { get; } = new(
        name: "--output",
        aliases: ["-o"])
    {
        DefaultValueFactory = _ => string.Empty,
        Description = "Output path",
    };
    
    private Option<int> Limit { get; } = new(
        name: "--limit",
        aliases: ["-l"])
    {
        DefaultValueFactory = _ => 5,
        Description = "Limit of pages to crawl",
    };
    
    private Option<int?> MaxDepth { get; } = new(
        name: "--max-depth",
        aliases: ["-d"])
    {
        DefaultValueFactory = _ => null,
        Description = "Maximum depth to crawl relative to the entered URL. A maxDepth of 0 scrapes only the entered URL. A maxDepth of 1 scrapes the entered URL and all pages one level deep. A maxDepth of 2 scrapes the entered URL and all pages up to two levels deep. Higher values follow the same pattern.",
    };

    public CrawlCommand() : base(
        name: "crawl",
        description: "Crawl a url and saves all pages as markdown")
    {
        Arguments.Add(Url);
        Options.Add(OutputPath);
        Options.Add(Limit);
        Options.Add(MaxDepth);
        
        SetAction(HandleAsync);
    }

    private async Task HandleAsync(ParseResult parseResult)
    {
        var url = parseResult.GetRequiredValue(Url);
        var outputPath = parseResult.GetRequiredValue(OutputPath);
        var limit = parseResult.GetRequiredValue(Limit);
        var maxDepth = parseResult.GetRequiredValue(MaxDepth);
            
        Console.WriteLine("Initializing...");
        
        var apiKey = await Helpers.GetApiKey().ConfigureAwait(false);
        using var api = new FirecrawlApp(apiKey);
        
        Console.WriteLine($"Crawling {url}...");

        var response = await api.Crawling.CrawlUrlsAsync(
            url: url,
            maxDepth: maxDepth,
            limit: limit,
            scrapeOptions: new ScrapeOptions
            {
                OnlyMainContent = true,
                WaitFor = 1000,
            }).ConfigureAwait(false);

        Console.WriteLine($"Success: {response.Success}");
        Console.WriteLine($"JobId: {response.Id}");
        Console.WriteLine($"Url: {response.Url}");
        
        var jobResponse = await api.Crawling.WaitJobAsync(
            jobId: response.Id!).ConfigureAwait(false);
        
        if (string.IsNullOrWhiteSpace(outputPath))
        {
            outputPath = new Uri(url).Host;
        }
        
        Directory.CreateDirectory(outputPath);
        
        var index = 0;
        foreach (var data in jobResponse.Data ?? [])
        {
            var name = string.IsNullOrWhiteSpace(data.Metadata?.SourceURL)
                ? $"output{++index}.md"
                : $"{ConvertUrlToFilename(data.Metadata.SourceURL)}.md";
            var subPath = Path.Combine(outputPath, name);
            
            var fileInfo = new FileInfo(subPath);
            await File.WriteAllTextAsync(fileInfo.FullName, data.Markdown).ConfigureAwait(false);
            Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
        }
        
        Console.WriteLine("Done.");
    }
    
    public static string ConvertUrlToFilename(string url)
    {
        url = url ?? throw new ArgumentNullException(nameof(url));
        
        url = url
            .Replace("https://", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("https:/", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("http://", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("http:/", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("www.", string.Empty, StringComparison.OrdinalIgnoreCase);
        
        // Replace invalid filename characters with '_'
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            url = url.Replace(c, '_');
        }
        
        return url;
    }
}