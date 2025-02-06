
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Scroll the page or a specific element
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestActionVariant6Type
    {
        /// <summary>
        /// 
        /// </summary>
        Scroll,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestActionVariant6TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestActionVariant6Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestActionVariant6Type.Scroll => "scroll",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestActionVariant6Type? ToEnum(string value)
        {
            return value switch
            {
                "scroll" => ScrapeAndExtractFromUrlsRequestActionVariant6Type.Scroll,
                _ => null,
            };
        }
    }
}