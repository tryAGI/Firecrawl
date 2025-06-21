#nullable enable

namespace Firecrawl
{
    public partial interface IScrapingClient
    {
        /// <summary>
        /// Scrape a single URL and optionally extract information using an LLM
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAndExtractFromUrlAsync(
            global::Firecrawl.AllOf<global::Firecrawl.ScrapeAndExtractFromUrlRequest2, global::Firecrawl.ScrapeOptions> request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Scrape a single URL and optionally extract information using an LLM
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAndExtractFromUrlAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}