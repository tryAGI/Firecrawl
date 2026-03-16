using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.Json;

namespace Firecrawl.Cli.Tests;

[TestClass]
public sealed class CliRuntimeTests
{
    [TestMethod]
    public void Resolve_base_url_prefers_option_over_environment()
    {
        using var _ = CliTestSupport.SetEnvironmentVariable("FIRECRAWL_BASE_URL", "https://env.example.com");

        var parseResult = CliTestSupport.RootCommand.Parse(["map", "https://example.com", "--base-url", "https://option.example.com"]);

        CliRuntime.ResolveBaseUrl(parseResult).Should().Be("https://option.example.com");
    }

    [TestMethod]
    public void Resolve_base_url_uses_environment_when_option_is_missing()
    {
        using var _ = CliTestSupport.SetEnvironmentVariable("FIRECRAWL_BASE_URL", "https://env.example.com");

        var parseResult = CliTestSupport.RootCommand.Parse(["map", "https://example.com"]);

        CliRuntime.ResolveBaseUrl(parseResult).Should().Be("https://env.example.com");
    }

    [TestMethod]
    public void Parse_key_value_pairs_supports_repeatable_flags()
    {
        var pairs = CliRuntime.ParseKeyValuePairs(["Accept=text/html", "X-Test=1"]);

        pairs.Should().Equal(
            new KeyValuePair<string, string>("Accept", "text/html"),
            new KeyValuePair<string, string>("X-Test", "1"));
    }

    [TestMethod]
    public void Parse_key_value_pairs_rejects_invalid_values()
    {
        var action = () => CliRuntime.ParseKeyValuePairs(["missing-separator"]);

        action.Should().Throw<CliException>()
            .WithMessage("Expected key=value*");
    }

