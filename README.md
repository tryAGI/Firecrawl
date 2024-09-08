# Firecrawl

[![Nuget package](https://img.shields.io/nuget/vpre/Firecrawl)](https://www.nuget.org/packages/Firecrawl/)
[![dotnet](https://github.com/tryAGI/Firecrawl/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/Firecrawl/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/Firecrawl)](https://github.com/tryAGI/Firecrawl/blob/main/LICENSE.txt)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

## Features 🔥
- Fully generated C# SDK based on [official Firecrawl OpenAPI specification](https://raw.githubusercontent.com/Firecrawl/assemblyai-api-spec/main/openapi.yml) using [OpenApiGenerator](https://github.com/HavenDV/OpenApiGenerator)
- Same day update to support new features
- Updated and supported automatically if there are no breaking changes
- All modern .NET features - nullability, trimming, NativeAOT, etc.
- Support .Net Framework/.Net Standard 2.0

### Usage
```csharp
using Firecrawl;

using var api = new FirecrawlApp(apiKey);

// Scrape
var response = await api.Scraping.ScrapeAsync("https://docs.firecrawl.dev/features/scrape");

string markdown = response.Data.Markdown;

// Crawl
var response = await api.Crawling.CrawlUrlsAsync(
    url: "https://docs.firecrawl.dev/",
    crawlerOptions: new CrawlUrlsRequestCrawlerOptions
    {
        Limit = 3,
    },
    pageOptions: new CrawlUrlsRequestPageOptions
    {
        OnlyMainContent = true,
    });

var jobResponse = await api.Crawl.WaitJobAsync(
    jobId: response.JobId);

foreach (var data in jobResponse.Data)
{
    Console.WriteLine($"URL: {data.Metadata.SourceURL}");
    Console.WriteLine($"Output file: {data.Markdown}");
}
```

### CLI
```bash
dotnet tool install -g Firecrawl.Cli
firecrawl auth <API_KEY>
firecrawl scrape https://docs.firecrawl.dev/features/scrape // saves it to output.md
firecrawl crawl https://docs.firecrawl.dev/features/scrape --limit 5 // saves all .md files to docs.firecrawl.dev folder
```

## Support

Priority place for bugs: https://github.com/tryAGI/Firecrawl/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/Firecrawl/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).

![CodeRabbit logo](https://opengraph.githubassets.com/1c51002d7d0bbe0c4fd72ff8f2e58192702f73a7037102f77e4dbb98ac00ea8f/marketplace/coderabbitai)

This project is supported by CodeRabbit through the [Open Source Support Program](https://github.com/marketplace/coderabbitai).