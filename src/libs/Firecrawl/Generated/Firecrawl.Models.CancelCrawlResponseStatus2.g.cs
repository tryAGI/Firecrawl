
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Example: cancelled
    /// </summary>
    public enum CancelCrawlResponseStatus2
    {
        /// <summary>
        /// 
        /// </summary>
        Cancelled,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class CancelCrawlResponseStatus2Extensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CancelCrawlResponseStatus2 value)
        {
            return value switch
            {
                CancelCrawlResponseStatus2.Cancelled => "cancelled",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CancelCrawlResponseStatus2? ToEnum(string value)
        {
            return value switch
            {
                "cancelled" => CancelCrawlResponseStatus2.Cancelled,
                _ => null,
            };
        }
    }
}