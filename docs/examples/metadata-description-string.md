# Metadata Description String



This example assumes `using Firecrawl;` is in scope and `apiKey` contains your Firecrawl API key.

```csharp
var json = """
    {
        "title": "Test Page",
        "description": "A simple description",
        "sourceURL": "https://example.com"
    }
    """;

var metadata = System.Text.Json.JsonSerializer.Deserialize<ScrapeResponseDataMetadata>(
    json, SourceGenerationContext.Default.ScrapeResponseDataMetadata);
```