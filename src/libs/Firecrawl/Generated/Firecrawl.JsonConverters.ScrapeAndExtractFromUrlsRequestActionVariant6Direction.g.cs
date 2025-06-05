#nullable enable

namespace Firecrawl.JsonConverters
{
    /// <inheritdoc />
    public sealed class ScrapeAndExtractFromUrlsRequestActionVariant6DirectionJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Direction>
    {
        /// <inheritdoc />
        public override global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Direction Read(
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
                        return global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6DirectionExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Direction)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Direction);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6Direction value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant6DirectionExtensions.ToValueString(value));
        }
    }
}
