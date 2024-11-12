
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GetCrawlStatusResponse4
    {
        /// <summary>
        /// Example: An unexpected error occurred on the server.
        /// </summary>
        /// <example>An unexpected error occurred on the server.</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCrawlStatusResponse4" /> class.
        /// </summary>
        /// <param name="error">
        /// Example: An unexpected error occurred on the server.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public GetCrawlStatusResponse4(
            string? error)
        {
            this.Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCrawlStatusResponse4" /> class.
        /// </summary>
        public GetCrawlStatusResponse4()
        {
        }
    }
}