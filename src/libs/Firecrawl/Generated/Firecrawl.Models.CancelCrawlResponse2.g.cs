
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CancelCrawlResponse2
    {
        /// <summary>
        /// Example: Crawl job not found.
        /// </summary>
        /// <example>Crawl job not found.</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelCrawlResponse2" /> class.
        /// </summary>
        /// <param name="error">
        /// Example: Crawl job not found.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CancelCrawlResponse2(
            string? error)
        {
            this.Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelCrawlResponse2" /> class.
        /// </summary>
        public CancelCrawlResponse2()
        {
        }
    }
}