#nullable enable

namespace Firecrawl
{
    public partial interface IResearchClient
    {
        /// <summary>
        /// Get the status and results of a deep research operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetDeepResearchStatusResponse> GetDeepResearchStatusAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}