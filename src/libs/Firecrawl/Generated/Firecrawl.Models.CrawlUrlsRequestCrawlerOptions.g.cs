
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlUrlsRequestCrawlerOptions
    {
        /// <summary>
        /// URL patterns to include
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includes")]
        public global::System.Collections.Generic.IList<string>? Includes { get; set; }

        /// <summary>
        /// URL patterns to exclude
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("excludes")]
        public global::System.Collections.Generic.IList<string>? Excludes { get; set; }

        /// <summary>
        /// Generate alt text for images using LLMs (must have a paid plan)<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("generateImgAltText")]
        public bool? GenerateImgAltText { get; set; }

        /// <summary>
        /// If true, returns only the URLs as a list on the crawl status. Attention: the return response will be a list of URLs inside the data, not a list of documents.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("returnOnlyUrls")]
        public bool? ReturnOnlyUrls { get; set; }

        /// <summary>
        /// Maximum depth to crawl relative to the entered URL. A maxDepth of 0 scrapes only the entered URL. A maxDepth of 1 scrapes the entered URL and all pages one level deep. A maxDepth of 2 scrapes the entered URL and all pages up to two levels deep. Higher values follow the same pattern.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("maxDepth")]
        public int? MaxDepth { get; set; }

        /// <summary>
        /// The crawling mode to use. Fast mode crawls 4x faster websites without sitemap, but may not be as accurate and shouldn't be used in heavy js-rendered websites.<br/>
        /// Default Value: default
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("mode")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestCrawlerOptionsModeJsonConverter))]
        public global::Firecrawl.CrawlUrlsRequestCrawlerOptionsMode? Mode { get; set; }

        /// <summary>
        /// Ignore the website sitemap when crawling<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("ignoreSitemap")]
        public bool? IgnoreSitemap { get; set; }

        /// <summary>
        /// Maximum number of pages to crawl<br/>
        /// Default Value: 10000
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Enables the crawler to navigate from a specific URL to previously linked pages. For instance, from 'example.com/product/123' back to 'example.com/product'<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allowBackwardCrawling")]
        public bool? AllowBackwardCrawling { get; set; }

        /// <summary>
        /// Allows the crawler to follow links to external websites.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allowExternalContentLinks")]
        public bool? AllowExternalContentLinks { get; set; }

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
#if NET8_0_OR_GREATER
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
        public static global::Firecrawl.CrawlUrlsRequestCrawlerOptions? FromJson(
            string json,
            global::System.Text.Json.Serialization.JsonSerializerContext jsonSerializerContext)
        {
            return global::System.Text.Json.JsonSerializer.Deserialize(
                json,
                typeof(global::Firecrawl.CrawlUrlsRequestCrawlerOptions),
                jsonSerializerContext) as global::Firecrawl.CrawlUrlsRequestCrawlerOptions;
        }

        /// <summary>
        /// Deserializes a JSON string using the provided JsonSerializerOptions.
        /// </summary>
#if NET8_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
        [global::System.Diagnostics.CodeAnalysis.RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
#endif
        public static global::Firecrawl.CrawlUrlsRequestCrawlerOptions? FromJson(
            string json,
            global::System.Text.Json.JsonSerializerOptions? jsonSerializerOptions = null)
        {
            return global::System.Text.Json.JsonSerializer.Deserialize<global::Firecrawl.CrawlUrlsRequestCrawlerOptions>(
                json,
                jsonSerializerOptions);
        }

    }
}