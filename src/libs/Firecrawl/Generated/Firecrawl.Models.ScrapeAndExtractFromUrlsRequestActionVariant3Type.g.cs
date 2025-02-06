
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Click on an element
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestActionVariant3Type
    {
        /// <summary>
        /// 
        /// </summary>
        Click,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestActionVariant3TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestActionVariant3Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestActionVariant3Type.Click => "click",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestActionVariant3Type? ToEnum(string value)
        {
            return value switch
            {
                "click" => ScrapeAndExtractFromUrlsRequestActionVariant3Type.Click,
                _ => null,
            };
        }
    }
}