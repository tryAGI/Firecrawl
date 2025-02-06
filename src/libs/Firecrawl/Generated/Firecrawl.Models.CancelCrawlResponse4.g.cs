
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CancelCrawlResponse4
    {
        /// <summary>
        /// Example: cancelled
        /// </summary>
        /// <example>cancelled</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.CancelCrawlResponseStatus2JsonConverter))]
        public global::Firecrawl.CancelCrawlResponseStatus2? Status { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelCrawlResponse4" /> class.
        /// </summary>
        /// <param name="status">
        /// Example: cancelled
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CancelCrawlResponse4(
            global::Firecrawl.CancelCrawlResponseStatus2? status)
        {
            this.Status = status;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelCrawlResponse4" /> class.
        /// </summary>
        public CancelCrawlResponse4()
        {
        }
    }
}