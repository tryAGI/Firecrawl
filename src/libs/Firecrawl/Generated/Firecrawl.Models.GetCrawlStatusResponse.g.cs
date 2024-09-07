
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GetCrawlStatusResponse
    {
        /// <summary>
        /// Status of the job (completed, active, failed, paused)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Current page number
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("current")]
        public int Current { get; set; }

        /// <summary>
        /// Total number of pages
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// Data returned from the job (null when it is in progress)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("data")]
        public global::System.Collections.Generic.IList<global::Firecrawl.CrawlStatusResponseObj>? Data { get; set; }

        /// <summary>
        /// Partial documents returned as it is being crawled (streaming). **This feature is currently in alpha - expect breaking changes** When a page is ready, it will append to the partial_data array, so there is no need to wait for the entire website to be crawled. When the crawl is done, partial_data will become empty and the result will be available in `data`. There is a max of 50 items in the array response. The oldest item (top of the array) will be removed when the new item is added to the array.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("partial_data")]
        public global::System.Collections.Generic.IList<global::Firecrawl.CrawlStatusResponseObj>? PartialData { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}