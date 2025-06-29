#nullable enable

namespace Firecrawl
{
    public partial interface ICrawlingClient
    {
        /// <summary>
        /// Get the errors of a crawl job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CrawlErrorsResponseObj> GetCrawlErrorsAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}