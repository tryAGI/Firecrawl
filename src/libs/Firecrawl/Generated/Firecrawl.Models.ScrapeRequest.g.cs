
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeRequest
    {
        /// <summary>
        /// The URL to scrape
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("url")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Url { get; set; }

        /// <summary>
        /// Specific formats to return.<br/>
        ///  - markdown: The page in Markdown format.<br/>
        ///  - html: The page's HTML, trimmed to include only meaningful content.<br/>
        ///  - rawHtml: The page's original HTML.<br/>
        ///  - links: The links on the page.<br/>
        ///  - screenshot: A screenshot of the top of the page.<br/>
        ///  - screenshot@fullPage: A screenshot of the full page. (overridden by screenshot if present)<br/>
        /// Default Value: [markdown]
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("formats")]
        public global::System.Collections.Generic.IList<global::Firecrawl.ScrapeRequestFormat>? Formats { get; set; }

        /// <summary>
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("headers")]
        public object? Headers { get; set; }

        /// <summary>
        /// Only include tags, classes and ids from the page in the final output. Use comma separated values. Example: 'script, .ad, #footer'
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includeTags")]
        public global::System.Collections.Generic.IList<string>? IncludeTags { get; set; }

        /// <summary>
        /// Tags, classes and ids to remove from the page. Use comma separated values. Example: 'script, .ad, #footer'
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("excludeTags")]
        public global::System.Collections.Generic.IList<string>? ExcludeTags { get; set; }

        /// <summary>
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("onlyMainContent")]
        public bool? OnlyMainContent { get; set; }

        /// <summary>
        /// Timeout in milliseconds for the request<br/>
        /// Default Value: 30000
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("timeout")]
        public int? Timeout { get; set; }

        /// <summary>
        /// Wait x amount of milliseconds for the page to load to fetch content<br/>
        /// Default Value: 0
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("waitFor")]
        public int? WaitFor { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeRequest" /> class.
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
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeRequest(
            string url,
            global::System.Collections.Generic.IList<global::Firecrawl.ScrapeRequestFormat>? formats,
            object? headers,
            global::System.Collections.Generic.IList<string>? includeTags,
            global::System.Collections.Generic.IList<string>? excludeTags,
            bool? onlyMainContent,
            int? timeout,
            int? waitFor)
        {
            this.Url = url ?? throw new global::System.ArgumentNullException(nameof(url));
            this.Formats = formats;
            this.Headers = headers;
            this.IncludeTags = includeTags;
            this.ExcludeTags = excludeTags;
            this.OnlyMainContent = onlyMainContent;
            this.Timeout = timeout;
            this.WaitFor = waitFor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeRequest" /> class.
        /// </summary>
        public ScrapeRequest()
        {
        }
    }
}