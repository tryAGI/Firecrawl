#nullable enable

namespace Firecrawl
{
    public partial interface IExtractionClient
    {
        /// <summary>
        /// Get the status of an extract job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ExtractStatusResponse> GetExtractStatusAsync(
            string id,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}