#nullable enable

namespace Firecrawl
{
    public partial interface ILLMsTxtClient
    {
        /// <summary>
        /// Generate LLMs.txt for a website
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GenerateLLMsTxtResponse> GenerateLLMsTxtAsync(
            global::Firecrawl.GenerateLLMsTxtRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Generate LLMs.txt for a website
        /// </summary>
        /// <param name="url">
        /// The URL to generate LLMs.txt from
        /// </param>
        /// <param name="maxUrls">
        /// Maximum number of URLs to analyze<br/>
        /// Default Value: 2
        /// </param>
        /// <param name="showFullText">
        /// Include full text content in the response<br/>
        /// Default Value: false
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.GenerateLLMsTxtResponse> GenerateLLMsTxtAsync(
            string url,
            int? maxUrls = default,
            bool? showFullText = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}