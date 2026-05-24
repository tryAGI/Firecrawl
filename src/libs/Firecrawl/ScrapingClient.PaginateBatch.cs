using System.Net.Http;

namespace Firecrawl;

public partial class ScrapingClient
{
    /// <summary>
    /// Walks the <c>next</c>-URL chain on a batch scrape status response,
    /// appending every page of <see cref="BatchScrapeStatusResponseObj.Data"/>
    /// into the first response and clearing
    /// <see cref="BatchScrapeStatusResponseObj.Next"/> when done.
    /// The supplied <paramref name="response"/> is mutated and returned.
    ///
    /// <para>
    /// Same-origin validation against <see cref="HttpClient.BaseAddress"/> is
    /// enforced via <see cref="AutoSDKPager.EnsureSameOrigin"/>.
    /// </para>
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
            AutoSDKPager.EnsureSameOrigin(next, HttpClient.BaseAddress);

            using var request = new HttpRequestMessage(HttpMethod.Get, next);
            if (HttpClient.DefaultRequestHeaders.Authorization is { } auth)
            {
                request.Headers.Authorization = auth;
            }

            using var http = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!http.IsSuccessStatusCode)
            {
                throw ApiException.Create(http.StatusCode, http.ReasonPhrase ?? http.StatusCode.ToString());
            }

            var content = await http.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                cancellationToken
#endif
                ).ConfigureAwait(false);

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
