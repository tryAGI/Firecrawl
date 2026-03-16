using System.CommandLine;

namespace Firecrawl.Cli.Tests;

[TestClass]
public sealed class CliParsingTests
{
    private static readonly string TempOutputDirectory = Path.Combine(Path.GetTempPath(), "firecrawl-cli-parser-output");

    [TestMethod]
    public void Command_tree_contains_expected_leaf_commands()
    {
        var actual = CliTestSupport.RootCommand.Subcommands
            .SelectMany(static subcommand => GetLeafCommandPaths(subcommand))
            .OrderBy(static path => path, StringComparer.Ordinal)
            .ToArray();

        actual.Should().BeEquivalentTo(
        [
            "auth clear",
            "auth set",
            "auth status",
            "batch-scrape cancel",
            "batch-scrape errors",
            "batch-scrape start",
            "batch-scrape status",
            "crawl active",
            "crawl cancel",
            "crawl errors",
            "crawl start",
            "crawl status",
            "deep-research start",
            "deep-research status",
            "extract start",
            "extract status",
            "llmstxt generate",
            "llmstxt status",
            "map",
            "scrape",
            "search",
            "team credit-usage",
            "team token-usage",
        ]);
    }

    [TestMethod]
    [DynamicData(nameof(GetRepresentativeParseCases))]
    public void Representative_examples_parse_without_errors(string[] args, string expectedCommandName)
    {
        var parseResult = CliTestSupport.RootCommand.Parse(args);

        parseResult.Errors.Should().BeEmpty();
        parseResult.CommandResult.Command.Name.Should().Be(expectedCommandName);
    }

    [TestMethod]
    public void Root_options_are_available_on_subcommands()
    {
        var parseResult = CliTestSupport.RootCommand.Parse(["scrape", "https://example.com", "--api-key", "option-key", "--base-url", "https://api.example.com", "--json"]);

        parseResult.Errors.Should().BeEmpty();
        parseResult.GetValue(CliOptions.ApiKey).Should().Be("option-key");
        parseResult.GetValue(CliOptions.BaseUrl).Should().Be("https://api.example.com");
        parseResult.GetValue(CliOptions.Json).Should().BeTrue();
    }

    public static IEnumerable<object[]> GetRepresentativeParseCases()
    {
        yield return [new[] { "auth", "set", "test-api-key" }, "set"];
        yield return [new[] { "auth", "clear" }, "clear"];
        yield return [new[] { "auth", "status", "--output", "auth-status.txt" }, "status"];
        yield return [new[] { "scrape", "https://example.com", "--format", "markdown", "--format", "html", "--header", "Accept=text/html", "--mobile", "false" }, "scrape"];
        yield return [new[] { "batch-scrape", "start", "https://example.com", "https://example.org", "--ignore-invalid-urls", "--webhook-url", "https://hooks.example.com/firecrawl", "--webhook-event", "completed", "--wait" }, "start"];
        yield return [new[] { "batch-scrape", "status", "job-123", "--output-dir", TempOutputDirectory }, "status"];
        yield return [new[] { "batch-scrape", "cancel", "job-123" }, "cancel"];
        yield return [new[] { "batch-scrape", "errors", "job-123" }, "errors"];
        yield return [new[] { "crawl", "start", "https://example.com", "--limit", "5", "--scrape-format", "markdown", "--webhook-url", "https://hooks.example.com/crawl", "--webhook-event", "completed", "--wait" }, "start"];
        yield return [new[] { "crawl", "status", "crawl-123", "--output-dir", TempOutputDirectory }, "status"];
        yield return [new[] { "crawl", "cancel", "crawl-123" }, "cancel"];
        yield return [new[] { "crawl", "errors", "crawl-123" }, "errors"];
        yield return [new[] { "crawl", "active" }, "active"];
        yield return [new[] { "map", "https://example.com", "--search", "docs", "--include-subdomains" }, "map"];
        yield return [new[] { "extract", "start", "https://example.com", "--prompt", "Extract title", "--schema-json", "{\"type\":\"object\"}", "--show-sources" }, "start"];
        yield return [new[] { "extract", "status", "extract-123" }, "status"];
        yield return [new[] { "deep-research", "start", "firecrawl docs", "--max-depth", "2", "--format", "markdown", "--json-schema-json", "{\"type\":\"object\"}" }, "start"];
        yield return [new[] { "deep-research", "status", "research-123" }, "status"];
        yield return [new[] { "team", "credit-usage" }, "credit-usage"];
        yield return [new[] { "team", "token-usage" }, "token-usage"];
        yield return [new[] { "search", "firecrawl", "--limit", "3", "--scrape-format", "markdown" }, "search"];
        yield return [new[] { "llmstxt", "generate", "https://example.com", "--max-urls", "5", "--wait" }, "generate"];
        yield return [new[] { "llmstxt", "status", "llmstxt-123" }, "status"];
    }

    private static IEnumerable<string> GetLeafCommandPaths(Command command, string? prefix = null)
    {
        var currentPath = string.IsNullOrWhiteSpace(prefix) ? command.Name : $"{prefix} {command.Name}";
        if (command.Subcommands.Count == 0)
        {
            yield return currentPath;
            yield break;
        }

        foreach (var subcommand in command.Subcommands)
        {
            foreach (var path in GetLeafCommandPaths(subcommand, currentPath))
            {
                yield return path;
            }
        }
    }
}
