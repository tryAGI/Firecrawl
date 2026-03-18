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
    /// <param name="onProgress">
    /// Optional callback invoked after each status check with the current crawl status.
    /// Useful for monitoring progress (e.g., logging <see cref="CrawlStatusResponseObj.Completed"/>
    /// and <see cref="CrawlStatusResponseObj.Total"/>).
    /// </param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    /// <exception cref="global::System.InvalidOperationException"></exception>
    public async Task<CrawlStatusResponseObj> WaitJobAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        Action<CrawlStatusResponseObj>? onProgress = null,
        CancellationToken cancellationToken = default)
    {
        var delay = pollingInterval ?? TimeSpan.FromSeconds(1);

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);

            var statusResponse = await GetCrawlStatusAsync(
                id: jobId,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            onProgress?.Invoke(statusResponse);

            if (statusResponse.Status is "completed" or "failed")
            {
                return statusResponse;
            }
        }
    }
}