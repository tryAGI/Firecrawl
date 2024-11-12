
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class SearchGoogleRequestPageOptions
    {
        /// <summary>
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("onlyMainContent")]
        public bool? OnlyMainContent { get; set; }

        /// <summary>
        /// Fetch the content of each page. If false, defaults to a basic fast serp API.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("fetchPageContent")]
        public bool? FetchPageContent { get; set; }

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
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchGoogleRequestPageOptions" /> class.
        /// </summary>
        /// <param name="onlyMainContent">
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="fetchPageContent">
        /// Fetch the content of each page. If false, defaults to a basic fast serp API.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="includeHtml">
        /// Include the HTML version of the content on page. Will output a html key in the response.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="includeRawHtml">
        /// Include the raw HTML content of the page. Will output a rawHtml key in the response.<br/>
        /// Default Value: false
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public SearchGoogleRequestPageOptions(
            bool? onlyMainContent,
            bool? fetchPageContent,
            bool? includeHtml,
            bool? includeRawHtml)
        {
            this.OnlyMainContent = onlyMainContent;
            this.FetchPageContent = fetchPageContent;
            this.IncludeHtml = includeHtml;
            this.IncludeRawHtml = includeRawHtml;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchGoogleRequestPageOptions" /> class.
        /// </summary>
        public SearchGoogleRequestPageOptions()
        {
        }
    }
}