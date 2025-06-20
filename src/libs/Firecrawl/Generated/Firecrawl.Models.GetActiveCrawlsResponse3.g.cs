
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GetActiveCrawlsResponse3
    {
        /// <summary>
        /// Example: false
        /// </summary>
        /// <example>false</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Example: Request rate limit exceeded. Please wait and try again later.
        /// </summary>
        /// <example>Request rate limit exceeded. Please wait and try again later.</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GetActiveCrawlsResponse3" /> class.
        /// </summary>
        /// <param name="success">
        /// Example: false
        /// </param>
        /// <param name="error">
        /// Example: Request rate limit exceeded. Please wait and try again later.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public GetActiveCrawlsResponse3(
            bool? success,
            string? error)
        {
            this.Success = success;
            this.Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetActiveCrawlsResponse3" /> class.
        /// </summary>
        public GetActiveCrawlsResponse3()
        {
        }
    }
}