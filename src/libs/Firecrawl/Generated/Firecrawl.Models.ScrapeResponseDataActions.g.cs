
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Results of the actions specified in the `actions` parameter. Only present if the `actions` parameter was provided in the request
    /// </summary>
    public sealed partial class ScrapeResponseDataActions
    {
        /// <summary>
        /// Screenshot URLs, in the same order as the screenshot actions provided.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("screenshots")]
        public global::System.Collections.Generic.IList<string>? Screenshots { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponseDataActions" /> class.
        /// </summary>
        /// <param name="screenshots">
        /// Screenshot URLs, in the same order as the screenshot actions provided.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeResponseDataActions(
            global::System.Collections.Generic.IList<string>? screenshots)
        {
            this.Screenshots = screenshots;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponseDataActions" /> class.
        /// </summary>
        public ScrapeResponseDataActions()
        {
        }
    }
}