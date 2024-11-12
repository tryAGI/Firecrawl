
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("jobId")]
        public string? JobId { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlResponse" /> class.
        /// </summary>
        /// <param name="jobId"></param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CrawlResponse(
            string? jobId)
        {
            this.JobId = jobId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlResponse" /> class.
        /// </summary>
        public CrawlResponse()
        {
        }
    }
}