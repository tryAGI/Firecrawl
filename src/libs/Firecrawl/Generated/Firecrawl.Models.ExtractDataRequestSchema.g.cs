
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Schema to define the structure of the extracted data
    /// </summary>
    public sealed partial class ExtractDataRequestSchema
    {
        /// <summary>
        /// Description of property1
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("property1")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Property1 { get; set; }

        /// <summary>
        /// Description of property2
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("property2")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int Property2 { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractDataRequestSchema" /> class.
        /// </summary>
        /// <param name="property1">
        /// Description of property1
        /// </param>
        /// <param name="property2">
        /// Description of property2
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ExtractDataRequestSchema(
            string property1,
            int property2)
        {
            this.Property1 = property1 ?? throw new global::System.ArgumentNullException(nameof(property1));
            this.Property2 = property2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractDataRequestSchema" /> class.
        /// </summary>
        public ExtractDataRequestSchema()
        {
        }
    }
}