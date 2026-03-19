/*
order: 10
title: Metadata Description Array
slug: metadata-description-array
*/

namespace Firecrawl.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void Metadata_Description_Array()
    {
        var json = """
            {
                "title": "Test Page",
                "description": ["First description", "Second description"],
                "sourceURL": "https://example.com"
            }
            """;

        var metadata = System.Text.Json.JsonSerializer.Deserialize<ScrapeResponseDataMetadata>(
            json, SourceGenerationContext.Default.ScrapeResponseDataMetadata);

        metadata.Should().NotBeNull();
        metadata!.Description.Should().NotBeNull();
        metadata.Description!.Value.IsValue2.Should().BeTrue();
        metadata.Description.Value.Value2.Should().HaveCount(2);
        metadata.Description.Value.Value2![0].Should().Be("First description");
    }
}
