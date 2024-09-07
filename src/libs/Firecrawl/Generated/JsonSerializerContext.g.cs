
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[] 
        { 
            typeof(global::OpenApiGenerator.JsonConverters.ScrapeRequestFormatJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.ScrapeRequestFormatNullableJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CrawlUrlsRequestCrawlerOptionsModeJsonConverter),
            typeof(global::OpenApiGenerator.JsonConverters.CrawlUrlsRequestCrawlerOptionsModeNullableJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}