
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum CrawlUrlsRequestScrapeOptionsFormat
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
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class CrawlUrlsRequestScrapeOptionsFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CrawlUrlsRequestScrapeOptionsFormat value)
        {
            return value switch
            {
                CrawlUrlsRequestScrapeOptionsFormat.Markdown => "markdown",
                CrawlUrlsRequestScrapeOptionsFormat.Html => "html",
                CrawlUrlsRequestScrapeOptionsFormat.RawHtml => "rawHtml",
                CrawlUrlsRequestScrapeOptionsFormat.Links => "links",
                CrawlUrlsRequestScrapeOptionsFormat.Screenshot => "screenshot",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CrawlUrlsRequestScrapeOptionsFormat? ToEnum(string value)
        {
            return value switch
            {
                "markdown" => CrawlUrlsRequestScrapeOptionsFormat.Markdown,
                "html" => CrawlUrlsRequestScrapeOptionsFormat.Html,
                "rawHtml" => CrawlUrlsRequestScrapeOptionsFormat.RawHtml,
                "links" => CrawlUrlsRequestScrapeOptionsFormat.Links,
                "screenshot" => CrawlUrlsRequestScrapeOptionsFormat.Screenshot,
                _ => null,
            };
        }
    }
}