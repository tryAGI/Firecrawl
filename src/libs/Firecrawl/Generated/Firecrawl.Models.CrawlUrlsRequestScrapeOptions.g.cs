
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlUrlsRequestScrapeOptions
    {
        /// <summary>
        /// Formats to include in the output.<br/>
        /// Default Value: [markdown]
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("formats")]
        public global::System.Collections.Generic.IList<global::Firecrawl.CrawlUrlsRequestScrapeOptionsFormat>? Formats { get; set; }

        /// <summary>
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("headers")]
        public object? Headers { get; set; }

        /// <summary>
        /// Tags to include in the output.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includeTags")]
        public global::System.Collections.Generic.IList<string>? IncludeTags { get; set; }

        /// <summary>
        /// Tags to exclude from the output.
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
        /// Remove base64 encoded images from the output<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("removeBase64Images")]
        public bool? RemoveBase64Images { get; set; }

        /// <summary>
        /// Set to true if you want to emulate scraping from a mobile device. Useful for testing responsive pages and taking mobile screenshots.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("mobile")]
        public bool? Mobile { get; set; }

        /// <summary>
        /// Wait x amount of milliseconds for the page to load to fetch content<br/>
        /// Default Value: 123
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("waitFor")]
        public int? WaitFor { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequestScrapeOptions" /> class.
        /// </summary>
        /// <param name="formats">
        /// Formats to include in the output.<br/>
        /// Default Value: [markdown]
        /// </param>
        /// <param name="headers">
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </param>
        /// <param name="includeTags">
        /// Tags to include in the output.
        /// </param>
        /// <param name="excludeTags">
        /// Tags to exclude from the output.
        /// </param>
        /// <param name="onlyMainContent">
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="removeBase64Images">
        /// Remove base64 encoded images from the output<br/>
        /// Default Value: true
        /// </param>
        /// <param name="mobile">
        /// Set to true if you want to emulate scraping from a mobile device. Useful for testing responsive pages and taking mobile screenshots.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="waitFor">
        /// Wait x amount of milliseconds for the page to load to fetch content<br/>
        /// Default Value: 123
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CrawlUrlsRequestScrapeOptions(
            global::System.Collections.Generic.IList<global::Firecrawl.CrawlUrlsRequestScrapeOptionsFormat>? formats,
            object? headers,
            global::System.Collections.Generic.IList<string>? includeTags,
            global::System.Collections.Generic.IList<string>? excludeTags,
            bool? onlyMainContent,
            bool? removeBase64Images,
            bool? mobile,
            int? waitFor)
        {
            this.Formats = formats;
            this.Headers = headers;
            this.IncludeTags = includeTags;
            this.ExcludeTags = excludeTags;
            this.OnlyMainContent = onlyMainContent;
            this.RemoveBase64Images = removeBase64Images;
            this.Mobile = mobile;
            this.WaitFor = waitFor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequestScrapeOptions" /> class.
        /// </summary>
        public CrawlUrlsRequestScrapeOptions()
        {
        }
    }
}