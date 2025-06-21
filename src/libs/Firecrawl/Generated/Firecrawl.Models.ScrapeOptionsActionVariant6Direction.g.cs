
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Direction to scroll<br/>
    /// Default Value: down
    /// </summary>
    public enum ScrapeOptionsActionVariant6Direction
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
    public static class ScrapeOptionsActionVariant6DirectionExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionVariant6Direction value)
        {
            return value switch
            {
                ScrapeOptionsActionVariant6Direction.Up => "up",
                ScrapeOptionsActionVariant6Direction.Down => "down",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionVariant6Direction? ToEnum(string value)
        {
            return value switch
            {
                "up" => ScrapeOptionsActionVariant6Direction.Up,
                "down" => ScrapeOptionsActionVariant6Direction.Down,
                _ => null,
            };
        }
    }
}