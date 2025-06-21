
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// The result of the comparison between the two page versions. 'new' means this page did not exist before, 'same' means content has not changed, 'changed' means content has changed, 'removed' means the page was removed.
    /// </summary>
    public enum ScrapeResponseDataChangeTrackingChangeStatus
    {
        /// <summary>
        /// 
        /// </summary>
        New,
        /// <summary>
        /// 
        /// </summary>
        Same,
        /// <summary>
        /// 
        /// </summary>
        Changed,
        /// <summary>
        /// 
        /// </summary>
        Removed,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeResponseDataChangeTrackingChangeStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeResponseDataChangeTrackingChangeStatus value)
        {
            return value switch
            {
                ScrapeResponseDataChangeTrackingChangeStatus.New => "new",
                ScrapeResponseDataChangeTrackingChangeStatus.Same => "same",
                ScrapeResponseDataChangeTrackingChangeStatus.Changed => "changed",
                ScrapeResponseDataChangeTrackingChangeStatus.Removed => "removed",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeResponseDataChangeTrackingChangeStatus? ToEnum(string value)
        {
            return value switch
            {
                "new" => ScrapeResponseDataChangeTrackingChangeStatus.New,
                "same" => ScrapeResponseDataChangeTrackingChangeStatus.Same,
                "changed" => ScrapeResponseDataChangeTrackingChangeStatus.Changed,
                "removed" => ScrapeResponseDataChangeTrackingChangeStatus.Removed,
                _ => null,
            };
        }
    }
}