
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public enum GetDeepResearchStatusResponseDataStatus
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
    public static class GetDeepResearchStatusResponseDataStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this GetDeepResearchStatusResponseDataStatus value)
        {
            return value switch
            {
                GetDeepResearchStatusResponseDataStatus.Processing => "processing",
                GetDeepResearchStatusResponseDataStatus.Completed => "completed",
                GetDeepResearchStatusResponseDataStatus.Failed => "failed",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static GetDeepResearchStatusResponseDataStatus? ToEnum(string value)
        {
            return value switch
            {
                "processing" => GetDeepResearchStatusResponseDataStatus.Processing,
                "completed" => GetDeepResearchStatusResponseDataStatus.Completed,
                "failed" => GetDeepResearchStatusResponseDataStatus.Failed,
                _ => null,
            };
        }
    }
}