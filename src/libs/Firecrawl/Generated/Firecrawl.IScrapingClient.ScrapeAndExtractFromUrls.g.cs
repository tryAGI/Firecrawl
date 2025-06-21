#nullable enable

namespace Firecrawl
{
    public partial interface IScrapingClient
    {
        /// <summary>
        /// Scrape multiple URLs and optionally extract information using an LLM
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.BatchScrapeResponseObj> ScrapeAndExtractFromUrlsAsync(
            global::Firecrawl.AllOf<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions> request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Scrape multiple URLs and optionally extract information using an LLM
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.BatchScrapeResponseObj> ScrapeAndExtractFromUrlsAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}