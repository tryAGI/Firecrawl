
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Schema for JSON extraction when using 'json' mode. Defines the structure of data to extract and compare. Must conform to [JSON Schema](https://json-schema.org/).
    /// </summary>
    public sealed partial class ScrapeOptionsChangeTrackingOptionsSchema
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}