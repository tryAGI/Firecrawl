namespace Firecrawl.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Crawl()
    {
        using var api = GetAuthenticatedApi();
        using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(5));
        var cancellationToken = cancellationTokenSource.Token;
        
        var response = await api.Crawling.CrawlUrlsAsync(
            url: "https://docs.firecrawl.dev/",
            limit: 3,
            scrapeOptions: new CrawlUrlsRequestScrapeOptions
            {
                OnlyMainContent = true,
            },
            cancellationToken: cancellationToken);

        Console.WriteLine($"Success: {response.Success}");
        Console.WriteLine($"JobId: {response.Id}");
        Console.WriteLine($"Url: {response.Url}");
        
        response.Success.Should().BeTrue();
        response.Id.Should().NotBeNullOrEmpty();
        response.Url.Should().NotBeNullOrEmpty();
        
        var jobResponse = await api.Crawling.WaitJobAsync(
            jobId: response.Id!,
            cancellationToken: cancellationToken);
        
        var index = 0;
        foreach (var data in jobResponse.Data ?? [])
        {
            data.Markdown.Should().NotBeNullOrEmpty();
            
            var fileInfo = new FileInfo($"output{++index}.md");
            await File.WriteAllTextAsync(fileInfo.FullName, data.Markdown, cancellationToken);
            Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
        }
        
        jobResponse.Should().NotBeNull();
        jobResponse.Status.Should().Be("completed");
        jobResponse.Total.Should().Be(3);
        jobResponse.Data.Should().NotBeNullOrEmpty();
    }
}
