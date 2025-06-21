
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// The current status of the extract job
    /// </summary>
    public enum ExtractStatusResponseStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Completed,
        /// <summary>
        /// 
        /// </summary>
        Processing,
        /// <summary>
        /// 
        /// </summary>
        Failed,
        /// <summary>
        /// 
        /// </summary>
        Cancelled,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ExtractStatusResponseStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ExtractStatusResponseStatus value)
        {
            return value switch
            {
                ExtractStatusResponseStatus.Completed => "completed",
                ExtractStatusResponseStatus.Processing => "processing",
                ExtractStatusResponseStatus.Failed => "failed",
                ExtractStatusResponseStatus.Cancelled => "cancelled",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ExtractStatusResponseStatus? ToEnum(string value)
        {
            return value switch
            {
                "completed" => ExtractStatusResponseStatus.Completed,
                "processing" => ExtractStatusResponseStatus.Processing,
                "failed" => ExtractStatusResponseStatus.Failed,
                "cancelled" => ExtractStatusResponseStatus.Cancelled,
                _ => null,
            };
        }
    }
}