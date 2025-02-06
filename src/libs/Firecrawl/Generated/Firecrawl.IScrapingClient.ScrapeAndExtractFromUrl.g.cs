#nullable enable

namespace Firecrawl
{
    public partial interface IScrapingClient
    {
        /// <summary>
        /// Scrape a single URL and optionally extract information using an LLM
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAndExtractFromUrlAsync(
            global::Firecrawl.ScrapeAndExtractFromUrlRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Scrape a single URL and optionally extract information using an LLM
        /// </summary>
        /// <param name="url">
        /// The URL to scrape
        /// </param>
        /// <param name="formats">
        /// Formats to include in the output.<br/>
        /// Default Value: [markdown]
        /// </param>
        /// <param name="onlyMainContent">
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="includeTags">
        /// Tags to include in the output.
        /// </param>
        /// <param name="excludeTags">
        /// Tags to exclude from the output.
        /// </param>
        /// <param name="headers">
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </param>
        /// <param name="waitFor">
        /// Specify a delay in milliseconds before fetching the content, allowing the page sufficient time to load.<br/>
        /// Default Value: 0
        /// </param>
        /// <param name="mobile">
        /// Set to true if you want to emulate scraping from a mobile device. Useful for testing responsive pages and taking mobile screenshots.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="skipTlsVerification">
        /// Skip TLS certificate verification when making requests<br/>
        /// Default Value: false
        /// </param>
        /// <param name="timeout">
        /// Timeout in milliseconds for the request<br/>
        /// Default Value: 30000
        /// </param>
        /// <param name="extract">
        /// Extract object
        /// </param>
        /// <param name="actions">
        /// Actions to perform on the page before grabbing the content
        /// </param>
        /// <param name="location">
        /// Location settings for the request. When specified, this will use an appropriate proxy if available and emulate the corresponding language and timezone settings. Defaults to 'US' if not specified.
        /// </param>
        /// <param name="removeBase64Images">
        /// Removes all base 64 images from the output, which may be overwhelmingly long. The image's alt text remains in the output, but the URL is replaced with a placeholder.
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAndExtractFromUrlAsync(
            string url,
            global::System.Collections.Generic.IList<global::Firecrawl.ScrapeAndExtractFromUrlRequestFormat>? formats = default,
            bool? onlyMainContent = default,
            global::System.Collections.Generic.IList<string>? includeTags = default,
            global::System.Collections.Generic.IList<string>? excludeTags = default,
            object? headers = default,
            int? waitFor = default,
            bool? mobile = default,
            bool? skipTlsVerification = default,
            int? timeout = default,
            global::Firecrawl.ScrapeAndExtractFromUrlRequestExtract? extract = default,
            global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant1, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant2, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant4, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant5, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant6, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant7, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant8>>? actions = default,
            global::Firecrawl.ScrapeAndExtractFromUrlRequestLocation? location = default,
            bool? removeBase64Images = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}