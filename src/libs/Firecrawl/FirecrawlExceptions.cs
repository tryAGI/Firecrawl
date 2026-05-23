using System.Net;

namespace Firecrawl;

/// <summary>
/// Thrown for HTTP 401 Unauthorized responses (invalid or missing API key).
/// </summary>
[Serializable]
public class FirecrawlAuthenticationException : ApiException
{
    public FirecrawlAuthenticationException() { }

    public FirecrawlAuthenticationException(string message)
        : base(message, HttpStatusCode.Unauthorized) { }

    public FirecrawlAuthenticationException(string message, Exception? innerException)
        : base(message, innerException, HttpStatusCode.Unauthorized) { }
}

/// <summary>
/// Thrown for HTTP 429 Too Many Requests responses.
/// </summary>
[Serializable]
public class FirecrawlRateLimitException : ApiException
{
    /// <summary>
    /// Value of the <c>Retry-After</c> response header, if present.
    /// Delta-seconds or HTTP-date depending on the server.
    /// </summary>
    public TimeSpan? RetryAfter { get; init; }

    public FirecrawlRateLimitException() { }

    public FirecrawlRateLimitException(string message)
        : base(message, HttpStatusCode.TooManyRequests) { }

    public FirecrawlRateLimitException(string message, Exception? innerException)
        : base(message, innerException, HttpStatusCode.TooManyRequests) { }
}

/// <summary>
/// Thrown for HTTP 402 Payment Required responses (insufficient credits).
/// </summary>
[Serializable]
public class FirecrawlPaymentRequiredException : ApiException
{
    public FirecrawlPaymentRequiredException() { }

    public FirecrawlPaymentRequiredException(string message)
        : base(message, HttpStatusCode.PaymentRequired) { }

    public FirecrawlPaymentRequiredException(string message, Exception? innerException)
        : base(message, innerException, HttpStatusCode.PaymentRequired) { }
}

/// <summary>
/// Thrown for HTTP 5xx Server Error responses.
/// </summary>
[Serializable]
public class FirecrawlServerException : ApiException
{
    public FirecrawlServerException() { }

    public FirecrawlServerException(string message, HttpStatusCode statusCode)
        : base(message, statusCode) { }

    public FirecrawlServerException(string message, Exception? innerException, HttpStatusCode statusCode)
        : base(message, innerException, statusCode) { }
}
