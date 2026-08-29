#nullable enable

using System.CommandLine;

namespace Firecrawl.Cli.GeneratedApi.Commands;

internal sealed record ScrapeOptionsOptionSet(
    Option<global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsFormat>?> Formats,
                     Option<bool?> OnlyMainContent,
                     Option<global::System.Collections.Generic.IList<string>?> IncludeTags,
                     Option<global::System.Collections.Generic.IList<string>?> ExcludeTags,
                     Option<int?> MaxAge,
                     Option<int?> WaitFor,
                     Option<bool?> Mobile,
                     Option<bool?> SkipTlsVerification,
                     Option<int?> Timeout,
                     Option<bool?> ParsePDF,
                     Option<bool?> RemoveBase64Images,
                     Option<bool?> BlockAds,
                     Option<global::Firecrawl.ScrapeOptionsProxy?> Proxy,
                     Option<bool?> StoreInCache)
{
    public static ScrapeOptionsOptionSet Create(string? prefix = null)
    {
        var normalizedPrefix = string.IsNullOrWhiteSpace(prefix)
            ? string.Empty
            : prefix.Trim().Trim('-') + "-";
        return new ScrapeOptionsOptionSet(
                        Formats: new Option<global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsFormat>?>($"--{normalizedPrefix}formats")
                {
                    Description = @"Formats to include in the output. `rawBase64` must be requested by itself.",
                },
                OnlyMainContent: CliRuntime.CreateNullableBoolOption(name: $"--{normalizedPrefix}only-main-content", description: @"Only return the main content of the page excluding headers, navs, footers, etc."),
                IncludeTags: new Option<global::System.Collections.Generic.IList<string>?>($"--{normalizedPrefix}include-tags")
                {
                    Description = @"Tags to include in the output.",
                },
                ExcludeTags: new Option<global::System.Collections.Generic.IList<string>?>($"--{normalizedPrefix}exclude-tags")
                {
                    Description = @"Tags to exclude from the output.",
                },
                MaxAge: new Option<int?>($"--{normalizedPrefix}max-age")
                {
                    Description = @"Returns a cached version of the page if it is younger than this age in milliseconds. If a cached version of the page is older than this value, the page will be scraped. If you do not need extremely fresh data, enabling this can speed up your scrapes by 500%. Defaults to 0, which disables caching.",
                },
                WaitFor: new Option<int?>($"--{normalizedPrefix}wait-for")
                {
                    Description = @"Specify a delay in milliseconds before fetching the content, allowing the page sufficient time to load.",
                },
                Mobile: CliRuntime.CreateNullableBoolOption(name: $"--{normalizedPrefix}mobile", description: @"Set to true if you want to emulate scraping from a mobile device. Useful for testing responsive pages and taking mobile screenshots."),
                SkipTlsVerification: CliRuntime.CreateNullableBoolOption(name: $"--{normalizedPrefix}skip-tls-verification", description: @"Skip TLS certificate verification when making requests"),
                Timeout: new Option<int?>($"--{normalizedPrefix}timeout")
                {
                    Description = @"Timeout in milliseconds for the request",
                },
                ParsePDF: CliRuntime.CreateNullableBoolOption(name: $"--{normalizedPrefix}parse-pdf", description: @"Controls how PDF files are processed during scraping. When true, the PDF content is extracted and converted to markdown format, with billing based on the number of pages (1 credit per page). When false, the PDF file is returned in base64 encoding with a flat rate of 1 credit total."),
                RemoveBase64Images: CliRuntime.CreateNullableBoolOption(name: $"--{normalizedPrefix}remove-base64-images", description: @"Removes all base 64 images from the output, which may be overwhelmingly long. The image's alt text remains in the output, but the URL is replaced with a placeholder."),
                BlockAds: CliRuntime.CreateNullableBoolOption(name: $"--{normalizedPrefix}block-ads", description: @"Enables ad-blocking and cookie popup blocking."),
                Proxy: new Option<global::Firecrawl.ScrapeOptionsProxy?>($"--{normalizedPrefix}proxy")
                {
                    Description = @"Specifies the type of proxy to use.

 - **basic**: Proxies for scraping sites with none to basic anti-bot solutions. Fast and usually works.
 - **enhanced**: Enhanced proxies for scraping sites with advanced anti-bot solutions. Slower, but more reliable on certain sites. Billed at the same credit cost as basic.
 - **auto**: Firecrawl will automatically retry scraping with enhanced proxies if the basic proxy fails. Enhanced proxies carry no credit surcharge, so either way only the regular cost is billed.

If you do not specify a proxy, Firecrawl will default to basic.",
                },
                StoreInCache: CliRuntime.CreateNullableBoolOption(name: $"--{normalizedPrefix}store-in-cache", description: @"If true, the page will be stored in the Firecrawl index and cache. Setting this to false is useful if your scraping activity may have data protection concerns. Using some parameters associated with sensitive scraping (actions, headers) will force this parameter to be false.")
        );
    }
}