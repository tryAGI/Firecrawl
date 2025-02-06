
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Take a screenshot
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant2Type
    {
        /// <summary>
        /// 
        /// </summary>
        Screenshot,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlRequestActionVariant2TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant2Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant2Type.Screenshot => "screenshot",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant2Type? ToEnum(string value)
        {
            return value switch
            {
                "screenshot" => ScrapeAndExtractFromUrlRequestActionVariant2Type.Screenshot,
                _ => null,
            };
        }
    }
}