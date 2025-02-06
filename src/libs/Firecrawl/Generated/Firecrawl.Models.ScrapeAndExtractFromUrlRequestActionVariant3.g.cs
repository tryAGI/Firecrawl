
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlRequestActionVariant3
    {
        /// <summary>
        /// Click on an element
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant3TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3Type Type { get; set; }

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
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestActionVariant3" /> class.
        /// </summary>
        /// <param name="type">
        /// Click on an element
        /// </param>
        /// <param name="selector">
        /// Query selector to find the element by<br/>
        /// Example: #load-more-button
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeAndExtractFromUrlRequestActionVariant3(
            string selector,
            global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3Type type)
        {
            this.Selector = selector ?? throw new global::System.ArgumentNullException(nameof(selector));
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestActionVariant3" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlRequestActionVariant3()
        {
        }
    }
}