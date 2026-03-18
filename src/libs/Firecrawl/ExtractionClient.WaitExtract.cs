namespace Firecrawl;

public partial class ExtractionClient
{
    /// <summary>
    /// Waits for an extract job to complete or fail.
    /// </summary>
    /// <param name="jobId"></param>
    /// <param name="pollingInterval">
    /// The interval between status checks. Defaults to 1 second.
    /// </param>
    /// <param name="progress">
    /// Optional <see cref="IProgress{T}"/> instance to report extract status after each poll.
    /// </param>
    /// <param name="timeout">
    /// Optional timeout for the entire wait operation. Defaults to no timeout.
    /// </param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    /// <exception cref="global::System.InvalidOperationException"></exception>
    /// <exception cref="global::System.TimeoutException"></exception>
    public Task<ExtractStatusResponse> WaitExtractAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<ExtractStatusResponse>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        return PollingHelper.PollUntilAsync(
            fetchStatus: ct => GetExtractStatusAsync(id: jobId, cancellationToken: ct),
            isComplete: r => r.Status is
                ExtractStatusResponseStatus.Completed or
                ExtractStatusResponseStatus.Failed or
                ExtractStatusResponseStatus.Cancelled,
            jobDescription: $"Extract job {jobId}",
            pollingInterval: pollingInterval,
            progress: progress,
            timeout: timeout,
            cancellationToken: cancellationToken);
    }
}
