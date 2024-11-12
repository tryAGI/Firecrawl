
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlUrlsRequestCrawlerOptions
    {
        /// <summary>
        /// URL patterns to include
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includes")]
        public global::System.Collections.Generic.IList<string>? Includes { get; set; }

        /// <summary>
        /// URL patterns to exclude
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("excludes")]
        public global::System.Collections.Generic.IList<string>? Excludes { get; set; }

        /// <summary>
        /// Generate alt text for images using LLMs (must have a paid plan)<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("generateImgAltText")]
        public bool? GenerateImgAltText { get; set; }

        /// <summary>
        /// If true, returns only the URLs as a list on the crawl status. Attention: the return response will be a list of URLs inside the data, not a list of documents.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("returnOnlyUrls")]
        public bool? ReturnOnlyUrls { get; set; }

        /// <summary>
        /// Maximum depth to crawl relative to the entered URL. A maxDepth of 0 scrapes only the entered URL. A maxDepth of 1 scrapes the entered URL and all pages one level deep. A maxDepth of 2 scrapes the entered URL and all pages up to two levels deep. Higher values follow the same pattern.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("maxDepth")]
        public int? MaxDepth { get; set; }

        /// <summary>
        /// The crawling mode to use. Fast mode crawls 4x faster websites without sitemap, but may not be as accurate and shouldn't be used in heavy js-rendered websites.<br/>
        /// Default Value: default
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("mode")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestCrawlerOptionsModeJsonConverter))]
        public global::Firecrawl.CrawlUrlsRequestCrawlerOptionsMode? Mode { get; set; }

        /// <summary>
        /// Ignore the website sitemap when crawling<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("ignoreSitemap")]
        public bool? IgnoreSitemap { get; set; }

        /// <summary>
        /// Maximum number of pages to crawl<br/>
        /// Default Value: 10000
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Enables the crawler to navigate from a specific URL to previously linked pages. For instance, from 'example.com/product/123' back to 'example.com/product'<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allowBackwardCrawling")]
        public bool? AllowBackwardCrawling { get; set; }

        /// <summary>
        /// Allows the crawler to follow links to external websites.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allowExternalContentLinks")]
        public bool? AllowExternalContentLinks { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequestCrawlerOptions" /> class.
        /// </summary>
        /// <param name="includes">
        /// URL patterns to include
        /// </param>
        /// <param name="excludes">
        /// URL patterns to exclude
        /// </param>
        /// <param name="generateImgAltText">
        /// Generate alt text for images using LLMs (must have a paid plan)<br/>
        /// Default Value: false
        /// </param>
        /// <param name="returnOnlyUrls">
        /// If true, returns only the URLs as a list on the crawl status. Attention: the return response will be a list of URLs inside the data, not a list of documents.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="maxDepth">
        /// Maximum depth to crawl relative to the entered URL. A maxDepth of 0 scrapes only the entered URL. A maxDepth of 1 scrapes the entered URL and all pages one level deep. A maxDepth of 2 scrapes the entered URL and all pages up to two levels deep. Higher values follow the same pattern.
        /// </param>
        /// <param name="mode">
        /// The crawling mode to use. Fast mode crawls 4x faster websites without sitemap, but may not be as accurate and shouldn't be used in heavy js-rendered websites.<br/>
        /// Default Value: default
        /// </param>
        /// <param name="ignoreSitemap">
        /// Ignore the website sitemap when crawling<br/>
        /// Default Value: false
        /// </param>
        /// <param name="limit">
        /// Maximum number of pages to crawl<br/>
        /// Default Value: 10000
        /// </param>
        /// <param name="allowBackwardCrawling">
        /// Enables the crawler to navigate from a specific URL to previously linked pages. For instance, from 'example.com/product/123' back to 'example.com/product'<br/>
        /// Default Value: false
        /// </param>
        /// <param name="allowExternalContentLinks">
        /// Allows the crawler to follow links to external websites.<br/>
        /// Default Value: false
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CrawlUrlsRequestCrawlerOptions(
            global::System.Collections.Generic.IList<string>? includes,
            global::System.Collections.Generic.IList<string>? excludes,
            bool? generateImgAltText,
            bool? returnOnlyUrls,
            int? maxDepth,
            global::Firecrawl.CrawlUrlsRequestCrawlerOptionsMode? mode,
            bool? ignoreSitemap,
            int? limit,
            bool? allowBackwardCrawling,
            bool? allowExternalContentLinks)
        {
            this.Includes = includes;
            this.Excludes = excludes;
            this.GenerateImgAltText = generateImgAltText;
            this.ReturnOnlyUrls = returnOnlyUrls;
            this.MaxDepth = maxDepth;
            this.Mode = mode;
            this.IgnoreSitemap = ignoreSitemap;
            this.Limit = limit;
            this.AllowBackwardCrawling = allowBackwardCrawling;
            this.AllowExternalContentLinks = allowExternalContentLinks;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequestCrawlerOptions" /> class.
        /// </summary>
        public CrawlUrlsRequestCrawlerOptions()
        {
        }
    }
}