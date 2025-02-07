
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlRequestActionVariant7
    {
        /// <summary>
        /// Scrape the current page content, returns the url and the html.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant7TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant7Type Type { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestActionVariant7" /> class.
        /// </summary>
        /// <param name="type">
        /// Scrape the current page content, returns the url and the html.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeAndExtractFromUrlRequestActionVariant7(
            global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant7Type type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestActionVariant7" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlRequestActionVariant7()
        {
        }
    }
}