using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Firecrawl.V2;

/// <summary>
/// Entry point for endpoints exposed only by the Firecrawl v2 API
/// (parse, monitor, concurrency-check, historical usage). Reuses the
/// <see cref="HttpClient"/> and <c>Authorization</c> header of the parent
/// <see cref="FirecrawlClient"/>, but rewrites the <c>/v1</c> base path
/// to <c>/v2</c> on every call.
///
/// <para>
/// The generated v1 client has no knowledge of these endpoints — the
/// Firecrawl team has not published an OpenAPI definition for v2 — so this
/// layer is hand-written. It is opt-in: callers reach it through
/// <see cref="FirecrawlClient.V2"/>.
/// </para>
/// </summary>
public sealed class V2Client
{
    private const string V1Suffix = "/v1";
    private const string V2Suffix = "/v2";

    private readonly HttpClient _httpClient;
    private readonly Uri _v2BaseAddress;

    /// <summary>
    /// Creates a v2 wrapper around an existing HttpClient configured with
    /// a Firecrawl base address (with or without the <c>/v1</c> suffix) and
    /// the <c>Authorization</c> header.
    /// </summary>
    public V2Client(HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        if (httpClient.BaseAddress is null)
        {
            throw new ArgumentException(
                "HttpClient.BaseAddress must be set before creating a V2Client.",
                nameof(httpClient));
        }

        _httpClient = httpClient;
        _v2BaseAddress = RebaseToV2(httpClient.BaseAddress);
    }

    internal static Uri RebaseToV2(Uri baseAddress)
    {
        var raw = baseAddress.AbsoluteUri.TrimEnd('/');
        if (raw.EndsWith(V1Suffix, StringComparison.OrdinalIgnoreCase))
        {
            raw = string.Concat(raw.AsSpan(0, raw.Length - V1Suffix.Length), V2Suffix);
        }
        else if (!raw.EndsWith(V2Suffix, StringComparison.OrdinalIgnoreCase))
        {
            raw += V2Suffix;
        }
        return new Uri(raw + "/", UriKind.Absolute);
    }

    // ──────────────── Parse ────────────────

    /// <summary>
    /// <c>POST /v2/parse</c> — uploads a file via multipart form-data and
    /// returns the extracted document. Pair with <see cref="AutoSDKUploadFile.FromPath"/>,
    /// <see cref="AutoSDKUploadFile.FromBytes(string, byte[], string?)"/>, or
    /// <see cref="AutoSDKUploadFile.FromStream"/>.
    /// </summary>
    public async Task<V2Document> ParseAsync(
        AutoSDKUploadFile file,
        ParseOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(file);

        using var content = new MultipartFormDataContent();
        var optionsJson = JsonSerializer.Serialize(
            options ?? new ParseOptions(),
            V2SourceGenerationContext.Default.ParseOptions);
        var optionsContent = new StringContent(optionsJson, Encoding.UTF8);
        optionsContent.Headers.ContentType = null;
        content.Add(optionsContent, "options");
        content.Add(file.ToHttpContent("file"));

        using var request = new HttpRequestMessage(HttpMethod.Post, AbsoluteUri("parse"))
        {
            Content = content,
        };
        CopyAuthorization(request);

        var response = await SendAsync<V2ApiResponse<V2Document>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseV2Document,
            cancellationToken).ConfigureAwait(false);

