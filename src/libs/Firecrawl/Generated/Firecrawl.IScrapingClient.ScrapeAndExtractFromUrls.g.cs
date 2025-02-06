#nullable enable

namespace Firecrawl
{
    public partial interface IScrapingClient
    {
        /// <summary>
        /// Scrape multiple URLs and optionally extract information using an LLM
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.BatchScrapeResponseObj> ScrapeAndExtractFromUrlsAsync(
            global::Firecrawl.ScrapeAndExtractFromUrlsRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Scrape multiple URLs and optionally extract information using an LLM
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="webhook"></param>
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
        /// <param name="ignoreInvalidURLs">
        /// If invalid URLs are specified in the urls array, they will be ignored. Instead of them failing the entire request, a batch scrape using the remaining valid URLs will be created, and the invalid URLs will be returned in the invalidURLs field of the response.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.BatchScrapeResponseObj> ScrapeAndExtractFromUrlsAsync(
            global::System.Collections.Generic.IList<string>? urls = default,
            global::Firecrawl.OneOf<string, global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhook>? webhook = default,
            global::System.Collections.Generic.IList<global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat>? formats = default,
            bool? onlyMainContent = default,
            global::System.Collections.Generic.IList<string>? includeTags = default,
            global::System.Collections.Generic.IList<string>? excludeTags = default,
            object? headers = default,
            int? waitFor = default,
            bool? mobile = default,
            bool? skipTlsVerification = default,
            int? timeout = default,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestExtract? extract = default,
            global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant1, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant2, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant3, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant4, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant5, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant7, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8>>? actions = default,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestLocation? location = default,
            bool? removeBase64Images = default,
            bool? ignoreInvalidURLs = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}