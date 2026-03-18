
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
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionWaitTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionWaitTypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScreenshotTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScreenshotTypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionClickTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionClickTypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionWriteTextTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionWriteTextTypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionPressAKeyTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionPressAKeyTypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollTypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollDirectionJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollDirectionNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScrapeTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionScrapeTypeNullableJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionExecuteJavaScriptTypeJsonConverter),
            typeof(global::Firecrawl.JsonConverters.ScrapeOptionsActionExecuteJavaScriptTypeNullableJsonConverter),
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
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>),
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),
            typeof(global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlRequest2, global::Firecrawl.ScrapeOptions>),
            typeof(global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions>),
            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),
            typeof(global::Firecrawl.JsonConverters.UnixTimestampJsonConverter),
        })]

    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.JsonSerializerContextTypes))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}