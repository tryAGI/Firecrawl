
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeResponseDataActionsScrape
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("html")]
        public string? Html { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponseDataActionsScrape" /> class.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="html"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeResponseDataActionsScrape(
            string? url,
            string? html)
        {
            this.Url = url;
            this.Html = html;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponseDataActionsScrape" /> class.
        /// </summary>
        public ScrapeResponseDataActionsScrape()
        {
        }
    }
}