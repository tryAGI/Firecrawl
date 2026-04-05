
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// API for interacting with Firecrawl services to perform web scraping and crawling tasks.<br/>
    /// If no httpClient is provided, a new one will be created.<br/>
    /// If no baseUri is provided, the default baseUri from OpenAPI spec will be used.
    /// </summary>
    public sealed partial class FirecrawlClient : global::Firecrawl.IFirecrawlClient, global::System.IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DefaultBaseUrl = "https://api.firecrawl.dev/v1";

        private bool _disposeHttpClient = true;

        /// <inheritdoc/>
        public global::System.Net.Http.HttpClient HttpClient { get; }

        /// <inheritdoc/>
        public System.Uri? BaseUri => HttpClient.BaseAddress;

        /// <inheritdoc/>
        public global::System.Collections.Generic.List<global::Firecrawl.EndPointAuthorization> Authorizations { get; }

        /// <inheritdoc/>
        public bool ReadResponseAsString { get; set; }
#if DEBUG
            = true;
#endif
        /// <summary>
        /// 
        /// </summary>
        #pragma warning disable CS0618 // Type or member is obsolete
        public global::System.Text.Json.JsonSerializerOptions JsonSerializerOptions { get; set; } = new global::System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                Converters =
                {
                    new global::Firecrawl.JsonConverters.ScrapeOptionsFormatJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsFormatNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionWaitTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionWaitTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScreenshotTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScreenshotTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionClickTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionClickTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionWriteTextTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionWriteTextTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionPressAKeyTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionPressAKeyTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollDirectionJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollDirectionNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrapeTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrapeTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionExecuteJavaScriptTypeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsActionExecuteJavaScriptTypeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsProxyJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsProxyNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsChangeTrackingOptionsModeJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeOptionsChangeTrackingOptionsModeNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingChangeStatusJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingChangeStatusNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingVisibilityJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeResponseDataChangeTrackingVisibilityNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ExtractStatusResponseStatusJsonConverter(),
                    new global::Firecrawl.JsonConverters.ExtractStatusResponseStatusNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestWebhookEventJsonConverter(),
                    new global::Firecrawl.JsonConverters.ScrapeAndExtractFromUrlsRequestWebhookEventNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.CrawlUrlsRequestWebhookEventJsonConverter(),
                    new global::Firecrawl.JsonConverters.CrawlUrlsRequestWebhookEventNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.StartDeepResearchRequestFormatJsonConverter(),
                    new global::Firecrawl.JsonConverters.StartDeepResearchRequestFormatNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.SearchAndScrapeRequestScrapeOptionsFormatJsonConverter(),
                    new global::Firecrawl.JsonConverters.SearchAndScrapeRequestScrapeOptionsFormatNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.CancelCrawlResponseStatusJsonConverter(),
                    new global::Firecrawl.JsonConverters.CancelCrawlResponseStatusNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.GetDeepResearchStatusResponseDataStatusJsonConverter(),
                    new global::Firecrawl.JsonConverters.GetDeepResearchStatusResponseDataStatusNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.GetLLMsTxtStatusResponseStatusJsonConverter(),
                    new global::Firecrawl.JsonConverters.GetLLMsTxtStatusResponseStatusNullableJsonConverter(),
                    new global::Firecrawl.JsonConverters.OneOfJsonConverter<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>(),
                    new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>(),
                    new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>(),
                    new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>(),
                    new global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlRequest2, global::Firecrawl.ScrapeOptions>(),
                    new global::Firecrawl.JsonConverters.AllOfJsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequest2, global::Firecrawl.ScrapeOptions>(),
                    new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>(),
                    new global::Firecrawl.JsonConverters.UnixTimestampJsonConverter(),
                }
            };
        #pragma warning restore CS0618 // Type or member is obsolete


        /// <summary>
        /// 
        /// </summary>
        public BillingClient Billing => new BillingClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// 
        /// </summary>
        public CrawlingClient Crawling => new CrawlingClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// 
        /// </summary>
        public ExtractionClient Extraction => new ExtractionClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// 
        /// </summary>
        public LLMsTxtClient LLMsTxt => new LLMsTxtClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// 
        /// </summary>
        public MappingClient Mapping => new MappingClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// 
        /// </summary>
        public ResearchClient Research => new ResearchClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// 
        /// </summary>
        public ScrapingClient Scraping => new ScrapingClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// 
        /// </summary>
        public SearchClient Search => new SearchClient(HttpClient, authorizations: Authorizations)
        {
            ReadResponseAsString = ReadResponseAsString,
            JsonSerializerOptions = JsonSerializerOptions,
        };

        /// <summary>
        /// Creates a new instance of the FirecrawlClient.
        /// If no httpClient is provided, a new one will be created.
        /// If no baseUri is provided, the default baseUri from OpenAPI spec will be used.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance. If not provided, a new one will be created.</param>
        /// <param name="baseUri">The base URL for the API. If not provided, the default baseUri from OpenAPI spec will be used.</param>
        /// <param name="authorizations">The authorizations to use for the requests.</param>
        /// <param name="disposeHttpClient">Dispose the HttpClient when the instance is disposed. True by default.</param>
        public FirecrawlClient(
            global::System.Net.Http.HttpClient? httpClient = null,
            global::System.Uri? baseUri = null,
            global::System.Collections.Generic.List<global::Firecrawl.EndPointAuthorization>? authorizations = null,
            bool disposeHttpClient = true)
        {
            HttpClient = httpClient ?? new global::System.Net.Http.HttpClient();
            HttpClient.BaseAddress ??= baseUri ?? new global::System.Uri(DefaultBaseUrl);
            Authorizations = authorizations ?? new global::System.Collections.Generic.List<global::Firecrawl.EndPointAuthorization>();
            _disposeHttpClient = disposeHttpClient;

            Initialized(HttpClient);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposeHttpClient)
            {
                HttpClient.Dispose();
            }
        }

        partial void Initialized(
            global::System.Net.Http.HttpClient client);
        partial void PrepareArguments(
            global::System.Net.Http.HttpClient client);
        partial void PrepareRequest(
            global::System.Net.Http.HttpClient client,
            global::System.Net.Http.HttpRequestMessage request);
        partial void ProcessResponse(
            global::System.Net.Http.HttpClient client,
            global::System.Net.Http.HttpResponseMessage response);
        partial void ProcessResponseContent(
            global::System.Net.Http.HttpClient client,
            global::System.Net.Http.HttpResponseMessage response,
            ref string content);
    }
}