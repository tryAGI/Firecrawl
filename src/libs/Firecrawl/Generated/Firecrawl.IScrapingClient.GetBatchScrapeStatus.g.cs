#nullable enable

namespace Firecrawl
{
    public partial interface IScrapingClient
    {
        /// <summary>
        /// Get the status of a batch scrape job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.BatchScrapeStatusResponseObj> GetBatchScrapeStatusAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}