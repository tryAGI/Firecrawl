using System.Net.Http;

namespace Firecrawl;

public partial class CrawlingClient
{
    /// <summary>
    /// Walks the <c>next</c>-URL chain on a crawl status response, appending
    /// every page of <see cref="CrawlStatusResponseObj.Data"/> into the first
    /// response and clearing <see cref="CrawlStatusResponseObj.Next"/> when
    /// done. The supplied <paramref name="response"/> is mutated and returned.
    ///
    /// <para>
    /// Same-origin validation against <see cref="HttpClient.BaseAddress"/> is
    /// enforced via <see cref="AutoSDKPager.EnsureSameOrigin"/> — Firecrawl's
    /// <c>next</c> pointers are absolute URLs and a hostile server returning a
    /// foreign URL would otherwise harvest the <c>Authorization</c> header.
    /// </para>
    /// </summary>
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
