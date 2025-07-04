
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// API for interacting with Firecrawl services to perform web scraping and crawling tasks.<br/>
    /// If no httpClient is provided, a new one will be created.<br/>
    /// If no baseUri is provided, the default baseUri from OpenAPI spec will be used.
    /// </summary>
    public partial interface IFirecrawlApp : global::System.IDisposable
    {
        /// <summary>
        /// The HttpClient instance.
        /// </summary>
        public global::System.Net.Http.HttpClient HttpClient { get; }

        /// <summary>
        /// The base URL for the API.
        /// </summary>
        public System.Uri? BaseUri { get; }

        /// <summary>
        /// The authorizations to use for the requests.
        /// </summary>
        public global::System.Collections.Generic.List<global::Firecrawl.EndPointAuthorization> Authorizations { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the response content should be read as a string.
        /// True by default in debug builds, false otherwise.
        /// </summary>
        public bool ReadResponseAsString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        global::System.Text.Json.Serialization.JsonSerializerContext JsonSerializerContext { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public ScrapingClient Scraping { get; }

        /// <summary>
        /// 
        /// </summary>
        public CrawlingClient Crawling { get; }

        /// <summary>
        /// 
        /// </summary>
        public MappingClient Mapping { get; }

        /// <summary>
        /// 
        /// </summary>
        public ExtractionClient Extraction { get; }

        /// <summary>
        /// 
        /// </summary>
        public ResearchClient Research { get; }

        /// <summary>
        /// 
        /// </summary>
        public BillingClient Billing { get; }

        /// <summary>
        /// 
        /// </summary>
        public SearchClient Search { get; }

        /// <summary>
        /// 
        /// </summary>
        public LLMsTxtClient LLMsTxt { get; }

    }
}