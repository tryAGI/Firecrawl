
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Press a key on the page. See https://asawicki.info/nosense/doc/devices/keyboard/key_codes.html for key codes.
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlsRequestActionVariant5
    {
        /// <summary>
        /// Press a key on the page
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant5TypeJsonConverter))]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant5Type Type { get; set; }

        /// <summary>
        /// Key to press<br/>
        /// Example: Enter
        /// </summary>
        /// <example>Enter</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("key")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Key { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant5" /> class.
        /// </summary>
        /// <param name="type">
        /// Press a key on the page
        /// </param>
        /// <param name="key">
        /// Key to press<br/>
        /// Example: Enter
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeAndExtractFromUrlsRequestActionVariant5(
            string key,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant5Type type)
        {
            this.Key = key ?? throw new global::System.ArgumentNullException(nameof(key));
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequestActionVariant5" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlsRequestActionVariant5()
        {
        }
    }
}