
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Options for scraping search results
    /// </summary>
    public sealed partial class SearchAndScrapeRequestScrapeOptions
    {
        /// <summary>
        /// Formats to include in the output
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("formats")]
        public global::System.Collections.Generic.IList<global::Firecrawl.SearchAndScrapeRequestScrapeOptionsFormat>? Formats { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAndScrapeRequestScrapeOptions" /> class.
        /// </summary>
        /// <param name="formats">
        /// Formats to include in the output
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SearchAndScrapeRequestScrapeOptions(
            global::System.Collections.Generic.IList<global::Firecrawl.SearchAndScrapeRequestScrapeOptionsFormat>? formats)
        {
            this.Formats = formats;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAndScrapeRequestScrapeOptions" /> class.
        /// </summary>
        public SearchAndScrapeRequestScrapeOptions()
        {
        }
    }
}