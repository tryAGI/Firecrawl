namespace Firecrawl;

public partial class CrawlingClient
{
    /// <summary>
    /// Waits for a crawl job to complete or fail.
    /// </summary>
    /// <param name="jobId"></param>
    /// <param name="pollingInterval">
    /// The interval between status checks. Defaults to 1 second.
    /// For large crawls, consider using a longer interval to reduce API calls and bandwidth.
    /// </param>
    /// <param name="progress">
    /// Optional <see cref="IProgress{T}"/> instance to report crawl status after each poll.
    /// Useful for UI progress bars or logging (e.g., <see cref="CrawlStatusResponseObj.Completed"/>
    /// and <see cref="CrawlStatusResponseObj.Total"/>).
    /// </param>
    /// <param name="timeout">
    /// Optional timeout for the entire wait operation. Defaults to no timeout.
    /// </param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    /// <exception cref="global::System.InvalidOperationException"></exception>
    /// <exception cref="global::System.TimeoutException"></exception>
    public Task<CrawlStatusResponseObj> WaitJobAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<CrawlStatusResponseObj>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        return PollingHelper.PollUntilAsync(
            fetchStatus: ct => GetCrawlStatusAsync(id: jobId, cancellationToken: ct),
            isComplete: r => r.Status is "completed" or "failed",
            jobDescription: $"Crawl job {jobId}",
            pollingInterval: pollingInterval,
            progress: progress,
            timeout: timeout,
            cancellationToken: cancellationToken);
    }
}
