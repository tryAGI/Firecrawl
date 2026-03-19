/*
order: 30
title: Scrape
slug: scrape
*/

namespace Firecrawl.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Scrape()
    {
        using var client = GetAuthenticatedClient();
        
        var response = await client.Scraping.ScrapeAndExtractFromUrlAsync(new AllOf<ScrapeAndExtractFromUrlRequest2, ScrapeOptions> 
        {
            Value1 = new ScrapeAndExtractFromUrlRequest2
            {
                Url = "https://docs.firecrawl.dev/features/scrape",
            },
        });
        response.Data.Should().NotBeNull();
        response.Data!.Markdown.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Success: {response.Success}");
        
        var fileInfo = new FileInfo("output.md");
        await File.WriteAllTextAsync(fileInfo.FullName, response.Data.Markdown);
        Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
    }
}
