
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// Default Value: [markdown]
    /// </summary>
    public enum StartDeepResearchRequestFormat
    {
        /// <summary>
        /// 
        /// </summary>
        Markdown,
        /// <summary>
        /// 
        /// </summary>
        Json,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class StartDeepResearchRequestFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this StartDeepResearchRequestFormat value)
        {
            return value switch
            {
                StartDeepResearchRequestFormat.Markdown => "markdown",
                StartDeepResearchRequestFormat.Json => "json",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static StartDeepResearchRequestFormat? ToEnum(string value)
        {
            return value switch
            {
                "markdown" => StartDeepResearchRequestFormat.Markdown,
                "json" => StartDeepResearchRequestFormat.Json,
                _ => null,
            };
        }
    }
}