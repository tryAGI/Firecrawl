# Crawl



This example assumes `using Firecrawl;` is in scope and `apiKey` contains your Firecrawl API key.

```csharp
using var client = new FirecrawlClient(apiKey);
using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(5));
var cancellationToken = cancellationTokenSource.Token;

var response = await client.Crawling.CrawlUrlsAsync(
    url: "https://docs.firecrawl.dev/",
    limit: 3,
    scrapeOptions: new ScrapeOptions
    {
        OnlyMainContent = true,
    },
    cancellationToken: cancellationToken);

Console.WriteLine($"Success: {response.Success}");
Console.WriteLine($"JobId: {response.Id}");
Console.WriteLine($"Url: {response.Url}");

var jobResponse = await client.Crawling.WaitJobAsync(
    jobId: response.Id!,
    cancellationToken: cancellationToken);

var index = 0;
foreach (var data in jobResponse.Data ?? [])
{

    var fileInfo = new FileInfo($"output{++index}.md");
    await File.WriteAllTextAsync(fileInfo.FullName, data.Markdown, cancellationToken);
    Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
}
```