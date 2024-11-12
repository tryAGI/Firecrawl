
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlUrlsRequestPageOptions
    {
        /// <summary>
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("headers")]
        public object? Headers { get; set; }

        /// <summary>
        /// Include the HTML version of the content on page. Will output a html key in the response.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includeHtml")]
        public bool? IncludeHtml { get; set; }

        /// <summary>
        /// Include the raw HTML content of the page. Will output a rawHtml key in the response.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includeRawHtml")]
        public bool? IncludeRawHtml { get; set; }

        /// <summary>
        /// Only include tags, classes and ids from the page in the final output. Use comma separated values. Example: 'script, .ad, #footer'
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("onlyIncludeTags")]
        public global::System.Collections.Generic.IList<string>? OnlyIncludeTags { get; set; }

        /// <summary>
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("onlyMainContent")]
        public bool? OnlyMainContent { get; set; }

        /// <summary>
        /// Tags, classes and ids to remove from the page. Use comma separated values. Example: 'script, .ad, #footer'
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("removeTags")]
        public global::System.Collections.Generic.IList<string>? RemoveTags { get; set; }

        /// <summary>
        /// Replace all relative paths with absolute paths for images and links<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("replaceAllPathsWithAbsolutePaths")]
        public bool? ReplaceAllPathsWithAbsolutePaths { get; set; }

        /// <summary>
        /// Include a screenshot of the top of the page that you are scraping.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("screenshot")]
        public bool? Screenshot { get; set; }

        /// <summary>
        /// Include a full page screenshot of the page that you are scraping.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("fullPageScreenshot")]
        public bool? FullPageScreenshot { get; set; }

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
        /// Initializes a new instance of the <see cref="CrawlUrlsRequestPageOptions" /> class.
        /// </summary>
        /// <param name="headers">
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </param>
        /// <param name="includeHtml">
        /// Include the HTML version of the content on page. Will output a html key in the response.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="includeRawHtml">
        /// Include the raw HTML content of the page. Will output a rawHtml key in the response.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="onlyIncludeTags">
        /// Only include tags, classes and ids from the page in the final output. Use comma separated values. Example: 'script, .ad, #footer'
        /// </param>
        /// <param name="onlyMainContent">
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="removeTags">
        /// Tags, classes and ids to remove from the page. Use comma separated values. Example: 'script, .ad, #footer'
        /// </param>
        /// <param name="replaceAllPathsWithAbsolutePaths">
        /// Replace all relative paths with absolute paths for images and links<br/>
        /// Default Value: false
        /// </param>
        /// <param name="screenshot">
        /// Include a screenshot of the top of the page that you are scraping.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="fullPageScreenshot">
        /// Include a full page screenshot of the page that you are scraping.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="waitFor">
        /// Wait x amount of milliseconds for the page to load to fetch content<br/>
        /// Default Value: 0
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CrawlUrlsRequestPageOptions(
            object? headers,
            bool? includeHtml,
            bool? includeRawHtml,
            global::System.Collections.Generic.IList<string>? onlyIncludeTags,
            bool? onlyMainContent,
            global::System.Collections.Generic.IList<string>? removeTags,
            bool? replaceAllPathsWithAbsolutePaths,
            bool? screenshot,
            bool? fullPageScreenshot,
            int? waitFor)
        {
            this.Headers = headers;
            this.IncludeHtml = includeHtml;
            this.IncludeRawHtml = includeRawHtml;
            this.OnlyIncludeTags = onlyIncludeTags;
            this.OnlyMainContent = onlyMainContent;
            this.RemoveTags = removeTags;
            this.ReplaceAllPathsWithAbsolutePaths = replaceAllPathsWithAbsolutePaths;
            this.Screenshot = screenshot;
            this.FullPageScreenshot = fullPageScreenshot;
            this.WaitFor = waitFor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequestPageOptions" /> class.
        /// </summary>
        public CrawlUrlsRequestPageOptions()
        {
        }
    }
}