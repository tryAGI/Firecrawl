namespace Firecrawl;

public sealed partial class FirecrawlClient
{
    /// <summary>
    /// Entry point for endpoints exposed only by the Firecrawl v2 API
    /// (parse, monitor, concurrency-check, historical usage).
    /// The v2 surface is hand-written because Firecrawl has not yet
    /// published an OpenAPI definition for v2; the generated client on this
    /// class covers v1 only.
    /// </summary>
    public V2.V2Client V2 => new(HttpClient);
}
