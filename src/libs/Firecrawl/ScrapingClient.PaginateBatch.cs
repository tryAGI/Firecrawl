namespace Firecrawl;

public partial class ScrapingClient
{
    /// <summary>
    /// Walks the <c>next</c>-URL chain on a batch scrape status response,
    /// appending every page of <see cref="BatchScrapeStatusResponseObj.Data"/>
    /// into the first response and clearing
    /// <see cref="BatchScrapeStatusResponseObj.Next"/> when done.
    /// The supplied <paramref name="response"/> is mutated and returned.
    /// </summary>
    public async Task<BatchScrapeStatusResponseObj> PaginateBatchAsync(
        BatchScrapeStatusResponseObj response,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(response);

        response.Data ??= new List<BatchScrapeStatusResponseObjDataItem>();
        var next = response.Next;

        while (!string.IsNullOrEmpty(next))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var content = await PaginationHelper
                .FetchNextPageJsonAsync(HttpClient, next, cancellationToken)
                .ConfigureAwait(false);

            var page = BatchScrapeStatusResponseObj.FromJson(content, JsonSerializerContext)
                ?? throw new InvalidOperationException("Pagination response deserialization returned null.");

            if (page.Data is { Count: > 0 })
            {
                foreach (var item in page.Data)
                {
                    response.Data.Add(item);
                }
            }

            next = page.Next;
        }

        response.Next = null;
        return response;
    }

    /// <summary>
    /// Convenience helper: waits for the batch scrape to finish and then
    /// paginates the full result set in one call.
    /// </summary>
    public async Task<BatchScrapeStatusResponseObj> WaitBatchAndPaginateAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<BatchScrapeStatusResponseObj>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var job = await WaitBatchAsync(jobId, pollingInterval, progress, timeout, cancellationToken)
            .ConfigureAwait(false);

        return await PaginateBatchAsync(job, cancellationToken).ConfigureAwait(false);
    }
}
