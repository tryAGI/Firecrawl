
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Scroll the page or a specific element
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant6Type
    {
        /// <summary>
        /// 
        /// </summary>
        Scroll,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlRequestActionVariant6TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant6Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant6Type.Scroll => "scroll",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant6Type? ToEnum(string value)
        {
            return value switch
            {
                "scroll" => ScrapeAndExtractFromUrlRequestActionVariant6Type.Scroll,
                _ => null,
            };
        }
    }
}