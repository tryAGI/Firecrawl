
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Execute JavaScript code on the page
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestActionVariant8Type
    {
        /// <summary>
        /// 
        /// </summary>
        ExecuteJavascript,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestActionVariant8TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestActionVariant8Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestActionVariant8Type.ExecuteJavascript => "executeJavascript",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestActionVariant8Type? ToEnum(string value)
        {
            return value switch
            {
                "executeJavascript" => ScrapeAndExtractFromUrlsRequestActionVariant8Type.ExecuteJavascript,
                _ => null,
            };
        }
    }
}