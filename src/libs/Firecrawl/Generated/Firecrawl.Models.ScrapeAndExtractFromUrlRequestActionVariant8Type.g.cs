
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Execute JavaScript code on the page
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant8Type
    {
        /// <summary>
        /// 
        /// </summary>
        ExecuteJavascript,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlRequestActionVariant8TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant8Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant8Type.ExecuteJavascript => "executeJavascript",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant8Type? ToEnum(string value)
        {
            return value switch
            {
                "executeJavascript" => ScrapeAndExtractFromUrlRequestActionVariant8Type.ExecuteJavascript,
                _ => null,
            };
        }
    }
}