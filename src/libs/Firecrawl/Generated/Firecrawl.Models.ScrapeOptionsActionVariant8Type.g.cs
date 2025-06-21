
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Execute JavaScript code on the page
    /// </summary>
    public enum ScrapeOptionsActionVariant8Type
    {
        /// <summary>
        /// 
        /// </summary>
        ExecuteJavascript,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsActionVariant8TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionVariant8Type value)
        {
            return value switch
            {
                ScrapeOptionsActionVariant8Type.ExecuteJavascript => "executeJavascript",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionVariant8Type? ToEnum(string value)
        {
            return value switch
            {
                "executeJavascript" => ScrapeOptionsActionVariant8Type.ExecuteJavascript,
                _ => null,
            };
        }
    }
}