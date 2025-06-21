
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Press a key on the page
    /// </summary>
    public enum ScrapeOptionsActionVariant5Type
    {
        /// <summary>
        /// 
        /// </summary>
        Press,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsActionVariant5TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionVariant5Type value)
        {
            return value switch
            {
                ScrapeOptionsActionVariant5Type.Press => "press",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionVariant5Type? ToEnum(string value)
        {
            return value switch
            {
                "press" => ScrapeOptionsActionVariant5Type.Press,
                _ => null,
            };
        }
    }
}