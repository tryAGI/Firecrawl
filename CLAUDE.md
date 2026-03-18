# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

C# SDK for [Firecrawl](https://firecrawl.dev/), the web scraping and crawling API, auto-generated from the official Firecrawl OpenAPI specification using [AutoSDK](https://github.com/tryAGI/AutoSDK). Published as NuGet package `Firecrawl`. Also includes a .NET CLI tool (`Firecrawl.Cli`) for command-line scraping and crawling.

## Build Commands

```bash
# Build the solution
dotnet build Firecrawl.slnx

# Build for release (also produces NuGet packages)
dotnet build Firecrawl.slnx -c Release

# Run integration tests (requires FIRECRAWL_API_KEY env var)
dotnet test src/tests/IntegrationTests/Firecrawl.IntegrationTests.csproj

# Regenerate SDK from OpenAPI spec
cd src/libs/Firecrawl && ./generate.sh

# Install and use the CLI tool
dotnet tool install -g Firecrawl.Cli
firecrawl auth <API_KEY>
firecrawl scrape https://example.com
firecrawl crawl https://example.com --limit 5
```

## Architecture

### Code Generation Pipeline

The SDK code in `src/libs/Firecrawl/Generated/` is **entirely auto-generated** -- do not manually edit files there.

1. `src/libs/Firecrawl/openapi.yaml` -- the Firecrawl OpenAPI spec (fetched from the official Firecrawl repo)
2. `src/helpers/FixOpenApiSpec/` -- converts OpenAPI 3.1 to 3.0 format for compatibility
3. `src/libs/Firecrawl/generate.sh` -- orchestrates: download spec, fix spec, run AutoSDK CLI, output to `Generated/`
4. CI auto-updates the spec and creates PRs if changes are detected

### Project Layout

| Project | Purpose |
|---------|---------|
| `src/libs/Firecrawl/` | Main SDK library (`FirecrawlClient`) |
| `src/libs/Firecrawl.Cli/` | .NET CLI tool for scraping/crawling (auth, scrape, crawl, map commands) |
| `src/tests/IntegrationTests/` | Integration tests against real Firecrawl API |
| `src/helpers/FixOpenApiSpec/` | OpenAPI spec fixer tool |
| `src/helpers/GenerateDocs/` | Documentation generator from integration tests |

### Hand-Written Extensions

| File | Purpose |
|------|---------|
| `PollingHelper.cs` | Shared generic polling logic used by all wait helpers |
| `CrawlClient.WaitJob.cs` | Polling helper to wait for crawl jobs to complete |
| `ScrapingClient.WaitBatch.cs` | Polling helper to wait for batch scrape jobs to complete |
| `ExtractionClient.WaitExtract.cs` | Polling helper to wait for extract jobs to complete |
| `ResearchClient.WaitDeepResearch.cs` | Polling helper to wait for deep research jobs to complete |
| `LLMsTxtClient.WaitLlmsTxt.cs` | Polling helper to wait for LLMs.txt generation to complete |

### CLI Tool Structure

The `Firecrawl.Cli` project provides a command-line interface with these commands:

| Command | File |
|---------|------|
| `firecrawl auth` | `Commands/AuthCommand.cs` |
| `firecrawl scrape` | `Commands/ScrapeCommand.cs` |
| `firecrawl crawl` | `Commands/CrawlCommand.cs` |
| `firecrawl map` | `Commands/MapCommand.cs` |

### Build Configuration

- **Target:** `net10.0` (single target)
- **Language:** C# preview with nullable reference types
- **Signing:** Strong-named assemblies via `src/key.snk`
- **Versioning:** Semantic versioning from git tags (`v` prefix) via MinVer
- **Analysis:** All .NET analyzers enabled, AOT/trimming compatibility enforced
- **Testing:** MSTest + FluentAssertions

### Key Conventions

- The client class is named `FirecrawlClient`
- The namespace is `Firecrawl`
- Crawl results are accessed via `client.Crawling.WaitJobAsync()` for polling until completion

### CI/CD

- Uses shared workflows from `HavenDV/workflows` repo
- Dependabot updates NuGet packages weekly (auto-merged)
- Documentation deployed to GitHub Pages via MkDocs Material
