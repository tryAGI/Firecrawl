#nullable enable

namespace Firecrawl
{
    public partial interface IScrapingClient
    {
        /// <summary>
        /// Scrape a single URL
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAsync(
            global::Firecrawl.ScrapeRequest request,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Scrape a single URL
        /// </summary>
        /// <param name="url">
        /// The URL to scrape
        /// </param>
        /// <param name="formats">
        /// Specific formats to return.<br/>
        ///  - markdown: The page in Markdown format.<br/>
        ///  - html: The page's HTML, trimmed to include only meaningful content.<br/>
        ///  - rawHtml: The page's original HTML.<br/>
        ///  - links: The links on the page.<br/>
        ///  - screenshot: A screenshot of the top of the page.<br/>
        ///  - screenshot@fullPage: A screenshot of the full page. (overridden by screenshot if present)<br/>
        /// Default Value: [markdown]
        /// </param>
        /// <param name="headers">
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </param>
        /// <param name="includeTags">
        /// Only include tags, classes and ids from the page in the final output. Use comma separated values. Example: 'script, .ad, #footer'
        /// </param>
        /// <param name="excludeTags">
        /// Tags, classes and ids to remove from the page. Use comma separated values. Example: 'script, .ad, #footer'
        /// </param>
        /// <param name="onlyMainContent">
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="timeout">
        /// Timeout in milliseconds for the request<br/>
        /// Default Value: 30000
        /// </param>
        /// <param name="waitFor">
        /// Wait x amount of milliseconds for the page to load to fetch content<br/>
        /// Default Value: 0
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAsync(
            string url,
            global::System.Collections.Generic.IList<global::Firecrawl.ScrapeRequestFormat>? formats = default,
            object? headers = default,
            global::System.Collections.Generic.IList<string>? includeTags = default,
            global::System.Collections.Generic.IList<string>? excludeTags = default,
            bool? onlyMainContent = true,
            int? timeout = 30000,
            int? waitFor = 0,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}