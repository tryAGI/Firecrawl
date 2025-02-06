
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ExtractDataRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("urls")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<string> Urls { get; set; }

        /// <summary>
        /// Prompt to guide the extraction process
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Prompt { get; set; }

        /// <summary>
        /// Schema to define the structure of the extracted data
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("schema")]
        public global::Firecrawl.ExtractDataRequestSchema? Schema { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractDataRequest" /> class.
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="prompt">
        /// Prompt to guide the extraction process
        /// </param>
        /// <param name="schema">
        /// Schema to define the structure of the extracted data
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ExtractDataRequest(
            global::System.Collections.Generic.IList<string> urls,
            string prompt,
            global::Firecrawl.ExtractDataRequestSchema? schema)
        {
            this.Urls = urls ?? throw new global::System.ArgumentNullException(nameof(urls));
            this.Prompt = prompt ?? throw new global::System.ArgumentNullException(nameof(prompt));
            this.Schema = schema;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractDataRequest" /> class.
        /// </summary>
        public ExtractDataRequest()
        {
        }
    }
}