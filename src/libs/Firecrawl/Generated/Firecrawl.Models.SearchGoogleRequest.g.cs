
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class SearchGoogleRequest
    {
        /// <summary>
        /// The query to search for
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("query")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Query { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("pageOptions")]
        public global::Firecrawl.SearchGoogleRequestPageOptions? PageOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("searchOptions")]
        public global::Firecrawl.SearchGoogleRequestSearchOptions? SearchOptions { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchGoogleRequest" /> class.
        /// </summary>
        /// <param name="query">
        /// The query to search for
        /// </param>
        /// <param name="pageOptions"></param>
        /// <param name="searchOptions"></param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public SearchGoogleRequest(
            string query,
            global::Firecrawl.SearchGoogleRequestPageOptions? pageOptions,
            global::Firecrawl.SearchGoogleRequestSearchOptions? searchOptions)
        {
            this.Query = query ?? throw new global::System.ArgumentNullException(nameof(query));
            this.PageOptions = pageOptions;
            this.SearchOptions = searchOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchGoogleRequest" /> class.
        /// </summary>
        public SearchGoogleRequest()
        {
        }
    }
}