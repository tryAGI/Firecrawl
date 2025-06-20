
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Change tracking information if `changeTracking` is in `formats`. Only present when the `changeTracking` format is requested.
    /// </summary>
    public sealed partial class ScrapeResponseDataChangeTracking
    {
        /// <summary>
        /// The timestamp of the previous scrape that the current page is being compared against. Null if no previous scrape exists.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("previousScrapeAt")]
        public global::System.DateTime? PreviousScrapeAt { get; set; }

        /// <summary>
        /// The result of the comparison between the two page versions. 'new' means this page did not exist before, 'same' means content has not changed, 'changed' means content has changed, 'removed' means the page was removed.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("changeStatus")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingChangeStatusJsonConverter))]
        public global::Firecrawl.ScrapeResponseDataChangeTrackingChangeStatus? ChangeStatus { get; set; }

        /// <summary>
        /// The visibility of the current page/URL. 'visible' means the URL was discovered through an organic route (links or sitemap), 'hidden' means the URL was discovered through memory from previous crawls.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("visibility")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingVisibilityJsonConverter))]
        public global::Firecrawl.ScrapeResponseDataChangeTrackingVisibility? Visibility { get; set; }

        /// <summary>
        /// Git-style diff of changes when using 'git-diff' mode. Only present when the mode is set to 'git-diff'.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("diff")]
        public string? Diff { get; set; }

        /// <summary>
        /// JSON comparison results when using 'json' mode. Only present when the mode is set to 'json'. This will emit a list of all the keys and their values from the `previous` and `current` scrapes based on the type defined in the `schema`. Example [here](/features/change-tracking)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("json")]
        public object? Json { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponseDataChangeTracking" /> class.
        /// </summary>
        /// <param name="previousScrapeAt">
        /// The timestamp of the previous scrape that the current page is being compared against. Null if no previous scrape exists.
        /// </param>
        /// <param name="changeStatus">
        /// The result of the comparison between the two page versions. 'new' means this page did not exist before, 'same' means content has not changed, 'changed' means content has changed, 'removed' means the page was removed.
        /// </param>
        /// <param name="visibility">
        /// The visibility of the current page/URL. 'visible' means the URL was discovered through an organic route (links or sitemap), 'hidden' means the URL was discovered through memory from previous crawls.
        /// </param>
        /// <param name="diff">
        /// Git-style diff of changes when using 'git-diff' mode. Only present when the mode is set to 'git-diff'.
        /// </param>
        /// <param name="json">
        /// JSON comparison results when using 'json' mode. Only present when the mode is set to 'json'. This will emit a list of all the keys and their values from the `previous` and `current` scrapes based on the type defined in the `schema`. Example [here](/features/change-tracking)
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeResponseDataChangeTracking(
            global::System.DateTime? previousScrapeAt,
            global::Firecrawl.ScrapeResponseDataChangeTrackingChangeStatus? changeStatus,
            global::Firecrawl.ScrapeResponseDataChangeTrackingVisibility? visibility,
            string? diff,
            object? json)
        {
            this.PreviousScrapeAt = previousScrapeAt;
            this.ChangeStatus = changeStatus;
            this.Visibility = visibility;
            this.Diff = diff;
            this.Json = json;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponseDataChangeTracking" /> class.
        /// </summary>
        public ScrapeResponseDataChangeTracking()
        {
        }
    }
}