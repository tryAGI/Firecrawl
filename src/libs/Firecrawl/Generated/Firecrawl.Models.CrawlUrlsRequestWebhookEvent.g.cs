
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum CrawlUrlsRequestWebhookEvent
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
    public static class CrawlUrlsRequestWebhookEventExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CrawlUrlsRequestWebhookEvent value)
        {
            return value switch
            {
                CrawlUrlsRequestWebhookEvent.Completed => "completed",
                CrawlUrlsRequestWebhookEvent.Page => "page",
                CrawlUrlsRequestWebhookEvent.Failed => "failed",
                CrawlUrlsRequestWebhookEvent.Started => "started",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CrawlUrlsRequestWebhookEvent? ToEnum(string value)
        {
            return value switch
            {
                "completed" => CrawlUrlsRequestWebhookEvent.Completed,
                "page" => CrawlUrlsRequestWebhookEvent.Page,
                "failed" => CrawlUrlsRequestWebhookEvent.Failed,
                "started" => CrawlUrlsRequestWebhookEvent.Started,
                _ => null,
            };
        }
    }
}