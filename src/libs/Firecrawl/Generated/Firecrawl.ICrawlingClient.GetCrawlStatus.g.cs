#nullable enable

namespace Firecrawl
{
    public partial interface ICrawlingClient
    {
        /// <summary>
        /// Get the status of a crawl job
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CrawlStatusResponseObj> GetCrawlStatusAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}