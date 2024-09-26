#nullable enable

namespace Firecrawl
{
    public partial interface ISearchClient
    {
        /// <summary>
        /// Search for a keyword in Google, returns top page results with markdown content for each page
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.SearchResponse> SearchGoogleAsync(
            global::Firecrawl.SearchGoogleRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Search for a keyword in Google, returns top page results with markdown content for each page
        /// </summary>
        /// <param name="query">
        /// The query to search for
        /// </param>
        /// <param name="pageOptions"></param>
        /// <param name="searchOptions"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.SearchResponse> SearchGoogleAsync(
            string query,
            global::Firecrawl.SearchGoogleRequestPageOptions? pageOptions = default,
            global::Firecrawl.SearchGoogleRequestSearchOptions? searchOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}