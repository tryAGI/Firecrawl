#nullable enable

namespace Firecrawl
{
    public partial interface IExtractionClient
    {
        /// <summary>
        /// Extract structured data from pages using LLMs
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ExtractResponse> ExtractDataAsync(
            global::Firecrawl.ExtractDataRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Extract structured data from pages using LLMs
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="prompt">
        /// Prompt to guide the extraction process
        /// </param>
        /// <param name="schema">
        /// Schema to define the structure of the extracted data
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ExtractResponse> ExtractDataAsync(
            global::System.Collections.Generic.IList<string> urls,
            string prompt,
            global::Firecrawl.ExtractDataRequestSchema? schema = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}