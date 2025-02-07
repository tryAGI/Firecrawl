
#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlUrlsRequest
    {
        /// <summary>
        /// The base URL to start crawling from
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("url")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Url { get; set; }

        /// <summary>
        /// Specifies URL patterns to exclude from the crawl by comparing website paths against the provided regex patterns. For example, if you set "excludePaths": ["blog/*"] for the base URL firecrawl.dev, any results matching that pattern will be excluded, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("excludePaths")]
        public global::System.Collections.Generic.IList<string>? ExcludePaths { get; set; }

        /// <summary>
        /// Specifies URL patterns to include in the crawl by comparing website paths against the provided regex patterns. Only the paths that match the specified patterns will be included in the response. For example, if you set "includePaths": ["blog/*"] for the base URL firecrawl.dev, only results matching that pattern will be included, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includePaths")]
        public global::System.Collections.Generic.IList<string>? IncludePaths { get; set; }

        /// <summary>
        /// Maximum depth to crawl relative to the entered URL.<br/>
        /// Default Value: 2
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("maxDepth")]
        public int? MaxDepth { get; set; }

        /// <summary>
        /// Ignore the website sitemap when crawling<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("ignoreSitemap")]
        public bool? IgnoreSitemap { get; set; }

        /// <summary>
        /// Maximum number of pages to crawl. Default limit is 10000.<br/>
        /// Default Value: 10000
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Enables the crawler to navigate from a specific URL to previously linked pages.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allowBackwardLinks")]
        public bool? AllowBackwardLinks { get; set; }

        /// <summary>
        /// Allows the crawler to follow links to external websites.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allowExternalLinks")]
        public bool? AllowExternalLinks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("webhook")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::Firecrawl.CrawlUrlsRequestWebhook>))]
        public global::Firecrawl.OneOf<string, global::Firecrawl.CrawlUrlsRequestWebhook>? Webhook { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("scrapeOptions")]
        public global::Firecrawl.CrawlUrlsRequestScrapeOptions? ScrapeOptions { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequest" /> class.
        /// </summary>
        /// <param name="url">
        /// The base URL to start crawling from
        /// </param>
        /// <param name="excludePaths">
        /// Specifies URL patterns to exclude from the crawl by comparing website paths against the provided regex patterns. For example, if you set "excludePaths": ["blog/*"] for the base URL firecrawl.dev, any results matching that pattern will be excluded, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </param>
        /// <param name="includePaths">
        /// Specifies URL patterns to include in the crawl by comparing website paths against the provided regex patterns. Only the paths that match the specified patterns will be included in the response. For example, if you set "includePaths": ["blog/*"] for the base URL firecrawl.dev, only results matching that pattern will be included, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </param>
        /// <param name="maxDepth">
        /// Maximum depth to crawl relative to the entered URL.<br/>
        /// Default Value: 2
        /// </param>
        /// <param name="ignoreSitemap">
        /// Ignore the website sitemap when crawling<br/>
        /// Default Value: false
        /// </param>
        /// <param name="limit">
        /// Maximum number of pages to crawl. Default limit is 10000.<br/>
        /// Default Value: 10000
        /// </param>
        /// <param name="allowBackwardLinks">
        /// Enables the crawler to navigate from a specific URL to previously linked pages.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="allowExternalLinks">
        /// Allows the crawler to follow links to external websites.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="webhook"></param>
        /// <param name="scrapeOptions"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CrawlUrlsRequest(
            string url,
            global::System.Collections.Generic.IList<string>? excludePaths,
            global::System.Collections.Generic.IList<string>? includePaths,
            int? maxDepth,
            bool? ignoreSitemap,
            int? limit,
            bool? allowBackwardLinks,
            bool? allowExternalLinks,
            global::Firecrawl.OneOf<string, global::Firecrawl.CrawlUrlsRequestWebhook>? webhook,
            global::Firecrawl.CrawlUrlsRequestScrapeOptions? scrapeOptions)
        {
            this.Url = url ?? throw new global::System.ArgumentNullException(nameof(url));
            this.ExcludePaths = excludePaths;
            this.IncludePaths = includePaths;
            this.MaxDepth = maxDepth;
            this.IgnoreSitemap = ignoreSitemap;
            this.Limit = limit;
            this.AllowBackwardLinks = allowBackwardLinks;
            this.AllowExternalLinks = allowExternalLinks;
            this.Webhook = webhook;
            this.ScrapeOptions = scrapeOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequest" /> class.
        /// </summary>
        public CrawlUrlsRequest()
        {
        }
    }
}