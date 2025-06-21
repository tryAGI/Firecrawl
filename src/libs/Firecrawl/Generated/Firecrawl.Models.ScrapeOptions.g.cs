
#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeOptions
    {
        /// <summary>
        /// Formats to include in the output.<br/>
        /// Default Value: [markdown]
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("formats")]
        public global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsFormat>? Formats { get; set; }

        /// <summary>
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("onlyMainContent")]
        public bool? OnlyMainContent { get; set; }

        /// <summary>
        /// Tags to include in the output.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("includeTags")]
        public global::System.Collections.Generic.IList<string>? IncludeTags { get; set; }

        /// <summary>
        /// Tags to exclude from the output.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("excludeTags")]
        public global::System.Collections.Generic.IList<string>? ExcludeTags { get; set; }

        /// <summary>
        /// Returns a cached version of the page if it is younger than this age in milliseconds. If a cached version of the page is older than this value, the page will be scraped. If you do not need extremely fresh data, enabling this can speed up your scrapes by 500%. Defaults to 0, which disables caching.<br/>
        /// Default Value: 0
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("maxAge")]
        public int? MaxAge { get; set; }

        /// <summary>
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("headers")]
        public object? Headers { get; set; }

        /// <summary>
        /// Specify a delay in milliseconds before fetching the content, allowing the page sufficient time to load.<br/>
        /// Default Value: 0
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("waitFor")]
        public int? WaitFor { get; set; }

        /// <summary>
        /// Set to true if you want to emulate scraping from a mobile device. Useful for testing responsive pages and taking mobile screenshots.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("mobile")]
        public bool? Mobile { get; set; }

        /// <summary>
        /// Skip TLS certificate verification when making requests<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("skipTlsVerification")]
        public bool? SkipTlsVerification { get; set; }

        /// <summary>
        /// Timeout in milliseconds for the request<br/>
        /// Default Value: 30000
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("timeout")]
        public int? Timeout { get; set; }

        /// <summary>
        /// Controls how PDF files are processed during scraping. When true, the PDF content is extracted and converted to markdown format, with billing based on the number of pages (1 credit per page). When false, the PDF file is returned in base64 encoding with a flat rate of 1 credit total.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("parsePDF")]
        public bool? ParsePDF { get; set; }

        /// <summary>
        /// JSON options object
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("jsonOptions")]
        public global::Firecrawl.ScrapeOptionsJsonOptions? JsonOptions { get; set; }

        /// <summary>
        /// Actions to perform on the page before grabbing the content
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("actions")]
        public global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionVariant1, global::Firecrawl.ScrapeOptionsActionVariant2, global::Firecrawl.ScrapeOptionsActionVariant3, global::Firecrawl.ScrapeOptionsActionVariant4, global::Firecrawl.ScrapeOptionsActionVariant5, global::Firecrawl.ScrapeOptionsActionVariant6, global::Firecrawl.ScrapeOptionsActionVariant7, global::Firecrawl.ScrapeOptionsActionVariant8>>? Actions { get; set; }

        /// <summary>
        /// Location settings for the request. When specified, this will use an appropriate proxy if available and emulate the corresponding language and timezone settings. Defaults to 'US' if not specified.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("location")]
        public global::Firecrawl.ScrapeOptionsLocation? Location { get; set; }

        /// <summary>
        /// Removes all base 64 images from the output, which may be overwhelmingly long. The image's alt text remains in the output, but the URL is replaced with a placeholder.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("removeBase64Images")]
        public bool? RemoveBase64Images { get; set; }

        /// <summary>
        /// Enables ad-blocking and cookie popup blocking.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("blockAds")]
        public bool? BlockAds { get; set; }

        /// <summary>
        /// Specifies the type of proxy to use.<br/>
        ///  - **basic**: Proxies for scraping sites with none to basic anti-bot solutions. Fast and usually works.<br/>
        ///  - **stealth**: Stealth proxies for scraping sites with advanced anti-bot solutions. Slower, but more reliable on certain sites. Costs up to 5 credits per request.<br/>
        ///  - **auto**: Firecrawl will automatically retry scraping with stealth proxies if the basic proxy fails. If the retry with stealth is successful, 5 credits will be billed for the scrape. If the first attempt with basic is successful, only the regular cost will be billed.<br/>
        /// If you do not specify a proxy, Firecrawl will default to basic.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("proxy")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.ScrapeOptionsProxyJsonConverter))]
        public global::Firecrawl.ScrapeOptionsProxy? Proxy { get; set; }

        /// <summary>
        /// Options for change tracking (Beta). Only applicable when 'changeTracking' is included in formats. The 'markdown' format must also be specified when using change tracking.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("changeTrackingOptions")]
        public global::Firecrawl.ScrapeOptionsChangeTrackingOptions? ChangeTrackingOptions { get; set; }

        /// <summary>
        /// If true, the page will be stored in the Firecrawl index and cache. Setting this to false is useful if your scraping activity may have data protection concerns. Using some parameters associated with sensitive scraping (actions, headers) will force this parameter to be false.<br/>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("storeInCache")]
        public bool? StoreInCache { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeOptions" /> class.
        /// </summary>
        /// <param name="formats">
        /// Formats to include in the output.<br/>
        /// Default Value: [markdown]
        /// </param>
        /// <param name="onlyMainContent">
        /// Only return the main content of the page excluding headers, navs, footers, etc.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="includeTags">
        /// Tags to include in the output.
        /// </param>
        /// <param name="excludeTags">
        /// Tags to exclude from the output.
        /// </param>
        /// <param name="maxAge">
        /// Returns a cached version of the page if it is younger than this age in milliseconds. If a cached version of the page is older than this value, the page will be scraped. If you do not need extremely fresh data, enabling this can speed up your scrapes by 500%. Defaults to 0, which disables caching.<br/>
        /// Default Value: 0
        /// </param>
        /// <param name="headers">
        /// Headers to send with the request. Can be used to send cookies, user-agent, etc.
        /// </param>
        /// <param name="waitFor">
        /// Specify a delay in milliseconds before fetching the content, allowing the page sufficient time to load.<br/>
        /// Default Value: 0
        /// </param>
        /// <param name="mobile">
        /// Set to true if you want to emulate scraping from a mobile device. Useful for testing responsive pages and taking mobile screenshots.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="skipTlsVerification">
        /// Skip TLS certificate verification when making requests<br/>
        /// Default Value: false
        /// </param>
        /// <param name="timeout">
        /// Timeout in milliseconds for the request<br/>
        /// Default Value: 30000
        /// </param>
        /// <param name="parsePDF">
        /// Controls how PDF files are processed during scraping. When true, the PDF content is extracted and converted to markdown format, with billing based on the number of pages (1 credit per page). When false, the PDF file is returned in base64 encoding with a flat rate of 1 credit total.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="jsonOptions">
        /// JSON options object
        /// </param>
        /// <param name="actions">
        /// Actions to perform on the page before grabbing the content
        /// </param>
        /// <param name="location">
        /// Location settings for the request. When specified, this will use an appropriate proxy if available and emulate the corresponding language and timezone settings. Defaults to 'US' if not specified.
        /// </param>
        /// <param name="removeBase64Images">
        /// Removes all base 64 images from the output, which may be overwhelmingly long. The image's alt text remains in the output, but the URL is replaced with a placeholder.
        /// </param>
        /// <param name="blockAds">
        /// Enables ad-blocking and cookie popup blocking.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="proxy">
        /// Specifies the type of proxy to use.<br/>
        ///  - **basic**: Proxies for scraping sites with none to basic anti-bot solutions. Fast and usually works.<br/>
        ///  - **stealth**: Stealth proxies for scraping sites with advanced anti-bot solutions. Slower, but more reliable on certain sites. Costs up to 5 credits per request.<br/>
        ///  - **auto**: Firecrawl will automatically retry scraping with stealth proxies if the basic proxy fails. If the retry with stealth is successful, 5 credits will be billed for the scrape. If the first attempt with basic is successful, only the regular cost will be billed.<br/>
        /// If you do not specify a proxy, Firecrawl will default to basic.
        /// </param>
        /// <param name="changeTrackingOptions">
        /// Options for change tracking (Beta). Only applicable when 'changeTracking' is included in formats. The 'markdown' format must also be specified when using change tracking.
        /// </param>
        /// <param name="storeInCache">
        /// If true, the page will be stored in the Firecrawl index and cache. Setting this to false is useful if your scraping activity may have data protection concerns. Using some parameters associated with sensitive scraping (actions, headers) will force this parameter to be false.<br/>
        /// Default Value: true
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ScrapeOptions(
            global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsFormat>? formats,
            bool? onlyMainContent,
            global::System.Collections.Generic.IList<string>? includeTags,
            global::System.Collections.Generic.IList<string>? excludeTags,
            int? maxAge,
            object? headers,
            int? waitFor,
            bool? mobile,
            bool? skipTlsVerification,
            int? timeout,
            bool? parsePDF,
            global::Firecrawl.ScrapeOptionsJsonOptions? jsonOptions,
            global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionVariant1, global::Firecrawl.ScrapeOptionsActionVariant2, global::Firecrawl.ScrapeOptionsActionVariant3, global::Firecrawl.ScrapeOptionsActionVariant4, global::Firecrawl.ScrapeOptionsActionVariant5, global::Firecrawl.ScrapeOptionsActionVariant6, global::Firecrawl.ScrapeOptionsActionVariant7, global::Firecrawl.ScrapeOptionsActionVariant8>>? actions,
            global::Firecrawl.ScrapeOptionsLocation? location,
            bool? removeBase64Images,
            bool? blockAds,
            global::Firecrawl.ScrapeOptionsProxy? proxy,
            global::Firecrawl.ScrapeOptionsChangeTrackingOptions? changeTrackingOptions,
            bool? storeInCache)
        {
            this.Formats = formats;
            this.OnlyMainContent = onlyMainContent;
            this.IncludeTags = includeTags;
            this.ExcludeTags = excludeTags;
            this.MaxAge = maxAge;
            this.Headers = headers;
            this.WaitFor = waitFor;
            this.Mobile = mobile;
            this.SkipTlsVerification = skipTlsVerification;
            this.Timeout = timeout;
            this.ParsePDF = parsePDF;
            this.JsonOptions = jsonOptions;
            this.Actions = actions;
            this.Location = location;
            this.RemoveBase64Images = removeBase64Images;
            this.BlockAds = blockAds;
            this.Proxy = proxy;
            this.ChangeTrackingOptions = changeTrackingOptions;
            this.StoreInCache = storeInCache;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeOptions" /> class.
        /// </summary>
        public ScrapeOptions()
        {
        }
    }
}