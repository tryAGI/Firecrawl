
#nullable enable

namespace Firecrawl
{
    public partial class ScrapingClient
    {
        partial void PrepareScrapeAndExtractFromUrlArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Firecrawl.ScrapeAndExtractFromUrlRequest request);
        partial void PrepareScrapeAndExtractFromUrlRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Firecrawl.ScrapeAndExtractFromUrlRequest request);
        partial void ProcessScrapeAndExtractFromUrlResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessScrapeAndExtractFromUrlResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Scrape a single URL and optionally extract information using an LLM
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAndExtractFromUrlAsync(
            global::Firecrawl.ScrapeAndExtractFromUrlRequest request,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareScrapeAndExtractFromUrlArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Firecrawl.PathBuilder(
                path: "/scrape",
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
            PrepareScrapeAndExtractFromUrlRequest(
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
            ProcessScrapeAndExtractFromUrlResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            // Payment required
            if ((int)__response.StatusCode == 402)
            {
                string? __content_402 = null;
                global::System.Exception? __exception_402 = null;
                global::Firecrawl.ScrapeAndExtractFromUrlResponse? __value_402 = null;
                try
                {
                    if (ReadResponseAsString)
                    {
                        __content_402 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        __value_402 = global::Firecrawl.ScrapeAndExtractFromUrlResponse.FromJson(__content_402, JsonSerializerContext);
                    }
                    else
                    {
                        var __contentStream_402 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        __value_402 = await global::Firecrawl.ScrapeAndExtractFromUrlResponse.FromJsonStreamAsync(__contentStream_402, JsonSerializerContext).ConfigureAwait(false);
                    }
                }
                catch (global::System.Exception __ex)
                {
                    __exception_402 = __ex;
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.ScrapeAndExtractFromUrlResponse>(
                    message: __content_402 ?? __response.ReasonPhrase ?? string.Empty,
                    innerException: __exception_402,
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
                global::System.Exception? __exception_429 = null;
                global::Firecrawl.ScrapeAndExtractFromUrlResponse2? __value_429 = null;
                try
                {
                    if (ReadResponseAsString)
                    {
                        __content_429 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        __value_429 = global::Firecrawl.ScrapeAndExtractFromUrlResponse2.FromJson(__content_429, JsonSerializerContext);
                    }
                    else
                    {
                        var __contentStream_429 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        __value_429 = await global::Firecrawl.ScrapeAndExtractFromUrlResponse2.FromJsonStreamAsync(__contentStream_429, JsonSerializerContext).ConfigureAwait(false);
                    }
                }
                catch (global::System.Exception __ex)
                {
                    __exception_429 = __ex;
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.ScrapeAndExtractFromUrlResponse2>(
                    message: __content_429 ?? __response.ReasonPhrase ?? string.Empty,
                    innerException: __exception_429,
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
                global::System.Exception? __exception_500 = null;
                global::Firecrawl.ScrapeAndExtractFromUrlResponse3? __value_500 = null;
                try
                {
                    if (ReadResponseAsString)
                    {
                        __content_500 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        __value_500 = global::Firecrawl.ScrapeAndExtractFromUrlResponse3.FromJson(__content_500, JsonSerializerContext);
                    }
                    else
                    {
                        var __contentStream_500 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        __value_500 = await global::Firecrawl.ScrapeAndExtractFromUrlResponse3.FromJsonStreamAsync(__contentStream_500, JsonSerializerContext).ConfigureAwait(false);
                    }
                }
                catch (global::System.Exception __ex)
                {
                    __exception_500 = __ex;
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.ScrapeAndExtractFromUrlResponse3>(
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
                ProcessScrapeAndExtractFromUrlResponseContent(
                    httpClient: HttpClient,
                    httpResponseMessage: __response,
                    content: ref __content);

                try
                {
                    __response.EnsureSuccessStatusCode();

                    return
                        global::Firecrawl.ScrapeResponse.FromJson(__content, JsonSerializerContext) ??
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
                        await global::Firecrawl.ScrapeResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
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
        /// Scrape a single URL and optionally extract information using an LLM
        /// </summary>
        /// <param name="url">
        /// The URL to scrape
        /// </param>
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
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.ScrapeResponse> ScrapeAndExtractFromUrlAsync(
            string url,
            global::System.Collections.Generic.IList<global::Firecrawl.ScrapeAndExtractFromUrlRequestFormat>? formats = default,
            bool? onlyMainContent = default,
            global::System.Collections.Generic.IList<string>? includeTags = default,
            global::System.Collections.Generic.IList<string>? excludeTags = default,
            object? headers = default,
            int? waitFor = default,
            bool? mobile = default,
            bool? skipTlsVerification = default,
            int? timeout = default,
            global::Firecrawl.ScrapeAndExtractFromUrlRequestExtract? extract = default,
            global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant1, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant2, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant4, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant5, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant6, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant7, global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant8>>? actions = default,
            global::Firecrawl.ScrapeAndExtractFromUrlRequestLocation? location = default,
            bool? removeBase64Images = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Firecrawl.ScrapeAndExtractFromUrlRequest
            {
                Url = url,
                Formats = formats,
                OnlyMainContent = onlyMainContent,
                IncludeTags = includeTags,
                ExcludeTags = excludeTags,
                Headers = headers,
                WaitFor = waitFor,
                Mobile = mobile,
                SkipTlsVerification = skipTlsVerification,
                Timeout = timeout,
                Extract = extract,
                Actions = actions,
                Location = location,
                RemoveBase64Images = removeBase64Images,
            };

            return await ScrapeAndExtractFromUrlAsync(
                request: __request,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}