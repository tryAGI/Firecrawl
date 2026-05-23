using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firecrawl.V2;

/// <summary>
/// Subset of v2 scrape options reused across <c>/v2/scrape</c> and
/// <c>/v2/parse</c>. <c>formats</c> is left as <see cref="JsonElement"/>
/// because v2 accepts either a string (<c>"markdown"</c>) or an object
/// (<c>{ "type": "json", "schema": {...} }</c>) per entry, and modeling it as
/// a typed polymorphic union would balloon the surface area beyond what we
/// need to round-trip values supplied by callers.
/// </summary>
public class V2ScrapeOptions
{
    [JsonPropertyName("formats")]
    public JsonElement? Formats { get; set; }

    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    [JsonPropertyName("includeTags")]
    public IList<string>? IncludeTags { get; set; }

    [JsonPropertyName("excludeTags")]
    public IList<string>? ExcludeTags { get; set; }

    [JsonPropertyName("onlyMainContent")]
    public bool? OnlyMainContent { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("parsers")]
    public JsonElement? Parsers { get; set; }

    [JsonPropertyName("skipTlsVerification")]
    public bool? SkipTlsVerification { get; set; }

    [JsonPropertyName("removeBase64Images")]
    public bool? RemoveBase64Images { get; set; }

    [JsonPropertyName("blockAds")]
    public bool? BlockAds { get; set; }

    [JsonPropertyName("proxy")]
    public string? Proxy { get; set; }

    [JsonPropertyName("integration")]
    public string? Integration { get; set; }
}

/// <summary>
/// Options accepted by <c>/v2/parse</c>. The endpoint rejects browser-only
/// formats (<c>changeTracking</c>, <c>screenshot</c>, <c>branding</c>) and
/// browser-only options (<c>actions</c>, <c>waitFor</c>, <c>location</c>,
/// <c>mobile</c>). Callers should restrict themselves to the inherited
/// <see cref="V2ScrapeOptions"/> surface.
/// </summary>
public sealed class ParseOptions : V2ScrapeOptions
{
}
