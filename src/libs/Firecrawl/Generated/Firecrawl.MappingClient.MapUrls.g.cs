
#nullable enable

namespace Firecrawl
{
    public partial class MappingClient
    {
        partial void PrepareMapUrlsArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Firecrawl.MapUrlsRequest request);
        partial void PrepareMapUrlsRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Firecrawl.MapUrlsRequest request);
        partial void ProcessMapUrlsResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessMapUrlsResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Map multiple URLs based on options
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.MapResponse> MapUrlsAsync(
            global::Firecrawl.MapUrlsRequest request,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareMapUrlsArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new PathBuilder(
                path: "/map",
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
            PrepareMapUrlsRequest(
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
            ProcessMapUrlsResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            // Payment required
            if ((int)__response.StatusCode == 402)
            {
                string? __content_402 = null;
                global::Firecrawl.MapUrlsResponse? __value_402 = null;
                if (ReadResponseAsString)
                {
                    __content_402 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_402 = global::Firecrawl.MapUrlsResponse.FromJson(__content_402, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_402 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_402 = await global::Firecrawl.MapUrlsResponse.FromJsonStreamAsync(__contentStream_402, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.MapUrlsResponse>(
                    message: __response.ReasonPhrase ?? string.Empty,
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
                global::Firecrawl.MapUrlsResponse2? __value_429 = null;
                if (ReadResponseAsString)
                {
                    __content_429 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_429 = global::Firecrawl.MapUrlsResponse2.FromJson(__content_429, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_429 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_429 = await global::Firecrawl.MapUrlsResponse2.FromJsonStreamAsync(__contentStream_429, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.MapUrlsResponse2>(
                    message: __response.ReasonPhrase ?? string.Empty,
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
                global::Firecrawl.MapUrlsResponse3? __value_500 = null;
                if (ReadResponseAsString)
                {
                    __content_500 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_500 = global::Firecrawl.MapUrlsResponse3.FromJson(__content_500, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_500 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_500 = await global::Firecrawl.MapUrlsResponse3.FromJsonStreamAsync(__contentStream_500, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.MapUrlsResponse3>(
                    message: __response.ReasonPhrase ?? string.Empty,
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
                var __content = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

                ProcessResponseContent(
                    client: HttpClient,
                    response: __response,
                    content: ref __content);
                ProcessMapUrlsResponseContent(
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
                    global::Firecrawl.MapResponse.FromJson(__content, JsonSerializerContext) ??
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

                using var __content = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

                return
                    await global::Firecrawl.MapResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                    throw new global::System.InvalidOperationException("Response deserialization failed.");
            }
        }

        /// <summary>
        /// Map multiple URLs based on options
        /// </summary>
        /// <param name="url">
        /// The base URL to start crawling from
        /// </param>
        /// <param name="search">
        /// Search query to use for mapping. During the Alpha phase, the 'smart' part of the search functionality is limited to 1000 search results. However, if map finds more results, there is no limit applied.
        /// </param>
        /// <param name="ignoreSitemap">
        /// Ignore the website sitemap when crawling.<br/>
        /// Default Value: true
        /// </param>
        /// <param name="sitemapOnly">
        /// Only return links found in the website sitemap<br/>
        /// Default Value: false
        /// </param>
        /// <param name="includeSubdomains">
        /// Include subdomains of the website<br/>
        /// Default Value: false
        /// </param>
        /// <param name="limit">
        /// Maximum number of links to return<br/>
        /// Default Value: 5000
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.MapResponse> MapUrlsAsync(
            string url,
            string? search = default,
            bool? ignoreSitemap = default,
            bool? sitemapOnly = default,
            bool? includeSubdomains = default,
            int? limit = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Firecrawl.MapUrlsRequest
            {
                Url = url,
                Search = search,
                IgnoreSitemap = ignoreSitemap,
                SitemapOnly = sitemapOnly,
                IncludeSubdomains = includeSubdomains,
                Limit = limit,
            };

            return await MapUrlsAsync(
                request: __request,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}