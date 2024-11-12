
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
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("crawlerOptions")]
        public global::Firecrawl.CrawlUrlsRequestCrawlerOptions? CrawlerOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("pageOptions")]
        public global::Firecrawl.CrawlUrlsRequestPageOptions? PageOptions { get; set; }

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
        /// <param name="crawlerOptions"></param>
        /// <param name="pageOptions"></param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CrawlUrlsRequest(
            string url,
            global::Firecrawl.CrawlUrlsRequestCrawlerOptions? crawlerOptions,
            global::Firecrawl.CrawlUrlsRequestPageOptions? pageOptions)
        {
            this.Url = url ?? throw new global::System.ArgumentNullException(nameof(url));
            this.CrawlerOptions = crawlerOptions;
            this.PageOptions = pageOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequest" /> class.
        /// </summary>
        public CrawlUrlsRequest()
        {
        }
    }
}