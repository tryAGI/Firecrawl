using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firecrawl.V2;

/// <summary>
/// Source-generated JSON serializer context for v2-only models. Kept
/// separate from <see cref="SourceGenerationContext"/> so the v1 codegen
/// can be regenerated freely without disturbing hand-written v2 types.
/// </summary>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(V2Document))]
[JsonSerializable(typeof(V2ApiResponse<V2Document>))]
[JsonSerializable(typeof(V2ApiResponse<Monitor>))]
[JsonSerializable(typeof(V2ApiResponse<IList<Monitor>>))]
[JsonSerializable(typeof(V2ApiResponse<MonitorCheck>))]
[JsonSerializable(typeof(V2ApiResponse<IList<MonitorCheck>>))]
[JsonSerializable(typeof(V2ApiResponse<MonitorCheckDetail>))]
[JsonSerializable(typeof(V2ApiResponse<Dictionary<string, JsonElement>>))]
[JsonSerializable(typeof(ConcurrencyCheckResponse))]
[JsonSerializable(typeof(HistoricalUsageResponse))]
[JsonSerializable(typeof(CreateMonitorRequest))]
[JsonSerializable(typeof(UpdateMonitorRequest))]
[JsonSerializable(typeof(ParseOptions))]
[JsonSerializable(typeof(V2ScrapeOptions))]
[JsonSerializable(typeof(Dictionary<string, JsonElement>))]
[JsonSerializable(typeof(JsonElement))]
internal sealed partial class V2SourceGenerationContext : JsonSerializerContext
{
}
