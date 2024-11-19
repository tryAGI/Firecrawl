
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
            typeof(global::Firecrawl.JsonConverters.ScrapeRequestFormatJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeRequestFormatNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestCrawlerOptionsModeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestCrawlerOptionsModeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.UnixTimestampJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}