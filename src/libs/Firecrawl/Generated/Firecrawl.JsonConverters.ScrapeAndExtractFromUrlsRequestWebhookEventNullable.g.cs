#nullable enable

namespace Firecrawl.JsonConverters
{
    /// <inheritdoc />
    public sealed class ScrapeAndExtractFromUrlsRequestWebhookEventNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent?>
    {
        /// <inheritdoc />
        public override global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent? Read(
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
                        return global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEventExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEvent? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Firecrawl.ScrapeAndExtractFromUrlsRequestWebhookEventExtensions.ToValueString(value.Value));
            }
        }
    }
}
