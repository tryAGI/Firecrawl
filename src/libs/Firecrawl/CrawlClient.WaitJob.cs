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
    public async Task<CrawlStatusResponseObj> WaitJobAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<CrawlStatusResponseObj>? progress = null,
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

                var statusResponse = await GetCrawlStatusAsync(
                    id: jobId,
                    cancellationToken: token).ConfigureAwait(false);

                progress?.Report(statusResponse);

                if (statusResponse.Status is "completed" or "failed")
                {
                    return statusResponse;
                }
            }
        }
        catch (OperationCanceledException) when (timeout.HasValue && !cancellationToken.IsCancellationRequested)
        {
            throw new TimeoutException($"Crawl job {jobId} did not complete within {timeout.Value}.");
        }
    }
}