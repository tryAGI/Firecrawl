using System.CommandLine;

namespace Firecrawl.Cli;

internal static class CliOptions
{
    public static Option<string> ApiKey { get; } = new("--api-key")
    {
        Description = "Firecrawl API key. Overrides FIRECRAWL_API_KEY and any stored key.",
        Recursive = true,
    };

    public static Option<string> BaseUrl { get; } = new("--base-url")
    {
        Description = "Base URL for the Firecrawl API. Overrides FIRECRAWL_BASE_URL.",
        Recursive = true,
    };

    public static Option<bool> Json { get; } = new("--json")
    {
        Description = "Print the SDK response as JSON instead of human-readable text.",
        Recursive = true,
    };

    public static Option<string> CreateInputOption()
    {
        return new Option<string>("--input")
        {
            Description = "Load a JSON request from a file or '-' for stdin. Explicit flags override matching fields.",
        };
    }

    public static Option<string> CreateOutputOption()
    {
        return new Option<string>("--output")
        {
            Description = "Write the rendered command output to a file instead of stdout.",
        };
    }

    public static Option<string> CreateOutputDirectoryOption()
    {
        return new Option<string>("--output-dir")
        {
            Description = "Write one file set per returned page plus a metadata JSON sidecar.",
        };
    }

    public static Option<bool> CreateWaitOption()
    {
        return new Option<bool>("--wait")
        {
            Description = "Poll the related status endpoint until the job reaches a terminal state.",
        };
    }

    public static Option<string> CreatePollIntervalOption()
    {
        return new Option<string>("--poll-interval")
        {
            Description = "Polling interval, for example 2s, 500ms, 00:00:02.",
            DefaultValueFactory = _ => "2s",
        };
    }

    public static Option<string> CreateWaitTimeoutOption()
    {
        return new Option<string>("--wait-timeout")
        {
            Description = "Maximum time to wait before timing out, for example 30m or 00:30:00.",
            DefaultValueFactory = _ => "30m",
        };
    }

    public static Option<bool?> CreateNullableBoolOption(string name, string description, params string[] aliases)
    {
        var option = new Option<bool?>(name, aliases)
        {
            Description = description,
            Arity = ArgumentArity.ZeroOrOne,
        };

        option.CustomParser = result =>
        {
            if (result.Tokens.Count == 0)
            {
                return true;
            }

            if (result.Tokens.Count == 1 &&
                bool.TryParse(result.Tokens[0].Value, out var value))
            {
                return value;
            }

            result.AddError($"Option '{name}' expects true or false.");
            return null;
        };

        return option;
    }

    public static Option<string[]> CreateStringListOption(string name, string description, params string[] aliases)
    {
        return new Option<string[]>(name, aliases)
        {
            Description = description,
            Arity = ArgumentArity.ZeroOrMore,
        };
    }

