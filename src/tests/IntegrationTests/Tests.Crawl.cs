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
            crawlerOptions: new CrawlUrlsRequestCrawlerOptions
            {
                Limit = 3,
            },
            pageOptions: new CrawlUrlsRequestPageOptions
            {
                IncludeHtml = true,
                OnlyMainContent = true,
            },
            cancellationToken: cancellationToken);

        Console.WriteLine($"JobId: {response.JobId}");
        
        response.JobId.Should().NotBeNullOrEmpty();
        
        var jobResponse = await api.Crawl.WaitJobAsync(
            jobId: response.JobId!,
            cancellationToken: cancellationToken);
        
        var index = 0;
        foreach (var data in jobResponse.Data ?? [])
        {
            data.Html.Should().NotBeNullOrEmpty();
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
