
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum ScrapeOptionsFormat
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
        ChangeTracking,
        /// <summary>
        /// 
        /// </summary>
        Branding,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsFormat value)
        {
            return value switch
            {
                ScrapeOptionsFormat.Markdown => "markdown",
                ScrapeOptionsFormat.Html => "html",
                ScrapeOptionsFormat.RawHtml => "rawHtml",
                ScrapeOptionsFormat.Links => "links",
                ScrapeOptionsFormat.Screenshot => "screenshot",
                ScrapeOptionsFormat.Screenshot_fullPage => "screenshot@fullPage",
                ScrapeOptionsFormat.Json => "json",
                ScrapeOptionsFormat.ChangeTracking => "changeTracking",
                ScrapeOptionsFormat.Branding => "branding",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsFormat? ToEnum(string value)
        {
            return value switch
            {
                "markdown" => ScrapeOptionsFormat.Markdown,
                "html" => ScrapeOptionsFormat.Html,
                "rawHtml" => ScrapeOptionsFormat.RawHtml,
                "links" => ScrapeOptionsFormat.Links,
                "screenshot" => ScrapeOptionsFormat.Screenshot,
                "screenshot@fullPage" => ScrapeOptionsFormat.Screenshot_fullPage,
                "json" => ScrapeOptionsFormat.Json,
                "changeTracking" => ScrapeOptionsFormat.ChangeTracking,
                "branding" => ScrapeOptionsFormat.Branding,
                _ => null,
            };
        }
    }
}