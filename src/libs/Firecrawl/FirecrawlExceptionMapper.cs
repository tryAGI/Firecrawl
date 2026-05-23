using System.Net.Http;

namespace Firecrawl;

internal static class FirecrawlExceptionMapper
{
    /// <summary>
    /// Promotes 401/402/429/5xx HTTP responses into typed
    /// <see cref="FirecrawlAuthenticationException"/>,
    /// <see cref="FirecrawlPaymentRequiredException"/>,
    /// <see cref="FirecrawlRateLimitException"/>, and
    /// <see cref="FirecrawlServerException"/> so callers can catch by intent
    /// rather than branching on <see cref="ApiException.StatusCode"/>.
    /// </summary>
    internal static void ThrowTypedFirecrawlException(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var status = response.StatusCode;
        var reason = response.ReasonPhrase ?? status.ToString();

        switch ((int)status)
        {
            case 401:
                throw new FirecrawlAuthenticationException(reason);
            case 402:
                throw new FirecrawlPaymentRequiredException(reason);
            case 429:
                throw new FirecrawlRateLimitException(reason)
                {
                    RetryAfter = ParseRetryAfter(response),
                };
            case >= 500 and < 600:
                throw new FirecrawlServerException(reason, status);
        }
    }

    private static TimeSpan? ParseRetryAfter(HttpResponseMessage response)
    {
        var header = response.Headers.RetryAfter;
        if (header is null)
            return null;

        if (header.Delta.HasValue)
            return header.Delta.Value;

        if (header.Date is { } date)
        {
            var remaining = date - DateTimeOffset.UtcNow;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }

        return null;
    }
}
