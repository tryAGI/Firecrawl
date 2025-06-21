#nullable enable

namespace Firecrawl
{
    public partial interface ISearchClient
    {
        /// <summary>
        /// Search and optionally scrape search results
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.SearchAndScrapeResponse> SearchAndScrapeAsync(
            global::Firecrawl.SearchAndScrapeRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Search and optionally scrape search results
        /// </summary>
        /// <param name="query">
        /// The search query
        /// </param>
        /// <param name="limit">
        /// Maximum number of results to return<br/>
        /// Default Value: 5
        /// </param>
        /// <param name="tbs">
        /// Time-based search parameter
        /// </param>
        /// <param name="location">
        /// Location parameter for search results
        /// </param>
        /// <param name="timeout">
        /// Timeout in milliseconds<br/>
        /// Default Value: 60000
        /// </param>
        /// <param name="ignoreInvalidURLs">
        /// Excludes URLs from the search results that are invalid for other Firecrawl endpoints. This helps reduce errors if you are piping data from search into other Firecrawl API endpoints.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="scrapeOptions">
        /// Options for scraping search results
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.SearchAndScrapeResponse> SearchAndScrapeAsync(
            string query,
            int? limit = default,
            string? tbs = default,
            string? location = default,
            int? timeout = default,
            bool? ignoreInvalidURLs = default,
            global::Firecrawl.SearchAndScrapeRequestScrapeOptions? scrapeOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}