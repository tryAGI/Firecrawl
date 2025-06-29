
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeOptionsActionVariant4
    {
        /// <summary>
        /// Write text into an input field, text area, or contenteditable element. Note: You must first focus the element using a 'click' action before writing. The text will be typed character by character to simulate keyboard input.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant4TypeJsonConverter))]
        public global::Firecrawl.ScrapeOptionsActionVariant4Type Type { get; set; }

        /// <summary>
        /// Text to type<br/>
        /// Example: Hello, world!
        /// </summary>
        /// <example>Hello, world!</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("text")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Text { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeOptionsActionVariant4" /> class.
        /// </summary>
        /// <param name="type">
        /// Write text into an input field, text area, or contenteditable element. Note: You must first focus the element using a 'click' action before writing. The text will be typed character by character to simulate keyboard input.
        /// </param>
        /// <param name="text">
        /// Text to type<br/>
        /// Example: Hello, world!
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeOptionsActionVariant4(
            string text,
            global::Firecrawl.ScrapeOptionsActionVariant4Type type)
        {
            this.Text = text ?? throw new global::System.ArgumentNullException(nameof(text));
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeOptionsActionVariant4" /> class.
        /// </summary>
        public ScrapeOptionsActionVariant4()
        {
        }
    }
}