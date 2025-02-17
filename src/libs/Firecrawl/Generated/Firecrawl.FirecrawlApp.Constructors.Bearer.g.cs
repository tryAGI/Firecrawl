
#nullable enable

namespace Firecrawl
{
    public sealed partial class FirecrawlApp
    {
        /// <inheritdoc cref="FirecrawlApp(global::System.Net.Http.HttpClient?, global::System.Uri?, global::System.Collections.Generic.List{global::Firecrawl.EndPointAuthorization}?, bool)"/>
        public FirecrawlApp(
            string apiKey,
            global::System.Net.Http.HttpClient? httpClient = null,
            global::System.Uri? baseUri = null,
            global::System.Collections.Generic.List<global::Firecrawl.EndPointAuthorization>? authorizations = null,
            bool disposeHttpClient = true) : this(httpClient, baseUri, authorizations, disposeHttpClient)
        {
            Authorizing(HttpClient, ref apiKey);

            AuthorizeUsingBearer(apiKey);

            Authorized(HttpClient);
        }

        partial void Authorizing(
            global::System.Net.Http.HttpClient client,
            ref string apiKey);
        partial void Authorized(
            global::System.Net.Http.HttpClient client);
    }
}