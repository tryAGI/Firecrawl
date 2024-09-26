#nullable enable

namespace Firecrawl.JsonConverters
{
    /// <inheritdoc />
    public sealed class CrawlUrlsRequestCrawlerOptionsModeJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Firecrawl.CrawlUrlsRequestCrawlerOptionsMode>
    {
        /// <inheritdoc />
        public override global::Firecrawl.CrawlUrlsRequestCrawlerOptionsMode Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::Firecrawl.CrawlUrlsRequestCrawlerOptionsModeExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Firecrawl.CrawlUrlsRequestCrawlerOptionsMode)numValue;
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Firecrawl.CrawlUrlsRequestCrawlerOptionsMode value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Firecrawl.CrawlUrlsRequestCrawlerOptionsModeExtensions.ToValueString(value));
        }
    }
}
