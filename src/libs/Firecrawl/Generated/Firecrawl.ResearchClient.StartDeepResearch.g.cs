
#nullable enable

namespace Firecrawl
{
    public partial class ResearchClient
    {
        partial void PrepareStartDeepResearchArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Firecrawl.StartDeepResearchRequest request);
        partial void PrepareStartDeepResearchRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Firecrawl.StartDeepResearchRequest request);
        partial void ProcessStartDeepResearchResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessStartDeepResearchResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Start a deep research operation on a query
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Firecrawl.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.StartDeepResearchResponse> StartDeepResearchAsync(
            global::Firecrawl.StartDeepResearchRequest request,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareStartDeepResearchArguments(
                httpClient: HttpClient,
                request: request);

            var __pathBuilder = new global::Firecrawl.PathBuilder(
                path: "/deep-research",
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
            PrepareStartDeepResearchRequest(
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
            ProcessStartDeepResearchResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            // Invalid request parameters
            if ((int)__response.StatusCode == 400)
            {
                string? __content_400 = null;
                global::System.Exception? __exception_400 = null;
                global::Firecrawl.StartDeepResearchResponse2? __value_400 = null;
                try
                {
                    if (ReadResponseAsString)
                    {
                        __content_400 = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        __value_400 = global::Firecrawl.StartDeepResearchResponse2.FromJson(__content_400, JsonSerializerContext);
                    }
                    else
                    {
                        var __contentStream_400 = await __response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                        __value_400 = await global::Firecrawl.StartDeepResearchResponse2.FromJsonStreamAsync(__contentStream_400, JsonSerializerContext).ConfigureAwait(false);
                    }
                }
                catch (global::System.Exception __ex)
                {
                    __exception_400 = __ex;
                }

                throw new global::Firecrawl.ApiException<global::Firecrawl.StartDeepResearchResponse2>(
                    message: __content_400 ?? __response.ReasonPhrase ?? string.Empty,
                    innerException: __exception_400,
                    statusCode: __response.StatusCode)
                {
                    ResponseBody = __content_400,
                    ResponseObject = __value_400,
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
                ProcessStartDeepResearchResponseContent(
                    httpClient: HttpClient,
                    httpResponseMessage: __response,
                    content: ref __content);

                try
                {
                    __response.EnsureSuccessStatusCode();

                    return
                        global::Firecrawl.StartDeepResearchResponse.FromJson(__content, JsonSerializerContext) ??
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
                        await global::Firecrawl.StartDeepResearchResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
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
        /// Start a deep research operation on a query
        /// </summary>
        /// <param name="query">
        /// The query to research
        /// </param>
        /// <param name="maxDepth">
        /// Maximum depth of research iterations<br/>
        /// Default Value: 7
        /// </param>
        /// <param name="timeLimit">
        /// Time limit in seconds<br/>
        /// Default Value: 300
        /// </param>
        /// <param name="maxUrls">
        /// Maximum number of URLs to analyze<br/>
        /// Default Value: 20
        /// </param>
        /// <param name="analysisPrompt">
        /// The prompt to use for the final analysis. Useful to format the final analysis markdown in a specific way.
        /// </param>
        /// <param name="systemPrompt">
        /// The system prompt to use for the research agent. Useful to steer the research agent to a specific direction.
        /// </param>
        /// <param name="formats"></param>
        /// <param name="jsonOptions">
        /// Options for JSON output
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Firecrawl.StartDeepResearchResponse> StartDeepResearchAsync(
            string query,
            int? maxDepth = default,
            int? timeLimit = default,
            int? maxUrls = default,
            string? analysisPrompt = default,
            string? systemPrompt = default,
            global::System.Collections.Generic.IList<global::Firecrawl.StartDeepResearchRequestFormat>? formats = default,
            global::Firecrawl.StartDeepResearchRequestJsonOptions? jsonOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Firecrawl.StartDeepResearchRequest
            {
                Query = query,
                MaxDepth = maxDepth,
                TimeLimit = timeLimit,
                MaxUrls = maxUrls,
                AnalysisPrompt = analysisPrompt,
                SystemPrompt = systemPrompt,
                Formats = formats,
                JsonOptions = jsonOptions,
            };

            return await StartDeepResearchAsync(
                request: __request,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}