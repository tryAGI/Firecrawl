
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Direction to scroll<br/>
    /// Default Value: down
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestActionVariant6Direction
    {
        /// <summary>
        /// 
        /// </summary>
        Up,
        /// <summary>
        /// 
        /// </summary>
        Down,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestActionVariant6DirectionExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestActionVariant6Direction value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestActionVariant6Direction.Up => "up",
                ScrapeAndExtractFromUrlsRequestActionVariant6Direction.Down => "down",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestActionVariant6Direction? ToEnum(string value)
        {
            return value switch
            {
                "up" => ScrapeAndExtractFromUrlsRequestActionVariant6Direction.Up,
                "down" => ScrapeAndExtractFromUrlsRequestActionVariant6Direction.Down,
                _ => null,
            };
        }
    }
}