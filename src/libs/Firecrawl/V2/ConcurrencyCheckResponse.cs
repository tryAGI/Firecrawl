using System.Text.Json.Serialization;

namespace Firecrawl.V2;

/// <summary>
/// Response payload from <c>GET /v2/concurrency-check</c>.
/// </summary>
public sealed class ConcurrencyCheckResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("concurrency")]
    public int Concurrency { get; set; }

    [JsonPropertyName("maxConcurrency")]
    public int MaxConcurrency { get; set; }
}
