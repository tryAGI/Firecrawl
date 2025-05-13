#nullable enable

namespace Firecrawl.JsonConverters
{
    /// <inheritdoc />
    public sealed class ScrapeAndExtractFromUrlsRequestActionVariant8TypeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8Type?>
    {
        /// <inheritdoc />
        public override global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8Type? Read(
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
                        return global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8TypeExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8Type)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8Type?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8Type? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Firecrawl.ScrapeAndExtractFromUrlsRequestActionVariant8TypeExtensions.ToValueString(value.Value));
            }
        }
    }
}
