
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Firecrawl
{
    /// <summary>
    ///
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>>), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScript_f681b9d095e7f3b8")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScript_6399eca05818f0a8")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>?), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScript_6530b403140f8d0c")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.OneOf<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>>), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScript_aa877162c83d46a8")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<object>), TypeInfoPropertyName = "SystemCollectionsGeneric_ObjectList")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Text.Json.JsonElement?))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsFormat), TypeInfoPropertyName = "ScrapeOptionsFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsJsonOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWait))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWaitType), TypeInfoPropertyName = "ScrapeOptionsActionWaitType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScreenshot))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScreenshotType), TypeInfoPropertyName = "ScrapeOptionsActionScreenshotType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionClick))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionClickType), TypeInfoPropertyName = "ScrapeOptionsActionClickType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWriteText))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWriteTextType), TypeInfoPropertyName = "ScrapeOptionsActionWriteTextType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionPressAKey))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionPressAKeyType), TypeInfoPropertyName = "ScrapeOptionsActionPressAKeyType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScroll))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrollType), TypeInfoPropertyName = "ScrapeOptionsActionScrollType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrollDirection), TypeInfoPropertyName = "ScrapeOptionsActionScrollDirection2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrape))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrapeType), TypeInfoPropertyName = "ScrapeOptionsActionScrapeType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScript))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScriptType), TypeInfoPropertyName = "ScrapeOptionsActionExecuteJavaScriptType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsLocation))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsProxy), TypeInfoPropertyName = "ScrapeOptionsProxy2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptions))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode), TypeInfoPropertyName = "ScrapeOptionsChangeTrackingOptionsMode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractStatusResponseStatus), TypeInfoPropertyName = "ExtractStatusResponseStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractDataRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractDataResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractDataResponse2))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsFormat?), TypeInfoPropertyName = "NullableScrapeOptionsFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool?))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int?))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWaitType?), TypeInfoPropertyName = "NullableScrapeOptionsActionWaitType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScreenshotType?), TypeInfoPropertyName = "NullableScrapeOptionsActionScreenshotType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionClickType?), TypeInfoPropertyName = "NullableScrapeOptionsActionClickType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionWriteTextType?), TypeInfoPropertyName = "NullableScrapeOptionsActionWriteTextType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionPressAKeyType?), TypeInfoPropertyName = "NullableScrapeOptionsActionPressAKeyType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrollType?), TypeInfoPropertyName = "NullableScrapeOptionsActionScrollType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrollDirection?), TypeInfoPropertyName = "NullableScrapeOptionsActionScrollDirection2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionScrapeType?), TypeInfoPropertyName = "NullableScrapeOptionsActionScrapeType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScriptType?), TypeInfoPropertyName = "NullableScrapeOptionsActionExecuteJavaScriptType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsProxy?), TypeInfoPropertyName = "NullableScrapeOptionsProxy2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode?), TypeInfoPropertyName = "NullableScrapeOptionsChangeTrackingOptionsMode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime?))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Firecrawl.ExtractStatusResponseStatus?), TypeInfoPropertyName = "NullableExtractStatusResponseStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeOptionsFormat>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode>))]
    internal sealed partial class ExtractionSourceGenerationContextChunk0 : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
    /// <summary>
    ///
    /// </summary>
    public sealed partial class ExtractionSourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
        private static readonly global::System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver Resolver = new LazyChunkResolver();


        private static readonly global::System.Text.Json.JsonSerializerOptions DefaultOptions = CreateDefaultOptions();

        /// <summary>
        ///
        /// </summary>
        public static ExtractionSourceGenerationContext Default { get; } = new(DefaultOptions);

        private ExtractionSourceGenerationContext(global::System.Text.Json.JsonSerializerOptions options)
            : base(options)
        {
        }

        /// <inheritdoc />
        protected override global::System.Text.Json.JsonSerializerOptions? GeneratedSerializerOptions => DefaultOptions;

        /// <inheritdoc />
        public override global::System.Text.Json.Serialization.Metadata.JsonTypeInfo? GetTypeInfo(global::System.Type type)
        {
            return Resolver.GetTypeInfo(type, Options);
        }

        /// <summary>
        /// Adds this package's converters to <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// A converter has to be on the options a chained resolver builds its JsonTypeInfo against,
        /// and a context resolves types from every package below it. Each package contributes only
        /// what it owns and calls down the chain for the rest, so the family's converter table is
        /// written once rather than copied into all of them.
        /// </remarks>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public static void AddConverters(global::System.Text.Json.JsonSerializerOptions options)
        {
            options.Converters.Add(new global::Firecrawl.JsonConverters.OneOfJsonConverter<global::Firecrawl.ScrapeOptionsActionWait, global::Firecrawl.ScrapeOptionsActionScreenshot, global::Firecrawl.ScrapeOptionsActionClick, global::Firecrawl.ScrapeOptionsActionWriteText, global::Firecrawl.ScrapeOptionsActionPressAKey, global::Firecrawl.ScrapeOptionsActionScroll, global::Firecrawl.ScrapeOptionsActionScrape, global::Firecrawl.ScrapeOptionsActionExecuteJavaScript>());
            options.Converters.Add(new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>());
            options.Converters.Add(new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>());
            options.Converters.Add(new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>());
            options.Converters.Add(new global::Firecrawl.JsonConverters.OneOfJsonConverter<string, global::System.Collections.Generic.IList<string>>());
            options.Converters.Add(new global::Firecrawl.JsonConverters.UnixTimestampJsonConverter());
            options.Converters.Add(new LazyEnumJsonConverterFactory());
        }

        private static global::System.Text.Json.JsonSerializerOptions CreateDefaultOptions()
        {
            var options = new global::System.Text.Json.JsonSerializerOptions
            {
                DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                TypeInfoResolver = Resolver,
            };
            AddConverters(options);

            return options;
        }


        private sealed class LazyEnumJsonConverterFactory : global::System.Text.Json.Serialization.JsonConverterFactory
        {
            public override bool CanConvert(global::System.Type typeToConvert)
            {
                return
                    typeToConvert == typeof(global::Firecrawl.ScrapeOptionsFormat)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsFormat?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWaitType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWaitType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScreenshotType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScreenshotType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionClickType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionClickType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWriteTextType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWriteTextType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionPressAKeyType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionPressAKeyType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollDirection)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollDirection?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrapeType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrapeType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScriptType)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScriptType?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsProxy)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsProxy?)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode)

                    || typeToConvert == typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode?)

                    || typeToConvert == typeof(global::Firecrawl.ExtractStatusResponseStatus)

                    || typeToConvert == typeof(global::Firecrawl.ExtractStatusResponseStatus?);
            }

            public override global::System.Text.Json.Serialization.JsonConverter CreateConverter(
                global::System.Type typeToConvert,
                global::System.Text.Json.JsonSerializerOptions options)
            {
                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsFormat))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsFormatJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsFormat?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsFormatNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWaitType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionWaitTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWaitType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionWaitTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScreenshotType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScreenshotTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScreenshotType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScreenshotTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionClickType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionClickTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionClickType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionClickTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWriteTextType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionWriteTextTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionWriteTextType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionWriteTextTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionPressAKeyType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionPressAKeyTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionPressAKeyType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionPressAKeyTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollDirection))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollDirectionJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrollDirection?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrollDirectionNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrapeType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrapeTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionScrapeType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionScrapeTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScriptType))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionExecuteJavaScriptTypeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsActionExecuteJavaScriptType?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsActionExecuteJavaScriptTypeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsProxy))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsProxyJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsProxy?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsProxyNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsChangeTrackingOptionsModeJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ScrapeOptionsChangeTrackingOptionsMode?))
                {
                    return new global::Firecrawl.JsonConverters.ScrapeOptionsChangeTrackingOptionsModeNullableJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ExtractStatusResponseStatus))
                {
                    return new global::Firecrawl.JsonConverters.ExtractStatusResponseStatusJsonConverter();
                }

                if (typeToConvert == typeof(global::Firecrawl.ExtractStatusResponseStatus?))
                {
                    return new global::Firecrawl.JsonConverters.ExtractStatusResponseStatusNullableJsonConverter();
                }
                throw new global::System.NotSupportedException($"No generated enum converter is registered for '{typeToConvert}'.");
            }
        }

        private sealed class LazyChunkResolver : global::System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver
        {
            private readonly object _gate = new();
            private readonly global::System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver?[] _resolvers = new global::System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver?[1];

            public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo? GetTypeInfo(
                global::System.Type type,
                global::System.Text.Json.JsonSerializerOptions options)
            {
                for (var index = 0; index < _resolvers.Length; index++)
                {
                    var typeInfo = GetResolver(index).GetTypeInfo(type, options);
                    if (typeInfo is not null)
                    {
                        return typeInfo;
                    }
                }

                return null;
            }

            private global::System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver GetResolver(int index)
            {
                var resolver = global::System.Threading.Volatile.Read(ref _resolvers[index]);
                if (resolver is not null)
                {
                    return resolver;
                }

                lock (_gate)
                {
                    return _resolvers[index] ??= CreateResolver(index);
                }
            }

            private static global::System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver CreateResolver(int index)
            {
                return index switch
                {
                    0 => new ExtractionSourceGenerationContextChunk0(new global::System.Text.Json.JsonSerializerOptions()),
                    _ => throw new global::System.ArgumentOutOfRangeException(nameof(index)),
                };
            }
        }
    }
}