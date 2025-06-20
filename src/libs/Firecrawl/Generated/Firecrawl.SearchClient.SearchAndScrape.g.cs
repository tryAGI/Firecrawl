
#nullable enable

namespace Firecrawl
{
    public partial class SearchClient
    {
        partial void PrepareSearchAndScrapeArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Firecrawl.SearchAndScrapeRequest request);
        partial void PrepareSearchAndScrapeRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Firecrawl.SearchAndScrapeRequest request);
        partial void ProcessSearchAndScrapeResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessSearchAndScrapeResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Search and optionally scrape search results
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.SearchAndScrapeResponse> SearchAndScrapeAsync(
            global::Firecrawl.SearchAndScrapeRequest request,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareSearchAndScrapeArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Firecrawl.PathBuilder(
                path: "/search",
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
            PrepareSearchAndScrapeRequest(
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
            ProcessSearchAndScrapeResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            // Request timeout
            if ((int)__response.StatusCode == 408)
            {
                string? __content_408 = null;
                global::System.Exception? __exception_408 = null;
                global::Firecrawl.SearchAndScrapeResponse2? __value_408 = null;
                try
                {
                    if (ReadResponseAsString)
                    {
                        __content_408 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        __value_408 = global::Firecrawl.SearchAndScrapeResponse2.FromJson(__content_408, JsonSerializerContext);
                    }
                    else
                    {
                        var __contentStream_408 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        __value_408 = await global::Firecrawl.SearchAndScrapeResponse2.FromJsonStreamAsync(__contentStream_408, JsonSerializerContext).ConfigureAwait(false);
                    }
                }
                catch (global::System.Exception __ex)
                {
                    __exception_408 = __ex;
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.SearchAndScrapeResponse2>(
                    message: __content_408 ?? __response.ReasonPhrase ?? string.Empty,
                    innerException: __exception_408,
                    statusCode: __response.StatusCode)
                {
                    ResponseBody = __content_408,
                    ResponseObject = __value_408,
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
                global::System.Exception? __exception_500 = null;
                global::Firecrawl.SearchAndScrapeResponse3? __value_500 = null;
                try
                {
                    if (ReadResponseAsString)
                    {
                        __content_500 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        __value_500 = global::Firecrawl.SearchAndScrapeResponse3.FromJson(__content_500, JsonSerializerContext);
                    }
                    else
                    {
                        var __contentStream_500 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        __value_500 = await global::Firecrawl.SearchAndScrapeResponse3.FromJsonStreamAsync(__contentStream_500, JsonSerializerContext).ConfigureAwait(false);
                    }
                }
                catch (global::System.Exception __ex)
                {
                    __exception_500 = __ex;
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.SearchAndScrapeResponse3>(
                    message: __content_500 ?? __response.ReasonPhrase ?? string.Empty,
                    innerException: __exception_500,
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
                ProcessSearchAndScrapeResponseContent(
                    httpClient: HttpClient,
                    httpResponseMessage: __response,
                    content: ref __content);

                try
                {
                    __response.EnsureSuccessStatusCode();

                    return
                        global::Firecrawl.SearchAndScrapeResponse.FromJson(__content, JsonSerializerContext) ??
                        throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
                }
                catch (global::System.Exception __ex)
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
            }
            else
            {
                try
                {
                    __response.EnsureSuccessStatusCode();

                    using var __content = await __response.Content.ReadAsStreamAsync(
#if NET5_0_OR_GREATER
                        cancellationToken
#endif
                    ).ConfigureAwait(false);

                    return
                        await global::Firecrawl.SearchAndScrapeResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                        throw new global::System.InvalidOperationException("Response deserialization failed.");
                }
                catch (global::System.Exception __ex)
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
            }
        }

        /// <summary>
        /// Search and optionally scrape search results
        /// </summary>
        /// <param name="query">
        /// The search query
        /// </param>
        /// <param name="limit">
        /// Maximum number of results to return<br/>
        /// Default Value: 5
        /// </param>
        /// <param name="tbs">
        /// Time-based search parameter
        /// </param>
        /// <param name="location">
        /// Location parameter for search results
        /// </param>
        /// <param name="timeout">
        /// Timeout in milliseconds<br/>
        /// Default Value: 60000
        /// </param>
        /// <param name="ignoreInvalidURLs">
        /// Excludes URLs from the search results that are invalid for other Firecrawl endpoints. This helps reduce errors if you are piping data from search into other Firecrawl API endpoints.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="scrapeOptions">
        /// Options for scraping search results
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.SearchAndScrapeResponse> SearchAndScrapeAsync(
            string query,
            int? limit = default,
            string? tbs = default,
            string? location = default,
            int? timeout = default,
            bool? ignoreInvalidURLs = default,
            global::Firecrawl.SearchAndScrapeRequestScrapeOptions? scrapeOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Firecrawl.SearchAndScrapeRequest
            {
                Query = query,
                Limit = limit,
                Tbs = tbs,
                Location = location,
                Timeout = timeout,
                IgnoreInvalidURLs = ignoreInvalidURLs,
                ScrapeOptions = scrapeOptions,
            };

            return await SearchAndScrapeAsync(
                request: __request,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}