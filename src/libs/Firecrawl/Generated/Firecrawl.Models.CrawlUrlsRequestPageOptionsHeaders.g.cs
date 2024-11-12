
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
    /// </summary>
    public sealed partial class CrawlUrlsRequestPageOptionsHeaders
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlUrlsRequestPageOptionsHeaders" /> class.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CrawlUrlsRequestPageOptionsHeaders(
 )
        {
        }
    }
}