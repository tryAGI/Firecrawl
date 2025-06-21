
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum GetLLMsTxtStatusResponseStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Processing,
        /// <summary>
        /// 
        /// </summary>
        Completed,
        /// <summary>
        /// 
        /// </summary>
        Failed,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class GetLLMsTxtStatusResponseStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GetLLMsTxtStatusResponseStatus value)
        {
            return value switch
            {
                GetLLMsTxtStatusResponseStatus.Processing => "processing",
                GetLLMsTxtStatusResponseStatus.Completed => "completed",
                GetLLMsTxtStatusResponseStatus.Failed => "failed",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GetLLMsTxtStatusResponseStatus? ToEnum(string value)
        {
            return value switch
            {
                "processing" => GetLLMsTxtStatusResponseStatus.Processing,
                "completed" => GetLLMsTxtStatusResponseStatus.Completed,
                "failed" => GetLLMsTxtStatusResponseStatus.Failed,
                _ => null,
            };
        }
    }
}