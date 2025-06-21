
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Take a screenshot. The links will be in the response's `actions.screenshots` array.
    /// </summary>
    public enum ScrapeOptionsActionVariant2Type
    {
        /// <summary>
        /// 
        /// </summary>
        Screenshot,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsActionVariant2TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionVariant2Type value)
        {
            return value switch
            {
                ScrapeOptionsActionVariant2Type.Screenshot => "screenshot",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionVariant2Type? ToEnum(string value)
        {
            return value switch
            {
                "screenshot" => ScrapeOptionsActionVariant2Type.Screenshot,
                _ => null,
            };
        }
    }
}