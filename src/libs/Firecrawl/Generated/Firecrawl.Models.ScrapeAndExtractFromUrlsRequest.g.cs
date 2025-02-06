
#pragma warning disable CS0618 // Type or member is obsolete

#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeAndExtractFromUrlsRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("urls")]
        public global::System.Collections.Generic.IList<string>? Urls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("webhook")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhook>))]
        public global::Firecrawl.OneOf<string, global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhook>? Webhook { get; set; }

        /// <summary>
        /// Formats to include in the output.<br/>
        /// Default Value: [markdown]
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("formats")]
        public global::System.Collections.Generic.IList<global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat>? Formats { get; set; }

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
        /// Extract object
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("extract")]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestExtract? Extract { get; set; }

        /// <summary>
        /// Actions to perform on the page before grabbing the content
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("actions")]
        public global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant1, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant2, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant3, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant4, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant5, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant7, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8>>? Actions { get; set; }

        /// <summary>
        /// Location settings for the request. When specified, this will use an appropriate proxy if available and emulate the corresponding language and timezone settings. Defaults to 'US' if not specified.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("location")]
        public global::Firecrawl.ScrapeAndExtractFromUrlsRequestLocation? Location { get; set; }

        /// <summary>
        /// Removes all base 64 images from the output, which may be overwhelmingly long. The image's alt text remains in the output, but the URL is replaced with a placeholder.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("removeBase64Images")]
        public bool? RemoveBase64Images { get; set; }

        /// <summary>
        /// If invalid URLs are specified in the urls array, they will be ignored. Instead of them failing the entire request, a batch scrape using the remaining valid URLs will be created, and the invalid URLs will be returned in the invalidURLs field of the response.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("ignoreInvalidURLs")]
        public bool? IgnoreInvalidURLs { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequest" /> class.
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="webhook"></param>
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
        /// <param name="extract">
        /// Extract object
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
        /// <param name="ignoreInvalidURLs">
        /// If invalid URLs are specified in the urls array, they will be ignored. Instead of them failing the entire request, a batch scrape using the remaining valid URLs will be created, and the invalid URLs will be returned in the invalidURLs field of the response.<br/>
        /// Default Value: false
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeAndExtractFromUrlsRequest(
            global::System.Collections.Generic.IList<string>? urls,
            global::Firecrawl.OneOf<string, global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhook>? webhook,
            global::System.Collections.Generic.IList<global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat>? formats,
            bool? onlyMainContent,
            global::System.Collections.Generic.IList<string>? includeTags,
            global::System.Collections.Generic.IList<string>? excludeTags,
            object? headers,
            int? waitFor,
            bool? mobile,
            bool? skipTlsVerification,
            int? timeout,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestExtract? extract,
            global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant1, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant2, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant3, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant4, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant5, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant7, global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8>>? actions,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestLocation? location,
            bool? removeBase64Images,
            bool? ignoreInvalidURLs)
        {
            this.Urls = urls;
            this.Webhook = webhook;
            this.Formats = formats;
            this.OnlyMainContent = onlyMainContent;
            this.IncludeTags = includeTags;
            this.ExcludeTags = excludeTags;
            this.Headers = headers;
            this.WaitFor = waitFor;
            this.Mobile = mobile;
            this.SkipTlsVerification = skipTlsVerification;
            this.Timeout = timeout;
            this.Extract = extract;
            this.Actions = actions;
            this.Location = location;
            this.RemoveBase64Images = removeBase64Images;
            this.IgnoreInvalidURLs = ignoreInvalidURLs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeAndExtractFromUrlsRequest" /> class.
        /// </summary>
        public ScrapeAndExtractFromUrlsRequest()
        {
        }
    }
}