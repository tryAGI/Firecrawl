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
        /// <param name="crawlerOptions"></param>
        /// <param name="pageOptions"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CrawlResponse> CrawlUrlsAsync(
            string url,
            global::Firecrawl.CrawlUrlsRequestCrawlerOptions? crawlerOptions = default,
            global::Firecrawl.CrawlUrlsRequestPageOptions? pageOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}