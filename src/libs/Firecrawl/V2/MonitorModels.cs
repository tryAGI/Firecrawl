using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firecrawl.V2;

public sealed class MonitorSchedule
{
    [JsonPropertyName("cron")]
    public string? Cron { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
}

public sealed class CreateMonitorRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("schedule")]
    public MonitorSchedule? Schedule { get; set; }

    [JsonPropertyName("targets")]
    public IList<Dictionary<string, JsonElement>>? Targets { get; set; }

    [JsonPropertyName("webhook")]
    public Dictionary<string, JsonElement>? Webhook { get; set; }

    [JsonPropertyName("notification")]
    public Dictionary<string, JsonElement>? Notification { get; set; }

    [JsonPropertyName("retentionDays")]
    public int? RetentionDays { get; set; }
}

public sealed class UpdateMonitorRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("schedule")]
    public MonitorSchedule? Schedule { get; set; }

    [JsonPropertyName("targets")]
    public IList<Dictionary<string, JsonElement>>? Targets { get; set; }

    [JsonPropertyName("webhook")]
    public Dictionary<string, JsonElement>? Webhook { get; set; }

    [JsonPropertyName("notification")]
    public Dictionary<string, JsonElement>? Notification { get; set; }

    [JsonPropertyName("retentionDays")]
    public int? RetentionDays { get; set; }
}

public sealed class MonitorSummary
{
    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("same")]
    public int Same { get; set; }

    [JsonPropertyName("changed")]
    public int Changed { get; set; }

    [JsonPropertyName("new")]
    public int New { get; set; }

    [JsonPropertyName("removed")]
    public int Removed { get; set; }

    [JsonPropertyName("error")]
    public int Error { get; set; }
}

public sealed class Monitor
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("schedule")]
    public MonitorSchedule? Schedule { get; set; }

    [JsonPropertyName("nextRunAt")]
    public string? NextRunAt { get; set; }

    [JsonPropertyName("lastRunAt")]
    public string? LastRunAt { get; set; }

    [JsonPropertyName("currentCheckId")]
    public string? CurrentCheckId { get; set; }

    [JsonPropertyName("targets")]
    public IList<Dictionary<string, JsonElement>>? Targets { get; set; }

    [JsonPropertyName("webhook")]
    public Dictionary<string, JsonElement>? Webhook { get; set; }

    [JsonPropertyName("notification")]
    public Dictionary<string, JsonElement>? Notification { get; set; }

    [JsonPropertyName("retentionDays")]
    public int RetentionDays { get; set; }

    [JsonPropertyName("estimatedCreditsPerMonth")]
    public int? EstimatedCreditsPerMonth { get; set; }

    [JsonPropertyName("lastCheckSummary")]
    public MonitorSummary? LastCheckSummary { get; set; }

    [JsonPropertyName("createdAt")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public string? UpdatedAt { get; set; }
}

public class MonitorCheck
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("monitorId")]
    public string? MonitorId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("trigger")]
    public string? Trigger { get; set; }

    [JsonPropertyName("scheduledFor")]
    public string? ScheduledFor { get; set; }

    [JsonPropertyName("startedAt")]
    public string? StartedAt { get; set; }

    [JsonPropertyName("finishedAt")]
    public string? FinishedAt { get; set; }

    [JsonPropertyName("estimatedCredits")]
    public int? EstimatedCredits { get; set; }

    [JsonPropertyName("reservedCredits")]
    public int? ReservedCredits { get; set; }

    [JsonPropertyName("actualCredits")]
    public int? ActualCredits { get; set; }

    [JsonPropertyName("billingStatus")]
    public string? BillingStatus { get; set; }

    [JsonPropertyName("summary")]
    public MonitorSummary? Summary { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("createdAt")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public string? UpdatedAt { get; set; }
}

public sealed class MonitorJsonFieldDiff
{
    [JsonPropertyName("previous")]
    public JsonElement? Previous { get; set; }

    [JsonPropertyName("current")]
    public JsonElement? Current { get; set; }
}

public sealed class MonitorPageDiff
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("json")]
    public JsonElement? Json { get; set; }
}

public sealed class MonitorPageSnapshot
{
    [JsonPropertyName("json")]
    public Dictionary<string, JsonElement>? Json { get; set; }
}

public sealed class MonitorCheckPage
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("targetId")]
    public string? TargetId { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("previousScrapeId")]
    public string? PreviousScrapeId { get; set; }

    [JsonPropertyName("currentScrapeId")]
    public string? CurrentScrapeId { get; set; }

    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("metadata")]
    public JsonElement? Metadata { get; set; }

    [JsonPropertyName("diff")]
    public MonitorPageDiff? Diff { get; set; }

    [JsonPropertyName("snapshot")]
    public MonitorPageSnapshot? Snapshot { get; set; }

    [JsonPropertyName("createdAt")]
    public string? CreatedAt { get; set; }
}

public sealed class MonitorCheckDetail : MonitorCheck
{
    [JsonPropertyName("pages")]
    public IList<MonitorCheckPage>? Pages { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
