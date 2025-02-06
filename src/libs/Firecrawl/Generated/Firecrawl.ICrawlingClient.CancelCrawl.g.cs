#nullable enable

namespace Firecrawl
{
    public partial interface ICrawlingClient
    {
        /// <summary>
        /// Cancel a crawl job
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CancelCrawlResponse> CancelCrawlAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}