using System.Text.Json.Serialization;

namespace Firecrawl.V2;

/// <summary>
/// One bucket in a historical usage time series.
/// </summary>
public sealed class HistoricalUsageBucket
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("credits")]
    public long? Credits { get; set; }

    [JsonPropertyName("tokens")]
    public long? Tokens { get; set; }
}

/// <summary>
/// Response payload from <c>GET /v2/team/credit-usage/historical</c>
/// and <c>GET /v2/team/token-usage/historical</c>.
/// </summary>
public sealed class HistoricalUsageResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("data")]
    public IList<HistoricalUsageBucket>? Data { get; set; }
}
