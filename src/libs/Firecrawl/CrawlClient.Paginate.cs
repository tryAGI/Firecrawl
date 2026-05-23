namespace Firecrawl;

public partial class CrawlingClient
{
    /// <summary>
    /// Walks the <c>next</c>-URL chain on a crawl status response, appending
    /// every page of <see cref="CrawlStatusResponseObj.Data"/> into the first
    /// response and clearing <see cref="CrawlStatusResponseObj.Next"/> when
    /// done. The supplied <paramref name="response"/> is mutated and returned.
    /// </summary>
    /// <remarks>
    /// Firecrawl's <c>next</c> pointers are absolute URLs; we refuse to
    /// forward the <c>Authorization</c> header across origins to avoid leaking
    /// the API key.
    /// </remarks>
    public async Task<CrawlStatusResponseObj> PaginateAsync(
        CrawlStatusResponseObj response,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(response);

        response.Data ??= new List<CrawlStatusResponseObjDataItem>();
        var next = response.Next;

        while (!string.IsNullOrEmpty(next))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var content = await PaginationHelper
                .FetchNextPageJsonAsync(HttpClient, next, cancellationToken)
                .ConfigureAwait(false);

            var page = CrawlStatusResponseObj.FromJson(content, JsonSerializerContext)
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
    /// Convenience helper: waits for the job to finish and then paginates the
    /// full result set in one call.
    /// </summary>
    public async Task<CrawlStatusResponseObj> WaitJobAndPaginateAsync(
        string jobId,
        TimeSpan? pollingInterval = null,
        IProgress<CrawlStatusResponseObj>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var job = await WaitJobAsync(jobId, pollingInterval, progress, timeout, cancellationToken)
            .ConfigureAwait(false);

        return await PaginateAsync(job, cancellationToken).ConfigureAwait(false);
    }
}
