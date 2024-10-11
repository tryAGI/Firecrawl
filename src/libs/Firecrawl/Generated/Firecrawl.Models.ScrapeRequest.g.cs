
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
        public bool? OnlyMainContent { get; set; } = true;

        /// <summary>
        /// Timeout in milliseconds for the request<br/>
        /// Default Value: 30000
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("timeout")]
        public int? Timeout { get; set; } = 30000;

        /// <summary>
        /// Wait x amount of milliseconds for the page to load to fetch content<br/>
        /// Default Value: 0
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("waitFor")]
        public int? WaitFor { get; set; } = 0;

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}