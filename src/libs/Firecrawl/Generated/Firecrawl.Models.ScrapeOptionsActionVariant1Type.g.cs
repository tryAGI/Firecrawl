
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Wait for a specified amount of milliseconds
    /// </summary>
    public enum ScrapeOptionsActionVariant1Type
    {
        /// <summary>
        /// 
        /// </summary>
        Wait,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsActionVariant1TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionVariant1Type value)
        {
            return value switch
            {
                ScrapeOptionsActionVariant1Type.Wait => "wait",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionVariant1Type? ToEnum(string value)
        {
            return value switch
            {
                "wait" => ScrapeOptionsActionVariant1Type.Wait,
                _ => null,
            };
        }
    }
}