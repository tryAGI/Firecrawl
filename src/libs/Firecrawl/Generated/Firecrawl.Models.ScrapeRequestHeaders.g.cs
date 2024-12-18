
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
    /// </summary>
    public sealed partial class ScrapeRequestHeaders
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();
    }
}