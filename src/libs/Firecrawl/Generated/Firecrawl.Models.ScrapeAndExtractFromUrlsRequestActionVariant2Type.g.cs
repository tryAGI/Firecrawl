
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Take a screenshot
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestActionVariant2Type
    {
        /// <summary>
        /// 
        /// </summary>
        Screenshot,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestActionVariant2TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestActionVariant2Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestActionVariant2Type.Screenshot => "screenshot",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestActionVariant2Type? ToEnum(string value)
        {
            return value switch
            {
                "screenshot" => ScrapeAndExtractFromUrlsRequestActionVariant2Type.Screenshot,
                _ => null,
            };
        }
    }
}