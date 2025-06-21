
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Click on an element
    /// </summary>
    public enum ScrapeOptionsActionVariant3Type
    {
        /// <summary>
        /// 
        /// </summary>
        Click,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsActionVariant3TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionVariant3Type value)
        {
            return value switch
            {
                ScrapeOptionsActionVariant3Type.Click => "click",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionVariant3Type? ToEnum(string value)
        {
            return value switch
            {
                "click" => ScrapeOptionsActionVariant3Type.Click,
                _ => null,
            };
        }
    }
}