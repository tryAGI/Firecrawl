
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlsRequestActionVariant1
    {
        /// <summary>
        /// Wait for a specified amount of milliseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant1TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant1Type Type { get; set; }

        /// <summary>
        /// Number of milliseconds to wait
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("milliseconds")]
        public int? Milliseconds { get; set; }

        /// <summary>
        /// Query selector to find the element by<br/>
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
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant1" /> class.
        /// </summary>
        /// <param name="type">
        /// Wait for a specified amount of milliseconds
        /// </param>
        /// <param name="milliseconds">
        /// Number of milliseconds to wait
        /// </param>
        /// <param name="selector">
        /// Query selector to find the element by<br/>
        /// Example: #my-element
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeAndExtractFromUrlsRequestActionVariant1(
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant1Type type,
            int? milliseconds,
            string? selector)
        {
            this.Type = type;
            this.Milliseconds = milliseconds;
            this.Selector = selector;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant1" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlsRequestActionVariant1()
        {
        }
    }
}