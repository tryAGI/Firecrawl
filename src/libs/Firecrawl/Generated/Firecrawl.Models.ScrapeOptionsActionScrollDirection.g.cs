
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Direction to scroll<br/>
    /// Default Value: down
    /// </summary>
    public enum ScrapeOptionsActionScrollDirection
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
    public static class ScrapeOptionsActionScrollDirectionExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionScrollDirection value)
        {
            return value switch
            {
                ScrapeOptionsActionScrollDirection.Up => "up",
                ScrapeOptionsActionScrollDirection.Down => "down",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionScrollDirection? ToEnum(string value)
        {
            return value switch
            {
                "up" => ScrapeOptionsActionScrollDirection.Up,
                "down" => ScrapeOptionsActionScrollDirection.Down,
                _ => null,
            };
        }
    }
}