
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Extract object
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlRequestExtract
    {
        /// <summary>
        /// The schema to use for the extraction (Optional)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("schema")]
        public object? Schema { get; set; }

        /// <summary>
        /// The system prompt to use for the extraction (Optional)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("systemPrompt")]
        public string? SystemPrompt { get; set; }

        /// <summary>
        /// The prompt to use for the extraction without a schema (Optional)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestExtract" /> class.
        /// </summary>
        /// <param name="schema">
        /// The schema to use for the extraction (Optional)
        /// </param>
        /// <param name="systemPrompt">
        /// The system prompt to use for the extraction (Optional)
        /// </param>
        /// <param name="prompt">
        /// The prompt to use for the extraction without a schema (Optional)
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeAndExtractFromUrlRequestExtract(
            object? schema,
            string? systemPrompt,
            string? prompt)
        {
            this.Schema = schema;
            this.SystemPrompt = systemPrompt;
            this.Prompt = prompt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlRequestExtract" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlRequestExtract()
        {
        }
    }
}