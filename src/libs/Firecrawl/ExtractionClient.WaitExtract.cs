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
    public async Task<ExtractStatusResponse> WaitExtractAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<ExtractStatusResponse>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var delay = pollingInterval ?? TimeSpan.FromSeconds(1);

        using var cts = timeout.HasValue
            ? CancellationTokenSource.CreateLinkedTokenSource(cancellationToken)
            : null;
        cts?.CancelAfter(timeout!.Value);
        var token = cts?.Token ?? cancellationToken;

        try
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(delay, token).ConfigureAwait(false);

                var statusResponse = await GetExtractStatusAsync(
                    id: jobId,
                    cancellationToken: token).ConfigureAwait(false);

                progress?.Report(statusResponse);

                if (statusResponse.Status is
                    ExtractStatusResponseStatus.Completed or
                    ExtractStatusResponseStatus.Failed or
                    ExtractStatusResponseStatus.Cancelled)
                {
                    return statusResponse;
                }
            }
        }
        catch (OperationCanceledException) when (timeout.HasValue && !cancellationToken.IsCancellationRequested)
        {
            throw new TimeoutException($"Extract job {jobId} did not complete within {timeout.Value}.");
        }
    }
}
