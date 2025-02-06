namespace Firecrawl;

public partial class CrawlingClient
{
    /// <summary>
    /// Waits for a crawl job to complete or fail.
    /// </summary>
    /// <param name="jobId"></param>
    /// <param name="cancellationToken">The token to cancel the operation with</param>
    /// <exception cref="global::System.InvalidOperationException"></exception>
    public async Task<CrawlStatusResponseObj> WaitJobAsync(
        string jobId,
        CancellationToken cancellationToken = default)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
                
            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
            
            var statusResponse = await GetCrawlStatusAsync(
                id: jobId,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            if (statusResponse.Status is "completed" or "failed")
            {
                return statusResponse;
            }
        }
    }
}