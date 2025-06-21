#nullable enable

namespace Firecrawl
{
    public partial interface IBillingClient
    {
        /// <summary>
        /// Get remaining tokens for the authenticated team (Extract only)
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetTokenUsageResponse> GetTokenUsageAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}