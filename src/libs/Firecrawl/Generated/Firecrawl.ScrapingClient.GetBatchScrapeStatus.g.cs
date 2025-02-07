
#nullable enable

namespace Firecrawl
{
    public partial class ScrapingClient
    {
        partial void PrepareGetBatchScrapeStatusArguments(
            global::System.Net.Http.HttpClient httpClient);
        partial void PrepareGetBatchScrapeStatusRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage);
        partial void ProcessGetBatchScrapeStatusResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessGetBatchScrapeStatusResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Get the status of a batch scrape job
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.BatchScrapeStatusResponseObj> GetBatchScrapeStatusAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            PrepareArguments(
                client: HttpClient);
            PrepareGetBatchScrapeStatusArguments(
                httpClient: HttpClient);

            var __pathBuilder = new PathBuilder(
                path: "/batch/scrape/{id}",
                baseUri: HttpClient.BaseAddress); 
            var __path = __pathBuilder.ToString();
            using var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Get,
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

            PrepareRequest(
                client: HttpClient,
                request: __httpRequest);
            PrepareGetBatchScrapeStatusRequest(
                httpClient: HttpClient,
                httpRequestMessage: __httpRequest);

            using var __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            ProcessResponse(
                client: HttpClient,
                response: __response);
            ProcessGetBatchScrapeStatusResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            // Payment required
            if ((int)__response.StatusCode == 402)
            {
                string? __content_402 = null;
                global::Firecrawl.GetBatchScrapeStatusResponse? __value_402 = null;
                if (ReadResponseAsString)
                {
                    __content_402 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_402 = global::Firecrawl.GetBatchScrapeStatusResponse.FromJson(__content_402, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_402 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_402 = await global::Firecrawl.GetBatchScrapeStatusResponse.FromJsonStreamAsync(__contentStream_402, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.GetBatchScrapeStatusResponse>(
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
                global::Firecrawl.GetBatchScrapeStatusResponse2? __value_429 = null;
                if (ReadResponseAsString)
                {
                    __content_429 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_429 = global::Firecrawl.GetBatchScrapeStatusResponse2.FromJson(__content_429, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_429 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_429 = await global::Firecrawl.GetBatchScrapeStatusResponse2.FromJsonStreamAsync(__contentStream_429, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.GetBatchScrapeStatusResponse2>(
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
                global::Firecrawl.GetBatchScrapeStatusResponse3? __value_500 = null;
                if (ReadResponseAsString)
                {
                    __content_500 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    __value_500 = global::Firecrawl.GetBatchScrapeStatusResponse3.FromJson(__content_500, JsonSerializerContext);
                }
                else
                {
                    var __contentStream_500 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                    __value_500 = await global::Firecrawl.GetBatchScrapeStatusResponse3.FromJsonStreamAsync(__contentStream_500, JsonSerializerContext).ConfigureAwait(false);
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.GetBatchScrapeStatusResponse3>(
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
                var __content = await __response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                    cancellationToken
#endif
                ).ConfigureAwait(false);

                ProcessResponseContent(
                    client: HttpClient,
                    response: __response,
                    content: ref __content);
                ProcessGetBatchScrapeStatusResponseContent(
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
                    global::Firecrawl.BatchScrapeStatusResponseObj.FromJson(__content, JsonSerializerContext) ??
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
                    await global::Firecrawl.BatchScrapeStatusResponseObj.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                    throw new global::System.InvalidOperationException("Response deserialization failed.");
            }
        }
    }
}