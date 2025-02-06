
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
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestFormatJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestFormatNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant1TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant1TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant2TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant2TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant3TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant3TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant4TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant4TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant5TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant5TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant6TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant6TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant6DirectionJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant6DirectionNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant7TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant7TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant8TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlRequestActionVariant8TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestFormatJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestFormatNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant1TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant1TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant2TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant2TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant3TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant3TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant4TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant4TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant5TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant5TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant6TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant6TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant6DirectionJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant6DirectionNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant7TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant7TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant8TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestActionVariant8TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestScrapeOptionsFormatJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestScrapeOptionsFormatNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CancelCrawlResponseStatusJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CancelCrawlResponseStatusNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CancelCrawlResponseStatus2JsonConverter),
            typeof(global::Firecrawl.JsonConverters.CancelCrawlResponseStatus2NullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant1, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant2, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant4, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant5, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant6, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant7, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant8>),
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhook>),
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant1, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant2, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant3, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant4, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant5, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant7, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8>),
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::Firecrawl.CrawlUrlsRequestWebhook>),
            typeof(global::Firecrawl.JsonConverters.UnixTimestampJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}