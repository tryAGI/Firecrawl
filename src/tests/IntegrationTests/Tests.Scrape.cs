namespace Firecrawl.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Scrape()
    {
        using var api = GetAuthenticatedApi();
        
        var response = await api.Scraping.ScrapeAsync("https://docs.firecrawl.dev/features/scrape");
        response.Data.Should().NotBeNull();
        response.Data!.Markdown.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Success: {response.Success}");
        if (!string.IsNullOrWhiteSpace(response.Warning))
        {
            Console.WriteLine($"Warning: {response.Warning}");
        }
        
        var fileInfo = new FileInfo("output.md");
        await File.WriteAllTextAsync(fileInfo.FullName, response.Data.Markdown);
        Console.WriteLine($"Output file: {new Uri(fileInfo.FullName).AbsoluteUri}");
    }
}
