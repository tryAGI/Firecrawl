using System.CommandLine;
using System.Diagnostics.CodeAnalysis;

namespace Firecrawl.Cli.Commands;

public class CrawlCommand : Command
{
    public CrawlCommand() : base(name: "crawl", description: "Crawl a url and saves all pages as markdown")
    {
        var url = new Argument<string>(
            name: "url",
            getDefaultValue: () => string.Empty,
            description: "Input url");
        AddArgument(url);
        
        var outputPath = new Option<string>(
            name: "outputPath",
            getDefaultValue: () => string.Empty,
            description: "Output path");
        AddOption(outputPath);

        var limit = new Option<int>(
            name: "limit",
            getDefaultValue: () => 10,
            description: "Limit of pages to crawl");
        AddOption(limit);
        
        var maxDepth = new Option<int?>(
            name: "maxDepth",
            getDefaultValue: () => null,
            description: "Maximum depth to crawl relative to the entered URL. A maxDepth of 0 scrapes only the entered URL. A maxDepth of 1 scrapes the entered URL and all pages one level deep. A maxDepth of 2 scrapes the entered URL and all pages up to two levels deep. Higher values follow the same pattern.");
        AddOption(maxDepth);
        
        this.SetHandler(
            HandleAsync,
            url,
            outputPath,
            limit,
            maxDepth);
    }

    private static async Task HandleAsync(
        string url,
        string outputPath,
        int limit,
        int? maxDepth)
    {
        Console.WriteLine("Initializing...");
        
        var apiKey = await Helpers.GetApiKey().ConfigureAwait(false);
        using var api = new FirecrawlApp(apiKey);
        
        Console.WriteLine($"Crawling {url}...");

        var response = await api.Crawling.CrawlUrlsAsync(
            url: url,
            crawlerOptions: new CrawlUrlsRequestCrawlerOptions
            {
                MaxDepth = maxDepth,
                Limit = limit,
            },
            pageOptions: new CrawlUrlsRequestPageOptions
            {
                OnlyMainContent = true,
                WaitFor = 1000,
            }).ConfigureAwait(false);

        Console.WriteLine($"JobId: {response.JobId}");
        
        GetCrawlStatusResponse? statusResponse = null;
        while (true)
        {
            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
            
            statusResponse = await api.Crawl.GetCrawlStatusAsync(
                jobId: response.JobId!).ConfigureAwait(false);
            if (statusResponse.Status == "completed")
            {
                break;
            }
        }
        
        if (string.IsNullOrWhiteSpace(outputPath))
        {
            outputPath = new Uri(url).Host;
        }
        
        Directory.CreateDirectory(outputPath);
        
        var index = 0;
        foreach (var data in statusResponse.Data ?? [])
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
        foreach (char c in Path.GetInvalidFileNameChars())
        {
            url = url.Replace(c, '_');
        }
        
        return url;
    }
}