
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// The visibility of the current page/URL. 'visible' means the URL was discovered through an organic route (links or sitemap), 'hidden' means the URL was discovered through memory from previous crawls.
    /// </summary>
    public enum ScrapeResponseDataChangeTrackingVisibility
    {
        /// <summary>
        /// 
        /// </summary>
        Visible,
        /// <summary>
        /// 
        /// </summary>
        Hidden,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ScrapeResponseDataChangeTrackingVisibilityExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ScrapeResponseDataChangeTrackingVisibility value)
        {
            return value switch
            {
                ScrapeResponseDataChangeTrackingVisibility.Visible => "visible",
                ScrapeResponseDataChangeTrackingVisibility.Hidden => "hidden",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ScrapeResponseDataChangeTrackingVisibility? ToEnum(string value)
        {
            return value switch
            {
                "visible" => ScrapeResponseDataChangeTrackingVisibility.Visible,
                "hidden" => ScrapeResponseDataChangeTrackingVisibility.Hidden,
                _ => null,
            };
        }
    }
}