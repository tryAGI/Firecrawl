
#nullable enable

namespace Firecrawl
{
    public sealed partial class FirecrawlApp
    {
        /// <inheritdoc cref="FirecrawlApp(global::System.Net.Http.HttpClient?, global::System.Uri?)"/>
        public FirecrawlApp(
            string apiKey,
            global::System.Net.Http.HttpClient? httpClient = null,
            global::System.Uri? baseUri = null) : this(httpClient, baseUri)
        {
            Authorizing(_httpClient, ref apiKey);

            AuthorizeUsingBearer(apiKey);

            Authorized(_httpClient);
        }

        partial void Authorizing(
            global::System.Net.Http.HttpClient client,
            ref string apiKey);
        partial void Authorized(
            global::System.Net.Http.HttpClient client);
    }
}