
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
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsFormatJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsFormatNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant1TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant1TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant2TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant2TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant3TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant3TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant4TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant4TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant5TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant5TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant6TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant6TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant6DirectionJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant6DirectionNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant7TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant7TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant8TypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionVariant8TypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsProxyJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsProxyNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsChangeTrackingOptionsModeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsChangeTrackingOptionsModeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingChangeStatusJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingChangeStatusNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingVisibilityJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingVisibilityNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ExtractStatusResponseStatusJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ExtractStatusResponseStatusNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestWebhookEventJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestWebhookEventNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestWebhookEventJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CrawlUrlsRequestWebhookEventNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.StartDeepResearchRequestFormatJsonConverter),
            typeof(global::Firecrawl.JsonConverters.StartDeepResearchRequestFormatNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.SearchAndScrapeRequestScrapeOptionsFormatJsonConverter),
            typeof(global::Firecrawl.JsonConverters.SearchAndScrapeRequestScrapeOptionsFormatNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CancelCrawlResponseStatusJsonConverter),
            typeof(global::Firecrawl.JsonConverters.CancelCrawlResponseStatusNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.GetDeepResearchStatusResponseDataStatusJsonConverter),
            typeof(global::Firecrawl.JsonConverters.GetDeepResearchStatusResponseDataStatusNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.GetLLMsTxtStatusResponseStatusJsonConverter),
            typeof(global::Firecrawl.JsonConverters.GetLLMsTxtStatusResponseStatusNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<global::Firecrawl.ScrapeOptionsActionVariant1, global::Firecrawl.ScrapeOptionsActionVariant2, global::Firecrawl.ScrapeOptionsActionVariant3, global::Firecrawl.ScrapeOptionsActionVariant4, global::Firecrawl.ScrapeOptionsActionVariant5, global::Firecrawl.ScrapeOptionsActionVariant6, global::Firecrawl.ScrapeOptionsActionVariant7, global::Firecrawl.ScrapeOptionsActionVariant8>),
            typeof(global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlRequest2, global::Firecrawl.ScrapeOptions>),
            typeof(global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions>),
            typeof(global::Firecrawl.JsonConverters.UnixTimestampJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}