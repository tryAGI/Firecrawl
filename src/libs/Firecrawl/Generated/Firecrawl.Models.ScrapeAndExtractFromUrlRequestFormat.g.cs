
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestFormat
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
    public static class ScrapeAndExtractFromUrlRequestFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestFormat value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestFormat.Markdown => "markdown",
                ScrapeAndExtractFromUrlRequestFormat.Html => "html",
                ScrapeAndExtractFromUrlRequestFormat.RawHtml => "rawHtml",
                ScrapeAndExtractFromUrlRequestFormat.Links => "links",
                ScrapeAndExtractFromUrlRequestFormat.Screenshot => "screenshot",
                ScrapeAndExtractFromUrlRequestFormat.Extract => "extract",
                ScrapeAndExtractFromUrlRequestFormat.Screenshot_fullPage => "screenshot@fullPage",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestFormat? ToEnum(string value)
        {
            return value switch
            {
                "markdown" => ScrapeAndExtractFromUrlRequestFormat.Markdown,
                "html" => ScrapeAndExtractFromUrlRequestFormat.Html,
                "rawHtml" => ScrapeAndExtractFromUrlRequestFormat.RawHtml,
                "links" => ScrapeAndExtractFromUrlRequestFormat.Links,
                "screenshot" => ScrapeAndExtractFromUrlRequestFormat.Screenshot,
                "extract" => ScrapeAndExtractFromUrlRequestFormat.Extract,
                "screenshot@fullPage" => ScrapeAndExtractFromUrlRequestFormat.Screenshot_fullPage,
                _ => null,
            };
        }
    }
}