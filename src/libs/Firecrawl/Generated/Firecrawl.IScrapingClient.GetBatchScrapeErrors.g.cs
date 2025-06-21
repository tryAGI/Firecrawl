#nullable enable

namespace Firecrawl
{
    public partial interface IScrapingClient
    {
        /// <summary>
        /// Get the errors of a batch scrape job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.CrawlErrorsResponseObj> GetBatchScrapeErrorsAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}