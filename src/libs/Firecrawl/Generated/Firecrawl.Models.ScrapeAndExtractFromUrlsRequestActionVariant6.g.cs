
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlsRequestActionVariant6
    {
        /// <summary>
        /// Scroll the page or a specific element
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant6TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Type Type { get; set; }

        /// <summary>
        /// Direction to scroll<br/>
        /// Default Value: down
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("direction")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant6DirectionJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Direction? Direction { get; set; }

        /// <summary>
        /// Query selector for the element to scroll<br/>
        /// Example: #my-element
        /// </summary>
        /// <example>#my-element</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("selector")]
        public string? Selector { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant6" /> class.
        /// </summary>
        /// <param name="type">
        /// Scroll the page or a specific element
        /// </param>
        /// <param name="direction">
        /// Direction to scroll<br/>
        /// Default Value: down
        /// </param>
        /// <param name="selector">
        /// Query selector for the element to scroll<br/>
        /// Example: #my-element
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeAndExtractFromUrlsRequestActionVariant6(
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Type type,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Direction? direction,
            string? selector)
        {
            this.Type = type;
            this.Direction = direction;
            this.Selector = selector;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant6" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlsRequestActionVariant6()
        {
        }
    }
}