    [TestMethod]
    public async Task Read_json_value_supports_inline_and_file_inputs()
    {
        var inlineOption = new Option<string>("--schema-json");
        var fileOption = new Option<string>("--schema-file");
        var command = new Command("test");
        command.Options.Add(inlineOption);
        command.Options.Add(fileOption);

        var inlineParseResult = command.Parse(["--schema-json", "{\"type\":\"object\"}"]);
        var inlineValue = await CliRuntime.ReadJsonValueAsync(inlineParseResult, inlineOption, fileOption).ConfigureAwait(false);

        inlineValue.Should().NotBeNull();
        JsonSerializer.Serialize(inlineValue).Should().Be("{\"type\":\"object\"}");

        var filePath = Path.GetTempFileName();
        try
        {
            await File.WriteAllTextAsync(filePath, "{\"type\":\"string\"}").ConfigureAwait(false);
            var fileParseResult = command.Parse(["--schema-file", filePath]);
            var fileValue = await CliRuntime.ReadJsonValueAsync(fileParseResult, inlineOption, fileOption).ConfigureAwait(false);

            fileValue.Should().NotBeNull();
            JsonSerializer.Serialize(fileValue).Should().Be("{\"type\":\"string\"}");
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [TestMethod]
    public async Task Read_json_value_rejects_inline_and_file_together()
    {
        var inlineOption = new Option<string>("--schema-json");
        var fileOption = new Option<string>("--schema-file");
        var command = new Command("test");
        command.Options.Add(inlineOption);
        command.Options.Add(fileOption);

        var filePath = Path.GetTempFileName();
        try
        {
            var parseResult = command.Parse(["--schema-json", "{\"type\":\"object\"}", "--schema-file", filePath]);
            var action = async () => await CliRuntime.ReadJsonValueAsync(parseResult, inlineOption, fileOption).ConfigureAwait(false);

            await action.Should().ThrowAsync<CliException>()
                .WithMessage("Options '--schema-json' and '--schema-file' cannot be used together.");
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [TestMethod]
    public void Apply_scrape_options_binds_prefixed_nested_options_and_repeatables()
    {
        var options = CliOptions.CreateScrapeOptionSet("scrape");
        var command = new Command("test");
        AddScrapeOptions(command, options);

        var parseResult = command.Parse(
        [
            "--scrape-format", "markdown",
            "--scrape-format", "html",
            "--scrape-header", "Accept=text/html",
            "--scrape-header", "X-Test=1",
            "--scrape-mobile",
            "--scrape-block-ads", "false",
            "--scrape-json-prompt", "Extract the title",
            "--scrape-json-schema-json", "{\"type\":\"object\"}",
            "--scrape-location-country", "US",
            "--scrape-location-language", "en",
            "--scrape-change-mode", "git-diff",
            "--scrape-change-tag", "nightly",
            "--scrape-change-schema-json", "{\"type\":\"object\"}",
            "--scrape-store-in-cache",
        ]);

        var target = new ScrapeOptions();
        CliRuntime.ApplyScrapeOptions(parseResult, options, target);

        target.Formats.Should().ContainInOrder(ScrapeOptionsFormat.Markdown, ScrapeOptionsFormat.Html);
        JsonSerializer.Serialize(target.Headers).Should().Be("{\"Accept\":\"text/html\",\"X-Test\":\"1\"}");
        target.Mobile.Should().BeTrue();
        target.BlockAds.Should().BeFalse();
        target.JsonOptions.Should().NotBeNull();
        target.JsonOptions!.Prompt.Should().Be("Extract the title");
        JsonSerializer.Serialize(target.JsonOptions.Schema).Should().Be("{\"type\":\"object\"}");
        target.Location.Should().NotBeNull();
        target.Location!.Country.Should().Be("US");
        target.Location.Languages.Should().ContainSingle().Which.Should().Be("en");
        target.ChangeTrackingOptions.Should().NotBeNull();
        target.ChangeTrackingOptions!.Modes.Should().ContainSingle().Which.Should().Be(ScrapeOptionsChangeTrackingOptionsMode.GitDiff);
        target.ChangeTrackingOptions.Tag.Should().Be("nightly");
        JsonSerializer.Serialize(target.ChangeTrackingOptions.Schema).Should().Be("{\"type\":\"object\"}");
        target.StoreInCache.Should().BeTrue();
    }

    [TestMethod]
    public void Parse_actions_preserves_order_across_inline_and_file_payloads()
    {
        var filePath = Path.GetTempFileName();
        try
        {
            File.WriteAllText(filePath, "{\"type\":\"scroll\",\"direction\":\"down\"}");

            var actions = CliRuntime.ParseActions(
                inlineJson: ["{\"type\":\"wait\",\"milliseconds\":100}"],
                filePaths: [filePath]);

            actions.Should().NotBeNull();
            actions!.Should().HaveCount(2);
            actions[0].IsValue1.Should().BeTrue();
            actions[0].Value1!.Milliseconds.Should().Be(100);
            actions[1].IsValue6.Should().BeTrue();
            actions[1].Value6!.Direction.Should().Be(ScrapeOptionsActionScrollDirection.Down);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [TestMethod]
    public async Task Write_output_uses_human_text_by_default_and_json_when_requested()
    {
        var humanPath = Path.Combine(CliTestSupport.CreateTemporaryDirectory(), "human.txt");
        var jsonPath = Path.Combine(CliTestSupport.CreateTemporaryDirectory(), "json.txt");

        try
        {
            var humanParseResult = CliTestSupport.RootCommand.Parse([]);
            var jsonParseResult = CliTestSupport.RootCommand.Parse(["--json"]);

            await CliRuntime.WriteOutputAsync(humanParseResult, new { success = true }, "human output", humanPath).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(jsonParseResult, new { success = true }, "human output", jsonPath).ConfigureAwait(false);

            (await File.ReadAllTextAsync(humanPath).ConfigureAwait(false)).Should().Be("human output");
            (await File.ReadAllTextAsync(jsonPath).ConfigureAwait(false)).Should().Contain("\"success\": true");
        }
        finally
        {
            Directory.Delete(Path.GetDirectoryName(humanPath)!, recursive: true);
            Directory.Delete(Path.GetDirectoryName(jsonPath)!, recursive: true);
        }
    }

    [TestMethod]
    public async Task Poll_async_returns_when_the_result_is_complete()
    {
        var attempts = 0;

        var result = await CliRuntime.PollAsync(
            fetchAsync: async () =>
            {
                await Task.Yield();
                attempts++;
                return attempts;
            },
            isComplete: static value => value >= 3,
            pollInterval: TimeSpan.FromMilliseconds(1),
            waitTimeout: TimeSpan.FromSeconds(1)).ConfigureAwait(false);

        result.Should().Be(3);
        attempts.Should().Be(3);
    }

    [TestMethod]
    [DataRow("500ms", 500)]
    [DataRow("2s", 2000)]
    [DataRow("3m", 180000)]
    [DataRow("1h", 3600000)]
    [DataRow("00:00:01", 1000)]
    public void Parse_duration_supports_cli_friendly_values(string value, int expectedMilliseconds)
    {
        CliRuntime.ParseDuration(value, "--wait-timeout").Should().Be(TimeSpan.FromMilliseconds(expectedMilliseconds));
    }

    private static void AddScrapeOptions(Command command, ScrapeOptionSet options)
    {
        command.Options.Add(options.Formats);
        command.Options.Add(options.Headers);
        command.Options.Add(options.Mobile);
        command.Options.Add(options.BlockAds);
        command.Options.Add(options.JsonPrompt);
        command.Options.Add(options.JsonSchemaJson);
        command.Options.Add(options.LocationCountry);
        command.Options.Add(options.LocationLanguage);
        command.Options.Add(options.ChangeMode);
        command.Options.Add(options.ChangeTag);
        command.Options.Add(options.ChangeSchemaJson);
        command.Options.Add(options.StoreInCache);
    }
}
