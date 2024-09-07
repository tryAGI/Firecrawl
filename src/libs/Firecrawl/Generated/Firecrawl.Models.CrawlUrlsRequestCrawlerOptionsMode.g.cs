
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// The crawling mode to use. Fast mode crawls 4x faster websites without sitemap, but may not be as accurate and shouldn't be used in heavy js-rendered websites.<br/>
    /// Default Value: default
    /// </summary>
    public enum CrawlUrlsRequestCrawlerOptionsMode
    {
        /// <summary>
        /// 
        /// </summary>
        Default,
        /// <summary>
        /// 
        /// </summary>
        Fast,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class CrawlUrlsRequestCrawlerOptionsModeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CrawlUrlsRequestCrawlerOptionsMode value)
        {
            return value switch
            {
                CrawlUrlsRequestCrawlerOptionsMode.Default => "default",
                CrawlUrlsRequestCrawlerOptionsMode.Fast => "fast",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CrawlUrlsRequestCrawlerOptionsMode? ToEnum(string value)
        {
            return value switch
            {
                "default" => CrawlUrlsRequestCrawlerOptionsMode.Default,
                "fast" => CrawlUrlsRequestCrawlerOptionsMode.Fast,
                _ => null,
            };
        }
    }
}