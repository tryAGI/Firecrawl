#nullable enable

namespace Firecrawl.JsonConverters
{
    /// <inheritdoc />
    public sealed class ScrapeAndExtractFromUrlsRequestFormatJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat>
    {
        /// <inheritdoc />
        public override global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat Read(
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
                        return global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormatExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormat value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Firecrawl.ScrapeAndExtractFromUrlsRequestFormatExtensions.ToValueString(value));
        }
    }
}
