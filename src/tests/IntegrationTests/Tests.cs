namespace Firecrawl.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static FirecrawlClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("FIRECRAWL_API_KEY") ??
            throw new AssertInconclusiveException("FIRECRAWL_API_KEY environment variable is not found.");

        var client = new FirecrawlClient(apiKey);
        
        return client;
    }
}
