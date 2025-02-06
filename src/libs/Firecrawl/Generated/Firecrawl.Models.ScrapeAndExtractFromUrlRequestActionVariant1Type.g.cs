
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Wait for a specified amount of milliseconds
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant1Type
    {
        /// <summary>
        /// 
        /// </summary>
        Wait,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlRequestActionVariant1TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant1Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant1Type.Wait => "wait",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant1Type? ToEnum(string value)
        {
            return value switch
            {
                "wait" => ScrapeAndExtractFromUrlRequestActionVariant1Type.Wait,
                _ => null,
            };
        }
    }
}