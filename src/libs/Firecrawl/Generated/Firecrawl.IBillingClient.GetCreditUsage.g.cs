#nullable enable

namespace Firecrawl
{
    public partial interface IBillingClient
    {
        /// <summary>
        /// Get remaining credits for the authenticated team
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetCreditUsageResponse> GetCreditUsageAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}