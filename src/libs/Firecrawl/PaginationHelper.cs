using System.Net.Http;
using System.Text.Json;

namespace Firecrawl;

/// <summary>
/// Walks the <c>next</c>-URL pagination Firecrawl returns on crawl and batch
/// status responses, accumulating every page into the first response.
///
/// <para>
/// Each follow-up URL is validated against the configured <see cref="HttpClient.BaseAddress"/>
/// before being requested — Firecrawl's <c>next</c> pointers are absolute
/// URLs, and a malicious or misconfigured server could redirect us to a
/// third-party origin and harvest the <c>Authorization</c> header. We refuse
/// to forward credentials across origins for this reason.
/// </para>
/// </summary>
internal static class PaginationHelper
{
    internal static async Task<string> FetchNextPageJsonAsync(
        HttpClient httpClient,
        string nextUrl,
        CancellationToken cancellationToken)
    {
        EnsureSameOrigin(httpClient.BaseAddress, nextUrl);

        using var request = new HttpRequestMessage(HttpMethod.Get, nextUrl);
        if (httpClient.DefaultRequestHeaders.Authorization is { } auth)
        {
            request.Headers.Authorization = auth;
        }

        using var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
            cancellationToken
#endif
            ).ConfigureAwait(false);
    }

    internal static void EnsureSameOrigin(Uri? baseUri, string nextUrl)
    {
        if (baseUri is null)
            return;

        if (!Uri.TryCreate(nextUrl, UriKind.Absolute, out var target))
        {
            throw new InvalidOperationException(
                $"Pagination URL is not absolute: '{nextUrl}'.");
        }

        if (!string.Equals(target.Scheme, baseUri.Scheme, StringComparison.OrdinalIgnoreCase) ||
            !string.Equals(target.Host, baseUri.Host, StringComparison.OrdinalIgnoreCase) ||
            target.Port != baseUri.Port)
        {
            throw new InvalidOperationException(
                $"Refusing to follow pagination URL '{target.Scheme}://{target.Host}:{target.Port}' " +
                $"because it does not match the client base address " +
                $"'{baseUri.Scheme}://{baseUri.Host}:{baseUri.Port}'. " +
                "Forwarding the Authorization header to a different origin would leak the API key.");
        }
    }
}
