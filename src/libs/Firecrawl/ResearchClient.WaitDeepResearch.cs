namespace Firecrawl;

public partial class ResearchClient
{
    /// <summary>
    /// Waits for a deep research job to complete or fail.
    /// </summary>
    /// <param name="jobId"></param>
    /// <param name="pollingInterval">
    /// The interval between status checks. Defaults to 5 seconds.
    /// Deep research operations are long-running, so a longer default is used.
    /// </param>
    /// <param name="progress">
    /// Optional <see cref="IProgress{T}"/> instance to report deep research status after each poll.
    /// </param>
    /// <param name="timeout">
    /// Optional timeout for the entire wait operation. Defaults to no timeout.
    /// </param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    /// <exception cref="global::System.InvalidOperationException"></exception>
    /// <exception cref="global::System.TimeoutException"></exception>
    public Task<GetDeepResearchStatusResponse> WaitDeepResearchAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<GetDeepResearchStatusResponse>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        return PollingHelper.PollUntilAsync(
            fetchStatus: ct => GetDeepResearchStatusAsync(id: jobId, cancellationToken: ct),
            isComplete: r => r.Data?.Status is
                GetDeepResearchStatusResponseDataStatus.Completed or
                GetDeepResearchStatusResponseDataStatus.Failed,
            jobDescription: $"Deep research job {jobId}",
            pollingInterval: pollingInterval ?? TimeSpan.FromSeconds(5),
            progress: progress,
            timeout: timeout,
            cancellationToken: cancellationToken);
    }
}
