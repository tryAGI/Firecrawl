
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class BatchScrapeStatusResponseObjDataItemMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("sourceURL")]
        public string? SourceURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("<any other metadata> ")]
        public string? x_any_other_metadata__ { get; set; }

        /// <summary>
        /// The status code of the page
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("statusCode")]
        public int? StatusCode { get; set; }

        /// <summary>
        /// The error message of the page
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchScrapeStatusResponseObjDataItemMetadata" /> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="sourceURL"></param>
        /// <param name="x_any_other_metadata__"></param>
        /// <param name="statusCode">
        /// The status code of the page
        /// </param>
        /// <param name="error">
        /// The error message of the page
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public BatchScrapeStatusResponseObjDataItemMetadata(
            string? title,
            string? description,
            string? language,
            string? sourceURL,
            string? x_any_other_metadata__,
            int? statusCode,
            string? error)
        {
            this.Title = title;
            this.Description = description;
            this.Language = language;
            this.SourceURL = sourceURL;
            this.x_any_other_metadata__ = x_any_other_metadata__;
            this.StatusCode = statusCode;
            this.Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchScrapeStatusResponseObjDataItemMetadata" /> class.
        /// </summary>
        public BatchScrapeStatusResponseObjDataItemMetadata()
        {
        }
    }
}