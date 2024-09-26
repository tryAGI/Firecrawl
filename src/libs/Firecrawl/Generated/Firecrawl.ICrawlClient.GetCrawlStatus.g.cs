#nullable enable

namespace Firecrawl
{
    public partial interface ICrawlClient
    {
        /// <summary>
        /// Get the status of a crawl job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetCrawlStatusResponse> GetCrawlStatusAsync(
            string jobId,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}