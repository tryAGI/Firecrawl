
#nullable enable

namespace Firecrawl
{
    public partial class CrawlingClient
    {
        partial void PrepareCrawlUrlsArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Firecrawl.CrawlUrlsRequest request);
        partial void PrepareCrawlUrlsRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Firecrawl.CrawlUrlsRequest request);
        partial void ProcessCrawlUrlsResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessCrawlUrlsResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Crawl multiple URLs based on options
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.CrawlResponse> CrawlUrlsAsync(
            global::Firecrawl.CrawlUrlsRequest request,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareCrawlUrlsArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Firecrawl.PathBuilder(
                path: "/crawl",
                baseUri: HttpClient.BaseAddress); 
            var __path = __pathBuilder.ToString();
            using var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
            __httpRequest.Version = global::System.Net.HttpVersion.Version11;
            __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

            foreach (var __authorization in Authorizations)
            {
                if (__authorization.Type == "Http" ||
                    __authorization.Type == "OAuth2")
                {
                    __httpRequest.Headers.Authorization = new global::System.Net.Http.Headers.AuthenticationHeaderValue(
                        scheme: __authorization.Name,
                        parameter: __authorization.Value);
                }
                else if (__authorization.Type == "ApiKey" &&
                         __authorization.Location == "Header")
                {
                    __httpRequest.Headers.Add(__authorization.Name, __authorization.Value);
                }
            }
            var __httpRequestContentBody = request.ToJson(JsonSerializerContext);
            var __httpRequestContent = new global::System.Net.Http.StringContent(
                content: __httpRequestContentBody,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");
            __httpRequest.Content = __httpRequestContent;

            PrepareRequest(
                client: HttpClient,
                request: __httpRequest);
            PrepareCrawlUrlsRequest(
                httpClient: HttpClient,
                httpRequestMessage: __httpRequest,
                request: request);

            using var __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            ProcessResponse(
                client: HttpClient,
                response: __response);
            ProcessCrawlUrlsResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            // Payment required
            if ((int)__response.StatusCode == 402)
            {
                string? __content_402 = null;
                global::Firecrawl.CrawlUrlsResponse? __value_402 = null;
                if (ReadResponseAsString)
                {
                    __content_402 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_402 = global::Firecrawl.CrawlUrlsResponse.FromJson(__content_402, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_402 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_402 = await global::Firecrawl.CrawlUrlsResponse.FromJsonStreamAsync(__contentStream_402, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.CrawlUrlsResponse>(
                    message: __content_402 ?? __response.ReasonPhrase ?? string.Empty,
                    statusCode: __response.StatusCode)
                {
                    ResponseBody = __content_402,
                    ResponseObject = __value_402,
                    ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                        __response.Headers,
                        h => h.Key,
                        h => h.Value),
                };
            }
            // Too many requests
            if ((int)__response.StatusCode == 429)
            {
                string? __content_429 = null;
                global::Firecrawl.CrawlUrlsResponse2? __value_429 = null;
                if (ReadResponseAsString)
                {
                    __content_429 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_429 = global::Firecrawl.CrawlUrlsResponse2.FromJson(__content_429, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_429 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_429 = await global::Firecrawl.CrawlUrlsResponse2.FromJsonStreamAsync(__contentStream_429, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.CrawlUrlsResponse2>(
                    message: __content_429 ?? __response.ReasonPhrase ?? string.Empty,
                    statusCode: __response.StatusCode)
                {
                    ResponseBody = __content_429,
                    ResponseObject = __value_429,
                    ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                        __response.Headers,
                        h => h.Key,
                        h => h.Value),
                };
            }
            // Server error
            if ((int)__response.StatusCode == 500)
            {
                string? __content_500 = null;
                global::Firecrawl.CrawlUrlsResponse3? __value_500 = null;
                if (ReadResponseAsString)
                {
                    __content_500 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_500 = global::Firecrawl.CrawlUrlsResponse3.FromJson(__content_500, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_500 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_500 = await global::Firecrawl.CrawlUrlsResponse3.FromJsonStreamAsync(__contentStream_500, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.CrawlUrlsResponse3>(
                    message: __content_500 ?? __response.ReasonPhrase ?? string.Empty,
                    statusCode: __response.StatusCode)
                {
                    ResponseBody = __content_500,
                    ResponseObject = __value_500,
                    ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                        __response.Headers,
                        h => h.Key,
                        h => h.Value),
                };
            }

            if (ReadResponseAsString)
            {
                var __content = await __response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                    cancellationToken
#endif
                ).ConfigureAwait(false);

                ProcessResponseContent(
                    client: HttpClient,
                    response: __response,
                    content: ref __content);
                ProcessCrawlUrlsResponseContent(
                    httpClient: HttpClient,
                    httpResponseMessage: __response,
                    content: ref __content);

                try
                {
                    __response.EnsureSuccessStatusCode();
                }
                catch (global::System.Net.Http.HttpRequestException __ex)
                {
                    throw new global::Firecrawl.ApiException(
                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                        innerException: __ex,
                        statusCode: __response.StatusCode)
                    {
                        ResponseBody = __content,
                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                            __response.Headers,
                            h => h.Key,
                            h => h.Value),
                    };
                }

                return
                    global::Firecrawl.CrawlResponse.FromJson(__content, JsonSerializerContext) ??
                    throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
            }
            else
            {
                try
                {
                    __response.EnsureSuccessStatusCode();
                }
                catch (global::System.Net.Http.HttpRequestException __ex)
                {
                    throw new global::Firecrawl.ApiException(
                        message: __response.ReasonPhrase ?? string.Empty,
                        innerException: __ex,
                        statusCode: __response.StatusCode)
                    {
                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                            __response.Headers,
                            h => h.Key,
                            h => h.Value),
                    };
                }

                using var __content = await __response.Content.ReadAsStreamAsync(
#if NET5_0_OR_GREATER
                    cancellationToken
#endif
                ).ConfigureAwait(false);

                return
                    await global::Firecrawl.CrawlResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                    throw new global::System.InvalidOperationException("Response deserialization failed.");
            }
        }

        /// <summary>
        /// Crawl multiple URLs based on options
        /// </summary>
        /// <param name="url">
        /// The base URL to start crawling from
        /// </param>
        /// <param name="excludePaths">
        /// Specifies URL patterns to exclude from the crawl by comparing website paths against the provided regex patterns. For example, if you set "excludePaths": ["blog/*"] for the base URL firecrawl.dev, any results matching that pattern will be excluded, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </param>
        /// <param name="includePaths">
        /// Specifies URL patterns to include in the crawl by comparing website paths against the provided regex patterns. Only the paths that match the specified patterns will be included in the response. For example, if you set "includePaths": ["blog/*"] for the base URL firecrawl.dev, only results matching that pattern will be included, such as https://www.firecrawl.dev/blog/firecrawl-launch-week-1-recap.
        /// </param>
        /// <param name="maxDepth">
        /// Maximum depth to crawl relative to the entered URL.<br/>
        /// Default Value: 2
        /// </param>
        /// <param name="ignoreSitemap">
        /// Ignore the website sitemap when crawling<br/>
        /// Default Value: false
        /// </param>
        /// <param name="limit">
        /// Maximum number of pages to crawl. Default limit is 10000.<br/>
        /// Default Value: 10000
        /// </param>
        /// <param name="allowBackwardLinks">
        /// Enables the crawler to navigate from a specific URL to previously linked pages.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="allowExternalLinks">
        /// Allows the crawler to follow links to external websites.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="webhook"></param>
        /// <param name="scrapeOptions"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.CrawlResponse> CrawlUrlsAsync(
            string url,
            global::System.Collections.Generic.IList<string>? excludePaths = default,
            global::System.Collections.Generic.IList<string>? includePaths = default,
            int? maxDepth = default,
            bool? ignoreSitemap = default,
            int? limit = default,
            bool? allowBackwardLinks = default,
            bool? allowExternalLinks = default,
            global::Firecrawl.OneOf<string, global::Firecrawl.CrawlUrlsRequestWebhook>? webhook = default,
            global::Firecrawl.CrawlUrlsRequestScrapeOptions? scrapeOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Firecrawl.CrawlUrlsRequest
            {
                Url = url,
                ExcludePaths = excludePaths,
                IncludePaths = includePaths,
                MaxDepth = maxDepth,
                IgnoreSitemap = ignoreSitemap,
                Limit = limit,
                AllowBackwardLinks = allowBackwardLinks,
                AllowExternalLinks = allowExternalLinks,
                Webhook = webhook,
                ScrapeOptions = scrapeOptions,
            };

            return await CrawlUrlsAsync(
                request: __request,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}