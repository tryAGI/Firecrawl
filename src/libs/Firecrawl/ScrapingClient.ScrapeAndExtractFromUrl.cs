namespace Firecrawl;

public partial class ScrapingClient
{
    /// <summary>
    /// Scrape a single URL and optionally apply scrape options.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    public Task<ScrapeResponse> ScrapeAndExtractFromUrlAsync(
        Uri url,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        return ScrapeAndExtractFromUrlAsync(
            url: url.ToString(),
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Scrape a single URL and apply the provided scrape options.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    public Task<ScrapeResponse> ScrapeAndExtractFromUrlAsync(
        Uri url,
        ScrapeOptions options,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(url);

        return ScrapeAndExtractFromUrlAsync(
            url: url.ToString(),
            options: options,
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Scrape a single URL and optionally apply scrape options.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    public Task<ScrapeResponse> ScrapeAndExtractFromUrlAsync(
        string url,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);

        return ScrapeAndExtractFromUrlAsync(
            request: new AllOf<ScrapeAndExtractFromUrlRequest2, ScrapeOptions>(
                new ScrapeAndExtractFromUrlRequest2
                {
                    Url = url,
                },
                new ScrapeOptions()),
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Scrape a single URL and apply the provided scrape options.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="options"></param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    public Task<ScrapeResponse> ScrapeAndExtractFromUrlAsync(
        string url,
        ScrapeOptions options,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        ArgumentNullException.ThrowIfNull(options);

        return ScrapeAndExtractFromUrlAsync(
            request: new AllOf<ScrapeAndExtractFromUrlRequest2, ScrapeOptions>(
                new ScrapeAndExtractFromUrlRequest2
                {
                    Url = url,
                },
                options),
            cancellationToken: cancellationToken);
    }
}
