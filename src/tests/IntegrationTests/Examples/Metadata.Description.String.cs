/*
order: 20
title: Metadata Description String
slug: metadata-description-string
*/

namespace Firecrawl.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void Metadata_Description_String()
    {
        var json = """
            {
                "title": "Test Page",
                "description": "A simple description",
                "sourceURL": "https://example.com"
            }
            """;

        var metadata = System.Text.Json.JsonSerializer.Deserialize<ScrapeResponseDataMetadata>(
            json, SourceGenerationContext.Default.ScrapeResponseDataMetadata);

        metadata.Should().NotBeNull();
        metadata!.Description.Should().NotBeNull();
        metadata.Description!.Value.IsValue1.Should().BeTrue();
        metadata.Description.Value.Value1.Should().Be("A simple description");
    }
}
