
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlUrlsRequestPageOptions
    {
        /// <summary>
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("headers")]
        public object? Headers { get; set; }

        /// <summary>
        /// Include the HTML version of the content on page. Will output a html key in the response.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includeHtml")]
        public bool? IncludeHtml { get; set; } = false;

        /// <summary>
        /// Include the raw HTML content of the page. Will output a rawHtml key in the response.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includeRawHtml")]
        public bool? IncludeRawHtml { get; set; } = false;

        /// <summary>
        /// Only include tags, classes and ids from the page in the final output. Use comma separated values. Example: 'script, .ad, #footer'
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("onlyIncludeTags")]
        public global::System.Collections.Generic.IList<string>? OnlyIncludeTags { get; set; }

        /// <summary>
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("onlyMainContent")]
        public bool? OnlyMainContent { get; set; } = false;

        /// <summary>
        /// Tags, classes and ids to remove from the page. Use comma separated values. Example: 'script, .ad, #footer'
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("removeTags")]
        public global::System.Collections.Generic.IList<string>? RemoveTags { get; set; }

        /// <summary>
        /// Replace all relative paths with absolute paths for images and links<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("replaceAllPathsWithAbsolutePaths")]
        public bool? ReplaceAllPathsWithAbsolutePaths { get; set; } = false;

        /// <summary>
        /// Include a screenshot of the top of the page that you are scraping.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("screenshot")]
        public bool? Screenshot { get; set; } = false;

        /// <summary>
        /// Include a full page screenshot of the page that you are scraping.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("fullPageScreenshot")]
        public bool? FullPageScreenshot { get; set; } = false;

        /// <summary>
        /// Wait x amount of milliseconds for the page to load to fetch content<br/>
        /// Default Value: 0
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("waitFor")]
        public int? WaitFor { get; set; } = 0;

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();


        /// <summary>
        /// Serializes the current instance to a JSON string using the provided JsonSerializerContext.
        /// </summary>
        public string ToJson(
            global::System.Text.Json.Serialization.JsonSerializerContext jsonSerializerContext)
        {
            return global::System.Text.Json.JsonSerializer.Serialize(
                this,
                this.GetType(),
                jsonSerializerContext);
        }

        /// <summary>
        /// Serializes the current instance to a JSON string using the provided JsonSerializerOptions.
        /// </summary>
    #if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
        [global::System.Diagnostics.CodeAnalysis.RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
    #endif
        public string ToJson(
            global::System.Text.Json.JsonSerializerOptions? jsonSerializerOptions = null)
        {
            return global::System.Text.Json.JsonSerializer.Serialize(
                this,
                jsonSerializerOptions);
        }

        /// <summary>
        /// Deserializes a JSON string using the provided JsonSerializerContext.
        /// </summary>
        public static global::Firecrawl.CrawlUrlsRequestPageOptions? FromJson(
            string json,
            global::System.Text.Json.Serialization.JsonSerializerContext jsonSerializerContext)
        {
            return global::System.Text.Json.JsonSerializer.Deserialize(
                json,
                typeof(global::Firecrawl.CrawlUrlsRequestPageOptions),
                jsonSerializerContext) as global::Firecrawl.CrawlUrlsRequestPageOptions;
        }

        /// <summary>
        /// Deserializes a JSON string using the provided JsonSerializerOptions.
        /// </summary>
#if NET6_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
        [global::System.Diagnostics.CodeAnalysis.RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
#endif
        public static global::Firecrawl.CrawlUrlsRequestPageOptions? FromJson(
            string json,
            global::System.Text.Json.JsonSerializerOptions? jsonSerializerOptions = null)
        {
            return global::System.Text.Json.JsonSerializer.Deserialize<global::Firecrawl.CrawlUrlsRequestPageOptions>(
                json,
                jsonSerializerOptions);
        }

    }
}