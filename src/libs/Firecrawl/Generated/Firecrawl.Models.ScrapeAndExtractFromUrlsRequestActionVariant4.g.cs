
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlsRequestActionVariant4
    {
        /// <summary>
        /// Write text into an input field
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant4TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant4Type Type { get; set; }

        /// <summary>
        /// Text to type<br/>
        /// Example: Hello, world!
        /// </summary>
        /// <example>Hello, world!</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("text")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Text { get; set; }

        /// <summary>
        /// Query selector for the input field<br/>
        /// Example: #search-input
        /// </summary>
        /// <example>#search-input</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("selector")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Selector { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant4" /> class.
        /// </summary>
        /// <param name="type">
        /// Write text into an input field
        /// </param>
        /// <param name="text">
        /// Text to type<br/>
        /// Example: Hello, world!
        /// </param>
        /// <param name="selector">
        /// Query selector for the input field<br/>
        /// Example: #search-input
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeAndExtractFromUrlsRequestActionVariant4(
            string text,
            string selector,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant4Type type)
        {
            this.Text = text ?? throw new global::System.ArgumentNullException(nameof(text));
            this.Selector = selector ?? throw new global::System.ArgumentNullException(nameof(selector));
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant4" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlsRequestActionVariant4()
        {
        }
    }
}