
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum ScrapeRequestFormat
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
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeRequestFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeRequestFormat value)
        {
            return value switch
            {
                ScrapeRequestFormat.Markdown => "markdown",
                ScrapeRequestFormat.Html => "html",
                ScrapeRequestFormat.RawHtml => "rawHtml",
                ScrapeRequestFormat.Links => "links",
                ScrapeRequestFormat.Screenshot => "screenshot",
                ScrapeRequestFormat.Screenshot_fullPage => "screenshot@fullPage",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeRequestFormat? ToEnum(string value)
        {
            return value switch
            {
                "markdown" => ScrapeRequestFormat.Markdown,
                "html" => ScrapeRequestFormat.Html,
                "rawHtml" => ScrapeRequestFormat.RawHtml,
                "links" => ScrapeRequestFormat.Links,
                "screenshot" => ScrapeRequestFormat.Screenshot,
                "screenshot@fullPage" => ScrapeRequestFormat.Screenshot_fullPage,
                _ => null,
            };
        }
    }
}