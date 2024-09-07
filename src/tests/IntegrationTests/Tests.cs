namespace Firecrawl.IntegrationTests;

[TestClass]
public partial class Tests
{
    [TestMethod]
    public FirecrawlApp GetAuthenticatedApi()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("FIRECRAWL_API_KEY") ??
            throw new AssertInconclusiveException("FIRECRAWL_API_KEY environment variable is not found.");

        var api = new FirecrawlApp(apiKey);
        
        return api;
    }
}
