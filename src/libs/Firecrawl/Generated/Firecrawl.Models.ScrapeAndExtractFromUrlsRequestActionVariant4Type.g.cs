
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Write text into an input field
    /// </summary>
    public enum ScrapeAndExtractFromUrlsRequestActionVariant4Type
    {
        /// <summary>
        /// 
        /// </summary>
        Write,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeAndExtractFromUrlsRequestActionVariant4TypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeAndExtractFromUrlsRequestActionVariant4Type value)
        {
            return value switch
            {
                ScrapeAndExtractFromUrlsRequestActionVariant4Type.Write => "write",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeAndExtractFromUrlsRequestActionVariant4Type? ToEnum(string value)
        {
            return value switch
            {
                "write" => ScrapeAndExtractFromUrlsRequestActionVariant4Type.Write,
                _ => null,
            };
        }
    }
}