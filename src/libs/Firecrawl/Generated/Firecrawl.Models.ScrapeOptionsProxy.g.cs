
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Specifies the type of proxy to use.<br/>
    ///  - **basic**: Proxies for scraping sites with none to basic anti-bot solutions. Fast and usually works.<br/>
    ///  - **stealth**: Stealth proxies for scraping sites with advanced anti-bot solutions. Slower, but more reliable on certain sites. Costs up to 5 credits per request.<br/>
    ///  - **auto**: Firecrawl will automatically retry scraping with stealth proxies if the basic proxy fails. If the retry with stealth is successful, 5 credits will be billed for the scrape. If the first attempt with basic is successful, only the regular cost will be billed.<br/>
    /// If you do not specify a proxy, Firecrawl will default to basic.
    /// </summary>
    public enum ScrapeOptionsProxy
    {
        /// <summary>
        /// Proxies for scraping sites with none to basic anti-bot solutions. Fast and usually works.
        /// </summary>
        Basic,
        /// <summary>
        /// Stealth proxies for scraping sites with advanced anti-bot solutions. Slower, but more reliable on certain sites. Costs up to 5 credits per request.
        /// </summary>
        Stealth,
        /// <summary>
        /// Firecrawl will automatically retry scraping with stealth proxies if the basic proxy fails. If the retry with stealth is successful, 5 credits will be billed for the scrape. If the first attempt with basic is successful, only the regular cost will be billed.
        /// </summary>
        Auto,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsProxyExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsProxy value)
        {
            return value switch
            {
                ScrapeOptionsProxy.Basic => "basic",
                ScrapeOptionsProxy.Stealth => "stealth",
                ScrapeOptionsProxy.Auto => "auto",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsProxy? ToEnum(string value)
        {
            return value switch
            {
                "basic" => ScrapeOptionsProxy.Basic,
                "stealth" => ScrapeOptionsProxy.Stealth,
                "auto" => ScrapeOptionsProxy.Auto,
                _ => null,
            };
        }
    }
}