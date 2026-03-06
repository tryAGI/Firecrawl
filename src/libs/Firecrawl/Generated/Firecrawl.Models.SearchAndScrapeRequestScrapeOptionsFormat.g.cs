
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum SearchAndScrapeRequestScrapeOptionsFormat
    {
        /// <summary>
        /// 
        /// </summary>
        Markdown,
        /// <summary>
        /// 
        /// </summary>
        Html,
        /// <summary>
        /// 
        /// </summary>
        RawHtml,
        /// <summary>
        /// 
        /// </summary>
        Links,
        /// <summary>
        /// 
        /// </summary>
        Screenshot,
        /// <summary>
        /// 
        /// </summary>
        Screenshot_fullPage,
        /// <summary>
        /// 
        /// </summary>
        Json,
        /// <summary>
        /// 
        /// </summary>
        Branding,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SearchAndScrapeRequestScrapeOptionsFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SearchAndScrapeRequestScrapeOptionsFormat value)
        {
            return value switch
            {
                SearchAndScrapeRequestScrapeOptionsFormat.Markdown => "markdown",
                SearchAndScrapeRequestScrapeOptionsFormat.Html => "html",
                SearchAndScrapeRequestScrapeOptionsFormat.RawHtml => "rawHtml",
                SearchAndScrapeRequestScrapeOptionsFormat.Links => "links",
                SearchAndScrapeRequestScrapeOptionsFormat.Screenshot => "screenshot",
                SearchAndScrapeRequestScrapeOptionsFormat.Screenshot_fullPage => "screenshot@fullPage",
                SearchAndScrapeRequestScrapeOptionsFormat.Json => "json",
                SearchAndScrapeRequestScrapeOptionsFormat.Branding => "branding",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SearchAndScrapeRequestScrapeOptionsFormat? ToEnum(string value)
        {
            return value switch
            {
                "markdown" => SearchAndScrapeRequestScrapeOptionsFormat.Markdown,
                "html" => SearchAndScrapeRequestScrapeOptionsFormat.Html,
                "rawHtml" => SearchAndScrapeRequestScrapeOptionsFormat.RawHtml,
                "links" => SearchAndScrapeRequestScrapeOptionsFormat.Links,
                "screenshot" => SearchAndScrapeRequestScrapeOptionsFormat.Screenshot,
                "screenshot@fullPage" => SearchAndScrapeRequestScrapeOptionsFormat.Screenshot_fullPage,
                "json" => SearchAndScrapeRequestScrapeOptionsFormat.Json,
                "branding" => SearchAndScrapeRequestScrapeOptionsFormat.Branding,
                _ => null,
            };
        }
    }
}