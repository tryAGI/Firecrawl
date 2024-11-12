#nullable enable

namespace Firecrawl
{
    public partial interface ICrawlClient
    {
        /// <summary>
        /// Cancel a crawl job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CancelCrawlJobResponse> CancelCrawlJobAsync(
            string jobId,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}