        return response.Data
            ?? throw new InvalidOperationException("Parse response contained no data.");
    }

    // ──────────────── Concurrency check ────────────────

    /// <summary>
    /// <c>GET /v2/concurrency-check</c>.
    /// </summary>
    public async Task<ConcurrencyCheckResponse> GetConcurrencyAsync(
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, AbsoluteUri("concurrency-check"));
        CopyAuthorization(request);
        return await SendAsync<ConcurrencyCheckResponse>(
            request,
            V2SourceGenerationContext.Default.ConcurrencyCheckResponse,
            cancellationToken).ConfigureAwait(false);
    }

    // ──────────────── Historical usage ────────────────

    /// <summary>
    /// <c>GET /v2/team/credit-usage/historical</c>.
    /// </summary>
    public Task<HistoricalUsageResponse> GetCreditUsageHistoricalAsync(
        CancellationToken cancellationToken = default)
        => GetHistoricalAsync("team/credit-usage/historical", cancellationToken);

    /// <summary>
    /// <c>GET /v2/team/token-usage/historical</c>.
    /// </summary>
    public Task<HistoricalUsageResponse> GetTokenUsageHistoricalAsync(
        CancellationToken cancellationToken = default)
        => GetHistoricalAsync("team/token-usage/historical", cancellationToken);

    private async Task<HistoricalUsageResponse> GetHistoricalAsync(
        string path,
        CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, AbsoluteUri(path));
        CopyAuthorization(request);
        return await SendAsync<HistoricalUsageResponse>(
            request,
            V2SourceGenerationContext.Default.HistoricalUsageResponse,
            cancellationToken).ConfigureAwait(false);
    }

    // ──────────────── Monitor CRUD ────────────────

    /// <summary>
    /// <c>POST /v2/monitor</c>.
    /// </summary>
    public async Task<Monitor> CreateMonitorAsync(
        CreateMonitorRequest body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(body);
        var response = await PostJsonAsync<CreateMonitorRequest, V2ApiResponse<Monitor>>(
            "monitor",
            body,
            V2SourceGenerationContext.Default.CreateMonitorRequest,
            V2SourceGenerationContext.Default.V2ApiResponseMonitor,
            cancellationToken).ConfigureAwait(false);
        return response.Data
            ?? throw new InvalidOperationException("Create monitor returned no data.");
    }

    /// <summary>
    /// <c>GET /v2/monitor</c>.
    /// </summary>
    public async Task<IList<Monitor>> ListMonitorsAsync(
        int? limit = null,
        int? offset = null,
        CancellationToken cancellationToken = default)
    {
        var path = AppendQuery("monitor", limit, offset, status: null);
        using var request = new HttpRequestMessage(HttpMethod.Get, AbsoluteUri(path));
        CopyAuthorization(request);
        var response = await SendAsync<V2ApiResponse<IList<Monitor>>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseIListMonitor,
            cancellationToken).ConfigureAwait(false);
        return response.Data ?? new List<Monitor>();
    }

    /// <summary>
    /// <c>GET /v2/monitor/{id}</c>.
    /// </summary>
    public async Task<Monitor> GetMonitorAsync(
        string monitorId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(monitorId))
            throw new ArgumentException("monitorId cannot be empty.", nameof(monitorId));

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            AbsoluteUri($"monitor/{Uri.EscapeDataString(monitorId)}"));
        CopyAuthorization(request);
        var response = await SendAsync<V2ApiResponse<Monitor>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseMonitor,
            cancellationToken).ConfigureAwait(false);
        return response.Data
            ?? throw new InvalidOperationException("Get monitor returned no data.");
    }

    /// <summary>
    /// <c>PATCH /v2/monitor/{id}</c>.
    /// </summary>
    public async Task<Monitor> UpdateMonitorAsync(
        string monitorId,
        UpdateMonitorRequest body,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(monitorId))
            throw new ArgumentException("monitorId cannot be empty.", nameof(monitorId));
        ArgumentNullException.ThrowIfNull(body);

        var json = JsonSerializer.Serialize(body, V2SourceGenerationContext.Default.UpdateMonitorRequest);
        using var request = new HttpRequestMessage(
            HttpMethod.Patch,
            AbsoluteUri($"monitor/{Uri.EscapeDataString(monitorId)}"))
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
        };
        CopyAuthorization(request);
        var response = await SendAsync<V2ApiResponse<Monitor>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseMonitor,
            cancellationToken).ConfigureAwait(false);
        return response.Data
            ?? throw new InvalidOperationException("Update monitor returned no data.");
    }

    /// <summary>
    /// <c>DELETE /v2/monitor/{id}</c>.
    /// </summary>
    public async Task<bool> DeleteMonitorAsync(
        string monitorId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(monitorId))
            throw new ArgumentException("monitorId cannot be empty.", nameof(monitorId));

        using var request = new HttpRequestMessage(
            HttpMethod.Delete,
            AbsoluteUri($"monitor/{Uri.EscapeDataString(monitorId)}"));
        CopyAuthorization(request);
        var response = await SendAsync<V2ApiResponse<Dictionary<string, JsonElement>>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseDictionaryStringJsonElement,
            cancellationToken).ConfigureAwait(false);
        return response.Success;
    }

    /// <summary>
    /// <c>POST /v2/monitor/{id}/run</c>.
    /// </summary>
    public async Task<MonitorCheck> RunMonitorAsync(
        string monitorId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(monitorId))
            throw new ArgumentException("monitorId cannot be empty.", nameof(monitorId));

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            AbsoluteUri($"monitor/{Uri.EscapeDataString(monitorId)}/run"))
        {
            Content = new StringContent("{}", Encoding.UTF8, "application/json"),
        };
        CopyAuthorization(request);
        var response = await SendAsync<V2ApiResponse<MonitorCheck>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseMonitorCheck,
            cancellationToken).ConfigureAwait(false);
        return response.Data
            ?? throw new InvalidOperationException("Run monitor returned no data.");
    }

    /// <summary>
    /// <c>GET /v2/monitor/{id}/checks</c>.
    /// </summary>
    public async Task<IList<MonitorCheck>> ListMonitorChecksAsync(
        string monitorId,
        int? limit = null,
        int? offset = null,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(monitorId))
            throw new ArgumentException("monitorId cannot be empty.", nameof(monitorId));

        var path = AppendQuery(
            $"monitor/{Uri.EscapeDataString(monitorId)}/checks",
            limit, offset, status: null);
        using var request = new HttpRequestMessage(HttpMethod.Get, AbsoluteUri(path));
        CopyAuthorization(request);
        var response = await SendAsync<V2ApiResponse<IList<MonitorCheck>>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseIListMonitorCheck,
            cancellationToken).ConfigureAwait(false);
        return response.Data ?? new List<MonitorCheck>();
    }

    /// <summary>
    /// <c>GET /v2/monitor/{id}/checks/{checkId}</c>. Walks the <c>next</c>
    /// pagination chain automatically when <paramref name="autoPaginate"/>
    /// is <see langword="true"/>.
    /// </summary>
    public async Task<MonitorCheckDetail> GetMonitorCheckAsync(
        string monitorId,
        string checkId,
        int? limit = null,
        int? skip = null,
        string? status = null,
        bool autoPaginate = true,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(monitorId))
            throw new ArgumentException("monitorId cannot be empty.", nameof(monitorId));
        if (string.IsNullOrWhiteSpace(checkId))
            throw new ArgumentException("checkId cannot be empty.", nameof(checkId));

        var path = AppendQuery(
            $"monitor/{Uri.EscapeDataString(monitorId)}/checks/{Uri.EscapeDataString(checkId)}",
            limit, skip, status);

        using var request = new HttpRequestMessage(HttpMethod.Get, AbsoluteUri(path));
        CopyAuthorization(request);
        var response = await SendAsync<V2ApiResponse<MonitorCheckDetail>>(
            request,
            V2SourceGenerationContext.Default.V2ApiResponseMonitorCheckDetail,
            cancellationToken).ConfigureAwait(false);
        var check = response.Data
            ?? throw new InvalidOperationException("Get monitor check returned no data.");

        return autoPaginate
            ? await PaginateAsync(check, cancellationToken).ConfigureAwait(false)
            : check;
    }

    private async Task<MonitorCheckDetail> PaginateAsync(
        MonitorCheckDetail check,
        CancellationToken cancellationToken)
    {
        check.Pages ??= new List<MonitorCheckPage>();
        var next = check.Next;

        while (!string.IsNullOrEmpty(next))
        {
            cancellationToken.ThrowIfCancellationRequested();
            AutoSDKPager.EnsureSameOrigin(next, _httpClient.BaseAddress);

            using var request = new HttpRequestMessage(HttpMethod.Get, next);
            CopyAuthorization(request);
            var page = await SendAsync<V2ApiResponse<MonitorCheckDetail>>(
                request,
                V2SourceGenerationContext.Default.V2ApiResponseMonitorCheckDetail,
                cancellationToken).ConfigureAwait(false);

            if (page.Data is { Pages: { Count: > 0 } pages })
            {
                foreach (var p in pages)
                {
                    check.Pages.Add(p);
                }
            }

            next = page.Data?.Next;
        }

        check.Next = null;
        return check;
    }

    // ──────────────── HTTP plumbing ────────────────

    private Uri AbsoluteUri(string relativePath)
        => new(_v2BaseAddress, relativePath);

    private void CopyAuthorization(HttpRequestMessage request)
    {
        if (_httpClient.DefaultRequestHeaders.Authorization is { } auth)
        {
            request.Headers.Authorization = auth;
        }
    }

    private static string AppendQuery(string path, int? limit, int? offset, string? status)
    {
        var parts = new List<string>(3);
        if (limit.HasValue)
            parts.Add($"limit={limit.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        if (offset.HasValue)
            parts.Add($"offset={offset.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        if (!string.IsNullOrWhiteSpace(status))
            parts.Add($"status={Uri.EscapeDataString(status)}");
        return parts.Count == 0 ? path : path + "?" + string.Join("&", parts);
    }

    private async Task<T> PostJsonAsync<TBody, T>(
        string path,
        TBody body,
        System.Text.Json.Serialization.Metadata.JsonTypeInfo<TBody> bodyInfo,
        System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> responseInfo,
        CancellationToken cancellationToken)
        where T : class
    {
        var json = JsonSerializer.Serialize(body, bodyInfo);
        using var request = new HttpRequestMessage(HttpMethod.Post, AbsoluteUri(path))
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
        };
        CopyAuthorization(request);
        return await SendAsync(request, responseInfo, cancellationToken).ConfigureAwait(false);
    }

    private async Task<T> SendAsync<T>(
        HttpRequestMessage request,
        System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> typeInfo,
        CancellationToken cancellationToken)
        where T : class
    {
        using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

        var content = await response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
            cancellationToken
#endif
            ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw ApiException.Create(
                statusCode: response.StatusCode,
                message: string.IsNullOrEmpty(content) ? (response.ReasonPhrase ?? string.Empty) : content,
                innerException: null,
                responseBody: content,
                responseHeaders: System.Linq.Enumerable.ToDictionary(
                    response.Headers,
                    h => h.Key,
                    h => h.Value));
        }

        return JsonSerializer.Deserialize(content, typeInfo)
            ?? throw new InvalidOperationException(
                $"Failed to deserialize v2 response of type {typeof(T).Name}.");
    }
}
