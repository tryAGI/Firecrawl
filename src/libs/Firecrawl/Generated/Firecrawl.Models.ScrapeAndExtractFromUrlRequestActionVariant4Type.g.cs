
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Write text into an input field, text area, or contenteditable element. Note: You must first focus the element using a 'click' action before writing. The text will be typed character by character to simulate keyboard input.
    /// </summary>
    public enum ScrapeAndExtractFromUrlRequestActionVariant4Type
    {
        /// <summary>
        /// 
        /// </summary>
        Write,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlRequestActionVariant4TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlRequestActionVariant4Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlRequestActionVariant4Type.Write => "write",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlRequestActionVariant4Type? ToEnum(string value)
        {
            return value switch
            {
                "write" => ScrapeAndExtractFromUrlRequestActionVariant4Type.Write,
                _ => null,
            };
        }
    }
}