#nullable enable

namespace Firecrawl.JsonConverters
{
    /// <inheritdoc />
    public sealed class ScrapeAndExtractFromUrlRequestActionVariant3TypeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3Type?>
    {
        /// <inheritdoc />
        public override global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3Type? Read(
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
                        return global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3TypeExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3Type)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3Type?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3Type? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Firecrawl.ScrapeAndExtractFromUrlRequestActionVariant3TypeExtensions.ToValueString(value.Value));
            }
        }
    }
}
