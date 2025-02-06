
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Direction to scroll<br/>
    /// Default Value: down
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant6Direction
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
    public static class ScrapeAndExtractFromUrlRequestActionVariant6DirectionExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant6Direction value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant6Direction.Up => "up",
                ScrapeAndExtractFromUrlRequestActionVariant6Direction.Down => "down",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant6Direction? ToEnum(string value)
        {
            return value switch
            {
                "up" => ScrapeAndExtractFromUrlRequestActionVariant6Direction.Up,
                "down" => ScrapeAndExtractFromUrlRequestActionVariant6Direction.Down,
                _ => null,
            };
        }
    }
}