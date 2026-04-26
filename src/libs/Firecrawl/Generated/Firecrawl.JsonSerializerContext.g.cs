
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

            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlRequest2, global::Firecrawl.ScrapeOptions>),

            typeof(global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions>),

            typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>),

            typeof(global::Firecrawl.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsFormat), TypeInfoPropertyName = "ScrapeOptionsFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsJsonOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>>), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScript_f681b9d095e7f3b8")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScript_6399eca05818f0a8")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWait))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWaitType), TypeInfoPropertyName = "ScrapeOptionsActionWaitType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScreenshot))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScreenshotType), TypeInfoPropertyName = "ScrapeOptionsActionScreenshotType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionClick))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionClickType), TypeInfoPropertyName = "ScrapeOptionsActionClickType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWriteText))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWriteTextType), TypeInfoPropertyName = "ScrapeOptionsActionWriteTextType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionPressAKey))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionPressAKeyType), TypeInfoPropertyName = "ScrapeOptionsActionPressAKeyType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScroll))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrollType), TypeInfoPropertyName = "ScrapeOptionsActionScrollType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrollDirection), TypeInfoPropertyName = "ScrapeOptionsActionScrollDirection2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrape))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrapeType), TypeInfoPropertyName = "ScrapeOptionsActionScrapeType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScript))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScriptType), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScriptType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsLocation))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsProxy), TypeInfoPropertyName = "ScrapeOptionsProxy2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode), TypeInfoPropertyName = "ScrapeOptionsChangeTrackingOptionsMode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseData))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataActions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeResponseDataActionsScrape>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataActionsScrape))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeResponseDataActionsJavascriptReturn>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataActionsJavascriptReturn))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataMetadata))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.OneOf<string, global::System.Collections.Generic.IList<string>>), TypeInfoPropertyName = "OneOfStringIListString2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataChangeTracking))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataChangeTrackingChangeStatus), TypeInfoPropertyName = "ScrapeResponseDataChangeTrackingChangeStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataChangeTrackingVisibility), TypeInfoPropertyName = "ScrapeResponseDataChangeTrackingVisibility2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataBranding))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeResponseDataBrandingFont>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeResponseDataBrandingFont))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlStatusResponseObj))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.CrawlStatusResponseObjDataItem>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlStatusResponseObjDataItem))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlStatusResponseObjDataItemMetadata))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlErrorsResponseObj))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.CrawlErrorsResponseObjError>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlErrorsResponseObjError))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.BatchScrapeStatusResponseObj))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.BatchScrapeStatusResponseObjDataItem>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.BatchScrapeStatusResponseObjDataItem))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.BatchScrapeStatusResponseObjDataItemMetadata))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.BatchScrapeResponseObj))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.MapResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractStatusResponseStatus), TypeInfoPropertyName = "ExtractStatusResponseStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.AllOf<global::Firecrawl.ScrapeAndExtractFromUrlRequest2, global::Firecrawl.ScrapeOptions>), TypeInfoPropertyName = "AllOfScrapeAndExtractFromUrlRequest2ScrapeOptions2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlRequest2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.AllOf<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions>), TypeInfoPropertyName = "AllOfScrapeAndExtractFromUrlsRequest2ScrapeOptions2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlsRequest2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhook))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent), TypeInfoPropertyName = "ScrapeAndExtractFromUrlsRequestWebhookEvent2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlUrlsRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlUrlsRequestWebhook))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.CrawlUrlsRequestWebhookEvent>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlUrlsRequestWebhookEvent), TypeInfoPropertyName = "CrawlUrlsRequestWebhookEvent2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.MapUrlsRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractDataRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.StartDeepResearchRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.StartDeepResearchRequestFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.StartDeepResearchRequestFormat), TypeInfoPropertyName = "StartDeepResearchRequestFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.StartDeepResearchRequestJsonOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeRequestScrapeOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.SearchAndScrapeRequestScrapeOptionsFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeRequestScrapeOptionsFormat), TypeInfoPropertyName = "SearchAndScrapeRequestScrapeOptionsFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GenerateLLMsTxtRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlsResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeAndExtractFromUrlsResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetBatchScrapeStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetBatchScrapeStatusResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetBatchScrapeStatusResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CancelBatchScrapeResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CancelBatchScrapeResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CancelBatchScrapeResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetBatchScrapeErrorsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetBatchScrapeErrorsResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetBatchScrapeErrorsResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCrawlStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCrawlStatusResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCrawlStatusResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CancelCrawlResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CancelCrawlResponseStatus), TypeInfoPropertyName = "CancelCrawlResponseStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CancelCrawlResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CancelCrawlResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCrawlErrorsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCrawlErrorsResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCrawlErrorsResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlUrlsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlUrlsResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.CrawlUrlsResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.MapUrlsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.MapUrlsResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.MapUrlsResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractDataResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractDataResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetActiveCrawlsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.GetActiveCrawlsResponseCrawl>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetActiveCrawlsResponseCrawl))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Guid))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetActiveCrawlsResponseCrawlOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetActiveCrawlsResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetActiveCrawlsResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetActiveCrawlsResponse4))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.StartDeepResearchResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.StartDeepResearchResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetDeepResearchStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetDeepResearchStatusResponseData))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.GetDeepResearchStatusResponseDataActivitie>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetDeepResearchStatusResponseDataActivitie))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.GetDeepResearchStatusResponseDataSource>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetDeepResearchStatusResponseDataSource))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetDeepResearchStatusResponseDataStatus), TypeInfoPropertyName = "GetDeepResearchStatusResponseDataStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetDeepResearchStatusResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCreditUsageResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCreditUsageResponseData))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCreditUsageResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetCreditUsageResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetTokenUsageResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetTokenUsageResponseData))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetTokenUsageResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetTokenUsageResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.SearchAndScrapeResponseDataItem>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeResponseDataItem))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeResponseDataItemMetadata))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.SearchAndScrapeResponse3))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GenerateLLMsTxtResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GenerateLLMsTxtResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetLLMsTxtStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetLLMsTxtStatusResponseStatus), TypeInfoPropertyName = "GetLLMsTxtStatusResponseStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetLLMsTxtStatusResponseData))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.GetLLMsTxtStatusResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeOptionsFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>>), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScript_aa877162c83d46a8")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeResponseDataActionsScrape>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeResponseDataActionsJavascriptReturn>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.OneOf<string, global::System.Collections.Generic.List<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeResponseDataBrandingFont>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.CrawlStatusResponseObjDataItem>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.CrawlErrorsResponseObjError>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.BatchScrapeStatusResponseObjDataItem>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.CrawlUrlsRequestWebhookEvent>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.StartDeepResearchRequestFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.SearchAndScrapeRequestScrapeOptionsFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.GetActiveCrawlsResponseCrawl>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.GetDeepResearchStatusResponseDataActivitie>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.GetDeepResearchStatusResponseDataSource>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.SearchAndScrapeResponseDataItem>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}