
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// The schema to use for the extraction (Optional). Must conform to [JSON Schema](https://json-schema.org/).
    /// </summary>
    public sealed partial class ScrapeOptionsJsonOptionsSchema
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}