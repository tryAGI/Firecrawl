#nullable enable

namespace Firecrawl
{
    public partial interface ILLMsTxtClient
    {
        /// <summary>
        /// Get the status and results of an LLMs.txt generation job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GetLLMsTxtStatusResponse> GetLLMsTxtStatusAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}