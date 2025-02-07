
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlsRequestActionVariant2
    {
        /// <summary>
        /// Take a screenshot
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant2TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant2Type Type { get; set; }

        /// <summary>
        /// Should the screenshot be full-page or viewport sized?<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("fullPage")]
        public bool? FullPage { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant2" /> class.
        /// </summary>
        /// <param name="type">
        /// Take a screenshot
        /// </param>
        /// <param name="fullPage">
        /// Should the screenshot be full-page or viewport sized?<br/>
        /// Default Value: false
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeAndExtractFromUrlsRequestActionVariant2(
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant2Type type,
            bool? fullPage)
        {
            this.Type = type;
            this.FullPage = fullPage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant2" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlsRequestActionVariant2()
        {
        }
    }
}