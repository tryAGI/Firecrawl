```csharp
using var client = new FirecrawlClient(apiKey);

var response = await client.Scraping.ScrapeAndExtractFromUrlAsync(new AllOf<ScrapeAndExtractFromUrlRequest2, ScrapeOptions>
{
    Value1 = new ScrapeAndExtractFromUrlRequest2
    {
        Url = "https://docs.firecrawl.dev/features/scrape",
    },
});

Console.WriteLine($"Success: {response.Success}");

var fileInfo = new FileInfo("output.md");
await File.WriteAllTextAsync(fileInfo.FullName, response.Data.Markdown);
Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
```