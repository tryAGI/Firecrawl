namespace Firecrawl;

/// <summary>
/// Sends <c>x-idempotency-key</c> headers on POST endpoints that the Firecrawl
/// server processes through the idempotency middleware (crawl + batch scrape).
/// Pair with the same key across retries so the server collapses duplicates
/// rather than starting a second job.
/// </summary>
public static class IdempotencyKeyExtensions
{
    /// <summary>
    /// Header name documented by Firecrawl for idempotent POSTs.
    /// </summary>
    public const string HeaderName = "x-idempotency-key";

    private static AutoSDKRequestOptions WithIdempotencyKey(
        this AutoSDKRequestOptions? options,
        string idempotencyKey)
    {
        if (string.IsNullOrWhiteSpace(idempotencyKey))
            throw new ArgumentException("Idempotency key cannot be empty.", nameof(idempotencyKey));

        var merged = options ?? new AutoSDKRequestOptions();
        merged.Headers[HeaderName] = idempotencyKey;
        return merged;
    }

    /// <summary>
    /// Starts a batch scrape with the supplied idempotency key. The server
    /// will return the same job ID for repeated calls within its retention
    /// window (currently ~12 hours).
    /// </summary>
    public static Task<BatchScrapeResponseObj> ScrapeAndExtractFromUrlsWithIdempotencyAsync(
        this ScrapingClient client,
        AllOf<ScrapeAndExtractFromUrlsRequest2, ScrapeOptions> request,
        string idempotencyKey,
        AutoSDKRequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return client.ScrapeAndExtractFromUrlsAsync(
            request: request,
            requestOptions: requestOptions.WithIdempotencyKey(idempotencyKey),
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Starts a crawl with the supplied idempotency key.
    /// </summary>
    public static Task<CrawlResponse> CrawlUrlsWithIdempotencyAsync(
        this CrawlingClient client,
        CrawlUrlsRequest request,
        string idempotencyKey,
        AutoSDKRequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return client.CrawlUrlsAsync(
            request: request,
            requestOptions: requestOptions.WithIdempotencyKey(idempotencyKey),
            cancellationToken: cancellationToken);
    }
}
