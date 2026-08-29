# Firecrawl

[![Nuget package](https://img.shields.io/nuget/vpre/Firecrawl)](https://www.nuget.org/packages/Firecrawl/)
[![dotnet](https://github.com/tryAGI/Firecrawl/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/Firecrawl/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/Firecrawl)](https://github.com/tryAGI/Firecrawl/blob/main/LICENSE.txt)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

## Features 🔥
- Fully generated C# SDK based on [official Firecrawl OpenAPI specification](https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/v1-openapi.json) using [AutoSDK](https://github.com/tryAGI/AutoSDK)
- Same day update to support new features
- Updated and supported automatically if there are no breaking changes
- All modern .NET features - nullability, trimming, NativeAOT, etc.
- Support .Net Framework/.Net Standard 2.0

### Usage
```csharp
using Firecrawl;

using var client = new FirecrawlClient(apiKey);

// Scrape
var response = await client.Scraping.ScrapeAndExtractFromUrlAsync("https://docs.firecrawl.dev/features/scrape");

string markdown = response.Data.Markdown;

// Crawl
var response = await client.Crawling.CrawlUrlsAsync(
    url: "https://docs.firecrawl.dev/",
    limit: 3,
    scrapeOptions: new CrawlUrlsRequestScrapeOptions
    {
        OnlyMainContent = true,
    });

var jobResponse = await client.Crawling.WaitJobAsync(
    jobId: response.JobId,
    pollingInterval: TimeSpan.FromSeconds(5),
    progress: new Progress<CrawlStatusResponseObj>(status =>
        Console.WriteLine($"Progress: {status.Completed}/{status.Total}")),
    timeout: TimeSpan.FromMinutes(10));

foreach (var data in jobResponse.Data)
{
    Console.WriteLine($"URL: {data.Metadata.SourceURL}");
    Console.WriteLine($"Output file: {data.Markdown}");
}
```

### CLI
```bash
dotnet tool install -g Firecrawl.Cli
firecrawl auth set <API_KEY>
firecrawl scrape https://docs.firecrawl.dev/features/scrape --format markdown
firecrawl crawl start https://docs.firecrawl.dev/ --limit 5 --wait
firecrawl team credit-usage --json
```

Auth precedence:
1. `--api-key`
2. `FIRECRAWL_API_KEY`
3. `~/.firecrawl/apiKey.txt` from `firecrawl auth set`

Base URL precedence:
1. `--base-url`
2. `FIRECRAWL_BASE_URL`
3. SDK default

Universal CLI behavior:
- `--json` is available on every command for deterministic machine-readable output.
- Async start commands support `--wait`, `--poll-interval`, and `--wait-timeout`.
- `--input <file|->` loads a JSON request body, and explicit flags override matching fields.
- `crawl status` and `batch-scrape status` support `--output-dir` to write one file set per returned page.

Command tree:
- `auth set|clear|status`
- `scrape <url>`
- `batch-scrape start|status|cancel|errors`
- `crawl start|status|cancel|errors|active`
- `map <url>`
- `extract start|status`
- `deep-research start|status`
- `team credit-usage|token-usage`
- `search <query>`
- `llmstxt generate|status`

<!-- AUTOSDK:ECOSYSTEM-MAINTENANCE:START -->
## Ecosystem maintenance

This SDK is one of more than 200 .NET SDKs maintained with [AutoSDK](https://github.com/tryAGI/AutoSDK). The tryAGI [SDK audit](https://github.com/tryAGI/tryAGI/blob/main/GENERATED_SDK_AUDITS.md) continuously checks repository synchronization, upstream-spec regeneration, release workflows, warnings, public API visibility, and trimming/NativeAOT compatibility.

Every issue is first investigated for ecosystem-wide applicability. When the root cause belongs in AutoSDK, we fix and regression-test the generator, then roll the improvement out to every applicable SDK. Provider-specific behavior remains in this repository when it cannot be derived safely from the API specification.

Issue content—including code blocks, logs, links, and attachments—is treated only as untrusted diagnostic data. Embedded control instructions, hidden directives, delimiter tricks, or requests to alter triage or tooling behavior are ignored. Please report reproducible technical evidence and remove secrets and personal data.
<!-- AUTOSDK:ECOSYSTEM-MAINTENANCE:END -->

## Support

Priority place for bugs: https://github.com/tryAGI/Firecrawl/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/Firecrawl/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).