    public static ScrapeOptionSet CreateScrapeOptionSet(string? prefix = null)
    {
        var normalizedPrefix = string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}-";
        return new ScrapeOptionSet(
            Formats: CreateStringListOption($"--{normalizedPrefix}format", "Formats to include in the output."),
            OnlyMainContent: CreateNullableBoolOption($"--{normalizedPrefix}only-main-content", "Only return the main page content."),
            IncludeTags: CreateStringListOption($"--{normalizedPrefix}include-tag", "HTML tags to include in the output."),
            ExcludeTags: CreateStringListOption($"--{normalizedPrefix}exclude-tag", "HTML tags to exclude from the output."),
            MaxAge: new Option<int?>($"--{normalizedPrefix}max-age") { Description = "Maximum cache age in milliseconds." },
            Headers: CreateStringListOption($"--{normalizedPrefix}header", "HTTP headers as key=value."),
            WaitFor: new Option<int?>($"--{normalizedPrefix}wait-for") { Description = "Delay in milliseconds before reading the page." },
            Mobile: CreateNullableBoolOption($"--{normalizedPrefix}mobile", "Emulate a mobile device."),
            SkipTlsVerification: CreateNullableBoolOption($"--{normalizedPrefix}skip-tls-verification", "Skip TLS certificate verification."),
            Timeout: new Option<int?>($"--{normalizedPrefix}timeout") { Description = "Request timeout in milliseconds." },
            ParsePdf: CreateNullableBoolOption($"--{normalizedPrefix}parse-pdf", "Parse PDF content into markdown instead of returning base64."),
            JsonPrompt: new Option<string>($"--{normalizedPrefix}json-prompt") { Description = "Prompt to use for JSON extraction." },
            JsonSystemPrompt: new Option<string>($"--{normalizedPrefix}json-system-prompt") { Description = "System prompt to use for JSON extraction." },
            JsonSchemaJson: new Option<string>($"--{normalizedPrefix}json-schema-json") { Description = "Inline JSON Schema for JSON extraction." },
            JsonSchemaFile: new Option<string>($"--{normalizedPrefix}json-schema-file") { Description = "Path to a JSON Schema file for JSON extraction." },
            ActionJson: CreateStringListOption($"--{normalizedPrefix}action-json", "Action JSON object, repeatable and order-preserving."),
            ActionFile: CreateStringListOption($"--{normalizedPrefix}action-file", "Path to a JSON action file, repeatable and order-preserving."),
            LocationCountry: new Option<string>($"--{normalizedPrefix}location-country") { Description = "ISO 3166-1 alpha-2 country code." },
            LocationLanguage: CreateStringListOption($"--{normalizedPrefix}location-language", "Preferred languages for the request."),
            RemoveBase64Images: CreateNullableBoolOption($"--{normalizedPrefix}remove-base64-images", "Remove base64 images from the output."),
            BlockAds: CreateNullableBoolOption($"--{normalizedPrefix}block-ads", "Enable ad and cookie popup blocking."),
            Proxy: new Option<string>($"--{normalizedPrefix}proxy") { Description = "Proxy type: basic, enhanced, auto." },
            ChangeMode: CreateStringListOption($"--{normalizedPrefix}change-mode", "Change tracking mode: git-diff, json."),
            ChangePrompt: new Option<string>($"--{normalizedPrefix}change-prompt") { Description = "Prompt to use for change tracking JSON mode." },
            ChangeTag: new Option<string>($"--{normalizedPrefix}change-tag") { Description = "Change tracking tag." },
            ChangeSchemaJson: new Option<string>($"--{normalizedPrefix}change-schema-json") { Description = "Inline JSON Schema for change tracking JSON mode." },
            ChangeSchemaFile: new Option<string>($"--{normalizedPrefix}change-schema-file") { Description = "Path to a JSON Schema file for change tracking JSON mode." },
            StoreInCache: CreateNullableBoolOption($"--{normalizedPrefix}store-in-cache", "Store the page in Firecrawl cache.")
        );
    }

    public static WebhookOptionSet CreateBatchWebhookOptionSet()
    {
        return new WebhookOptionSet(
            Url: new Option<string>("--webhook-url") { Description = "Webhook URL." },
            Headers: CreateStringListOption("--webhook-header", "Webhook headers as key=value."),
            MetadataPairs: CreateStringListOption("--webhook-metadata", "Webhook metadata as key=value."),
            MetadataJson: new Option<string>("--webhook-metadata-json") { Description = "Inline JSON metadata for the webhook." },
            MetadataFile: new Option<string>("--webhook-metadata-file") { Description = "Path to a JSON metadata file for the webhook." },
            Events: CreateStringListOption("--webhook-event", "Webhook events: completed, page, failed, started.")
        );
    }

    public static WebhookOptionSet CreateCrawlWebhookOptionSet()
    {
        return new WebhookOptionSet(
            Url: new Option<string>("--webhook-url") { Description = "Webhook URL." },
            Headers: CreateStringListOption("--webhook-header", "Webhook headers as key=value."),
            MetadataPairs: CreateStringListOption("--webhook-metadata", "Webhook metadata as key=value."),
            MetadataJson: new Option<string>("--webhook-metadata-json") { Description = "Inline JSON metadata for the webhook." },
            MetadataFile: new Option<string>("--webhook-metadata-file") { Description = "Path to a JSON metadata file for the webhook." },
            Events: CreateStringListOption("--webhook-event", "Webhook events: completed, page, failed, started.")
        );
    }
}

internal sealed record ScrapeOptionSet(
    Option<string[]> Formats,
    Option<bool?> OnlyMainContent,
    Option<string[]> IncludeTags,
    Option<string[]> ExcludeTags,
    Option<int?> MaxAge,
    Option<string[]> Headers,
    Option<int?> WaitFor,
    Option<bool?> Mobile,
    Option<bool?> SkipTlsVerification,
    Option<int?> Timeout,
    Option<bool?> ParsePdf,
    Option<string> JsonPrompt,
    Option<string> JsonSystemPrompt,
    Option<string> JsonSchemaJson,
    Option<string> JsonSchemaFile,
    Option<string[]> ActionJson,
    Option<string[]> ActionFile,
    Option<string> LocationCountry,
    Option<string[]> LocationLanguage,
    Option<bool?> RemoveBase64Images,
    Option<bool?> BlockAds,
    Option<string> Proxy,
    Option<string[]> ChangeMode,
    Option<string> ChangePrompt,
    Option<string> ChangeTag,
    Option<string> ChangeSchemaJson,
    Option<string> ChangeSchemaFile,
    Option<bool?> StoreInCache);

internal sealed record WebhookOptionSet(
    Option<string> Url,
    Option<string[]> Headers,
    Option<string[]> MetadataPairs,
    Option<string> MetadataJson,
    Option<string> MetadataFile,
    Option<string[]> Events);
