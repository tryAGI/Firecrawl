
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Scrape the current page content, returns the url and the html.
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant7Type
    {
        /// <summary>
        /// 
        /// </summary>
        Scrape,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlRequestActionVariant7TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant7Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant7Type.Scrape => "scrape",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant7Type? ToEnum(string value)
        {
            return value switch
            {
                "scrape" => ScrapeAndExtractFromUrlRequestActionVariant7Type.Scrape,
                _ => null,
            };
        }
    }
}