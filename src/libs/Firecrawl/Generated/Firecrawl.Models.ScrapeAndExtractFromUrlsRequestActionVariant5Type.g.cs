
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Press a key on the page
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestActionVariant5Type
    {
        /// <summary>
        /// 
        /// </summary>
        Press,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestActionVariant5TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestActionVariant5Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestActionVariant5Type.Press => "press",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestActionVariant5Type? ToEnum(string value)
        {
            return value switch
            {
                "press" => ScrapeAndExtractFromUrlsRequestActionVariant5Type.Press,
                _ => null,
            };
        }
    }
}