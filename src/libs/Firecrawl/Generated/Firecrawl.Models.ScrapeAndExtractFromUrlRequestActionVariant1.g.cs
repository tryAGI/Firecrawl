
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlRequestActionVariant1
    {
        /// <summary>
        /// Wait for a specified amount of milliseconds
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant1TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant1Type Type { get; set; }

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
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestActionVariant1" /> class.
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
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeAndExtractFromUrlRequestActionVariant1(
            global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant1Type type,
            int? milliseconds,
            string? selector)
        {
            this.Type = type;
            this.Milliseconds = milliseconds;
            this.Selector = selector;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestActionVariant1" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlRequestActionVariant1()
        {
        }
    }
}