
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlsRequestActionVariant3
    {
        /// <summary>
        /// Click on an element
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant3TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant3Type Type { get; set; }

        /// <summary>
        /// Query selector to find the element by<br/>
        /// Example: #load-more-button
        /// </summary>
        /// <example>#load-more-button</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("selector")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Selector { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant3" /> class.
        /// </summary>
        /// <param name="type">
        /// Click on an element
        /// </param>
        /// <param name="selector">
        /// Query selector to find the element by<br/>
        /// Example: #load-more-button
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeAndExtractFromUrlsRequestActionVariant3(
            string selector,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant3Type type)
        {
            this.Selector = selector ?? throw new global::System.ArgumentNullException(nameof(selector));
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant3" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlsRequestActionVariant3()
        {
        }
    }
}