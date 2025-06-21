
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CancelBatchScrapeResponse
    {
        /// <summary>
        /// Example: true
        /// </summary>
        /// <example>true</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Example: Batch scrape job successfully cancelled.
        /// </summary>
        /// <example>Batch scrape job successfully cancelled.</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelBatchScrapeResponse" /> class.
        /// </summary>
        /// <param name="success">
        /// Example: true
        /// </param>
        /// <param name="message">
        /// Example: Batch scrape job successfully cancelled.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CancelBatchScrapeResponse(
            bool? success,
            string? message)
        {
            this.Success = success;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelBatchScrapeResponse" /> class.
        /// </summary>
        public CancelBatchScrapeResponse()
        {
        }
    }
}