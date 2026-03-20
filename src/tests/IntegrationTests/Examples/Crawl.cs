/*
 * order: 20
 * title: Crawl URLs
 * slug: crawl-urls
 */

namespace Firecrawl.IntegrationTests;

public partial class Tests
{
    //// Crawl multiple pages from a website and retrieve their content as markdown.
    //// The `WaitJobAsync` helper polls the crawl job until completion.

    [TestMethod]
    [Ignore("Crawl jobs take several minutes to complete")]
    public async Task Example_CrawlUrls()
    {
        using var client = GetAuthenticatedClient();
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

        response.Success.Should().BeTrue();
        response.Id.Should().NotBeNullOrEmpty();
        response.Url.Should().NotBeNullOrEmpty();

        var jobResponse = await client.Crawling.WaitJobAsync(
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
