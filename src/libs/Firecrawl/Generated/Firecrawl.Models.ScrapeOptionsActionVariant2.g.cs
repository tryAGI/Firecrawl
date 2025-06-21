
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeOptionsActionVariant2
    {
        /// <summary>
        /// Take a screenshot. The links will be in the response's `actions.screenshots` array.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant2TypeJsonConverter))]
        public global::Firecrawl.ScrapeOptionsActionVariant2Type Type { get; set; }

        /// <summary>
        /// Should the screenshot be full-page or viewport sized?<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("fullPage")]
        public bool? FullPage { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeOptionsActionVariant2" /> class.
        /// </summary>
        /// <param name="type">
        /// Take a screenshot. The links will be in the response's `actions.screenshots` array.
        /// </param>
        /// <param name="fullPage">
        /// Should the screenshot be full-page or viewport sized?<br/>
        /// Default Value: false
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeOptionsActionVariant2(
            global::Firecrawl.ScrapeOptionsActionVariant2Type type,
            bool? fullPage)
        {
            this.Type = type;
            this.FullPage = fullPage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeOptionsActionVariant2" /> class.
        /// </summary>
        public ScrapeOptionsActionVariant2()
        {
        }
    }
}