
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Example: cancelled
    /// </summary>
    public enum CancelCrawlResponseStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Cancelled,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class CancelCrawlResponseStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CancelCrawlResponseStatus value)
        {
            return value switch
            {
                CancelCrawlResponseStatus.Cancelled => "cancelled",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CancelCrawlResponseStatus? ToEnum(string value)
        {
            return value switch
            {
                "cancelled" => CancelCrawlResponseStatus.Cancelled,
                _ => null,
            };
        }
    }
}