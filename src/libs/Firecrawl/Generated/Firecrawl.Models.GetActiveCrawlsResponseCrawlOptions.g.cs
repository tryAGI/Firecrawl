
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// The crawler options used for this crawl
    /// </summary>
    public sealed partial class GetActiveCrawlsResponseCrawlOptions
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("scrapeOptions")]
        public global::Firecrawl.ScrapeOptions? ScrapeOptions { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GetActiveCrawlsResponseCrawlOptions" /> class.
        /// </summary>
        /// <param name="scrapeOptions"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public GetActiveCrawlsResponseCrawlOptions(
            global::Firecrawl.ScrapeOptions? scrapeOptions)
        {
            this.ScrapeOptions = scrapeOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetActiveCrawlsResponseCrawlOptions" /> class.
        /// </summary>
        public GetActiveCrawlsResponseCrawlOptions()
        {
        }
    }
}