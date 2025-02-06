
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Press a key on the page
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant5Type
    {
        /// <summary>
        /// 
        /// </summary>
        Press,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlRequestActionVariant5TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant5Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant5Type.Press => "press",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant5Type? ToEnum(string value)
        {
            return value switch
            {
                "press" => ScrapeAndExtractFromUrlRequestActionVariant5Type.Press,
                _ => null,
            };
        }
    }
}