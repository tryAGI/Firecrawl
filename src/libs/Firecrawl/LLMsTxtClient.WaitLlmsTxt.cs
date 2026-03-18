namespace Firecrawl;

public partial class LLMsTxtClient
{
    /// <summary>
    /// Waits for an LLMs.txt generation job to complete or fail.
    /// </summary>
    /// <param name="jobId"></param>
    /// <param name="pollingInterval">
    /// The interval between status checks. Defaults to 1 second.
    /// </param>
    /// <param name="progress">
    /// Optional <see cref="IProgress{T}"/> instance to report LLMs.txt generation status after each poll.
    /// </param>
    /// <param name="timeout">
    /// Optional timeout for the entire wait operation. Defaults to no timeout.
    /// </param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    /// <exception cref="global::System.InvalidOperationException"></exception>
    /// <exception cref="global::System.TimeoutException"></exception>
    public Task<GetLLMsTxtStatusResponse> WaitLlmsTxtAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<GetLLMsTxtStatusResponse>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        return PollingHelper.PollUntilAsync(
            fetchStatus: ct => GetLLMsTxtStatusAsync(id: jobId, cancellationToken: ct),
            isComplete: r => r.Status is
                GetLLMsTxtStatusResponseStatus.Completed or
                GetLLMsTxtStatusResponseStatus.Failed,
            jobDescription: $"LLMs.txt generation job {jobId}",
            pollingInterval: pollingInterval,
            progress: progress,
            timeout: timeout,
            cancellationToken: cancellationToken);
    }
}
