#nullable enable

namespace Firecrawl
{
    public partial interface IResearchClient
    {
        /// <summary>
        /// Get the status and results of a deep research operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetDeepResearchStatusResponse> GetDeepResearchStatusAsync(
            string id,
            global::Firecrawl.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}