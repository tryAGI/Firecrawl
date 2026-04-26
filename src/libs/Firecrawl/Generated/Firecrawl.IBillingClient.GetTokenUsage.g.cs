#nullable enable

namespace Firecrawl
{
    public partial interface IBillingClient
    {
        /// <summary>
        /// Get remaining tokens for the authenticated team (Extract only)
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetTokenUsageResponse> GetTokenUsageAsync(
            global::Firecrawl.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}