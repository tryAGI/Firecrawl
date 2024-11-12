
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class SearchGoogleRequestSearchOptions
    {
        /// <summary>
        /// Maximum number of results. Max is 20 during beta.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchGoogleRequestSearchOptions" /> class.
        /// </summary>
        /// <param name="limit">
        /// Maximum number of results. Max is 20 during beta.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public SearchGoogleRequestSearchOptions(
            int? limit)
        {
            this.Limit = limit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchGoogleRequestSearchOptions" /> class.
        /// </summary>
        public SearchGoogleRequestSearchOptions()
        {
        }
    }
}