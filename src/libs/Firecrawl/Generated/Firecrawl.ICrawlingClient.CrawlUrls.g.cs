#nullable enable

namespace Firecrawl
{
    public partial interface ICrawlingClient
    {
        /// <summary>
        /// Crawl multiple URLs based on options
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CrawlResponse> CrawlUrlsAsync(
            global::Firecrawl.CrawlUrlsRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Crawl multiple URLs based on options
        /// </summary>
        /// <param name="url">
        /// The base URL to start crawling from
        /// </param>
        /// <param name="excludePaths">
        /// Specifies URL patterns to exclude from the crawl by comparing website paths against the provided regex patterns. For example, if you set "excludePaths": ["blog/*"] for the base URL firecrawl.dev, any results matching that pattern will be excluded, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </param>
        /// <param name="includePaths">
        /// Specifies URL patterns to include in the crawl by comparing website paths against the provided regex patterns. Only the paths that match the specified patterns will be included in the response. For example, if you set "includePaths": ["blog/*"] for the base URL firecrawl.dev, only results matching that pattern will be included, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </param>
        /// <param name="maxDepth">
        /// Maximum depth to crawl relative to the entered URL.<br/>
        /// Default Value: 2
        /// </param>
        /// <param name="ignoreSitemap">
        /// Ignore the website sitemap when crawling<br/>
        /// Default Value: false
        /// </param>
        /// <param name="limit">
        /// Maximum number of pages to crawl. Default limit is 10000.<br/>
        /// Default Value: 10000
        /// </param>
        /// <param name="allowBackwardLinks">
        /// Enables the crawler to navigate from a specific URL to previously linked pages.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="allowExternalLinks">
        /// Allows the crawler to follow links to external websites.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="webhook"></param>
        /// <param name="scrapeOptions"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CrawlResponse> CrawlUrlsAsync(
            string url,
            global::System.Collections.Generic.IList<string>? excludePaths = default,
            global::System.Collections.Generic.IList<string>? includePaths = default,
            int? maxDepth = default,
            bool? ignoreSitemap = default,
            int? limit = default,
            bool? allowBackwardLinks = default,
            bool? allowExternalLinks = default,
            global::Firecrawl.OneOf<string, global::Firecrawl.CrawlUrlsRequestWebhook>? webhook = default,
            global::Firecrawl.CrawlUrlsRequestScrapeOptions? scrapeOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}