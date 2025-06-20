
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Write text into an input field, text area, or contenteditable element. Note: You must first focus the element using a 'click' action before writing. The text will be typed character by character to simulate keyboard input.
    /// </summary>
    public enum ScrapeOptionsActionVariant4Type
    {
        /// <summary>
        /// 
        /// </summary>
        Write,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeOptionsActionVariant4TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeOptionsActionVariant4Type value)
        {
            return value switch
            {
                ScrapeOptionsActionVariant4Type.Write => "write",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeOptionsActionVariant4Type? ToEnum(string value)
        {
            return value switch
            {
                "write" => ScrapeOptionsActionVariant4Type.Write,
                _ => null,
            };
        }
    }
}