
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestWebhookEvent
    {
        /// <summary>
        /// 
        /// </summary>
        Completed,
        /// <summary>
        /// 
        /// </summary>
        Page,
        /// <summary>
        /// 
        /// </summary>
        Failed,
        /// <summary>
        /// 
        /// </summary>
        Started,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestWebhookEventExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestWebhookEvent value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestWebhookEvent.Completed => "completed",
                ScrapeAndExtractFromUrlsRequestWebhookEvent.Page => "page",
                ScrapeAndExtractFromUrlsRequestWebhookEvent.Failed => "failed",
                ScrapeAndExtractFromUrlsRequestWebhookEvent.Started => "started",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestWebhookEvent? ToEnum(string value)
        {
            return value switch
            {
                "completed" => ScrapeAndExtractFromUrlsRequestWebhookEvent.Completed,
                "page" => ScrapeAndExtractFromUrlsRequestWebhookEvent.Page,
                "failed" => ScrapeAndExtractFromUrlsRequestWebhookEvent.Failed,
                "started" => ScrapeAndExtractFromUrlsRequestWebhookEvent.Started,
                _ => null,
            };
        }
    }
}