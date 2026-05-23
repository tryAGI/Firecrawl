using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firecrawl.V2;

/// <summary>
/// A scraped document returned by v2 endpoints (<c>/v2/scrape</c>,
/// <c>/v2/parse</c>, <c>/v2/crawl</c>, <c>/v2/batch/scrape</c>).
///
/// <para>
/// This is a hand-written v2 model — v1 has its own
/// <see cref="ScrapeResponseData"/>. The fields differ; only use this when
/// calling endpoints exposed by <see cref="FirecrawlClient.V2"/>.
/// </para>
/// </summary>
public sealed class V2Document
{
    [JsonPropertyName("markdown")]
    public string? Markdown { get; set; }

    [JsonPropertyName("html")]
    public string? Html { get; set; }

    [JsonPropertyName("rawHtml")]
    public string? RawHtml { get; set; }

    [JsonPropertyName("json")]
    public JsonElement? Json { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, JsonElement>? Metadata { get; set; }

    [JsonPropertyName("links")]
    public IList<string>? Links { get; set; }

    [JsonPropertyName("images")]
    public IList<string>? Images { get; set; }

    [JsonPropertyName("screenshot")]
    public string? Screenshot { get; set; }

    [JsonPropertyName("video")]
    public string? Video { get; set; }

    [JsonPropertyName("warning")]
    public string? Warning { get; set; }
}

/// <summary>
/// Wraps responses of shape <c>{ "success": true, "data": T }</c> returned
/// by most v2 endpoints.
/// </summary>
/// <typeparam name="T">The payload type carried in the <c>data</c> field.</typeparam>
public sealed class V2ApiResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}
