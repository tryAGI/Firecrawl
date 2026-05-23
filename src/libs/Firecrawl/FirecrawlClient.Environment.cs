namespace Firecrawl;

public sealed partial class FirecrawlClient
{
    /// <summary>
    /// Environment variable read by <see cref="FromEnvironment"/> for the API key.
    /// </summary>
    public const string ApiKeyEnvironmentVariable = "FIRECRAWL_API_KEY";

    /// <summary>
    /// Environment variable read by <see cref="FromEnvironment"/> for the base URL.
    /// </summary>
    public const string ApiUrlEnvironmentVariable = "FIRECRAWL_API_URL";

    /// <summary>
    /// Creates a <see cref="FirecrawlClient"/> from the
    /// <c>FIRECRAWL_API_KEY</c> environment variable.
    /// Falls back to <c>FIRECRAWL_API_URL</c> for the base URL when set.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <c>FIRECRAWL_API_KEY</c> is not set or empty.
    /// </exception>
    public static FirecrawlClient FromEnvironment(
        System.Net.Http.HttpClient? httpClient = null,
        bool disposeHttpClient = true)
    {
        var apiKey = Environment.GetEnvironmentVariable(ApiKeyEnvironmentVariable);
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException(
                $"API key not found. Set the {ApiKeyEnvironmentVariable} environment variable " +
                "or use a constructor overload that accepts an apiKey argument.");
        }

        var baseUrlOverride = Environment.GetEnvironmentVariable(ApiUrlEnvironmentVariable);
        var baseUri = string.IsNullOrWhiteSpace(baseUrlOverride)
            ? null
            : new Uri(baseUrlOverride, UriKind.Absolute);

        return new FirecrawlClient(
            apiKey: apiKey,
            httpClient: httpClient,
            baseUri: baseUri,
            authorizations: null,
            disposeHttpClient: disposeHttpClient);
    }
}
