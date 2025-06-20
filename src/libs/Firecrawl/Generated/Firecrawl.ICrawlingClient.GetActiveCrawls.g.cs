#nullable enable

namespace Firecrawl
{
    public partial interface ICrawlingClient
    {
        /// <summary>
        /// Get all active crawls for the authenticated team
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetActiveCrawlsResponse> GetActiveCrawlsAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}