
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestFormat
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
        Extract,
        /// <summary>
        /// 
        /// </summary>
        Screenshot_fullPage,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestFormat value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestFormat.Markdown => "markdown",
                ScrapeAndExtractFromUrlsRequestFormat.Html => "html",
                ScrapeAndExtractFromUrlsRequestFormat.RawHtml => "rawHtml",
                ScrapeAndExtractFromUrlsRequestFormat.Links => "links",
                ScrapeAndExtractFromUrlsRequestFormat.Screenshot => "screenshot",
                ScrapeAndExtractFromUrlsRequestFormat.Extract => "extract",
                ScrapeAndExtractFromUrlsRequestFormat.Screenshot_fullPage => "screenshot@fullPage",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestFormat? ToEnum(string value)
        {
            return value switch
            {
                "markdown" => ScrapeAndExtractFromUrlsRequestFormat.Markdown,
                "html" => ScrapeAndExtractFromUrlsRequestFormat.Html,
                "rawHtml" => ScrapeAndExtractFromUrlsRequestFormat.RawHtml,
                "links" => ScrapeAndExtractFromUrlsRequestFormat.Links,
                "screenshot" => ScrapeAndExtractFromUrlsRequestFormat.Screenshot,
                "extract" => ScrapeAndExtractFromUrlsRequestFormat.Extract,
                "screenshot@fullPage" => ScrapeAndExtractFromUrlsRequestFormat.Screenshot_fullPage,
                _ => null,
            };
        }
    }
}