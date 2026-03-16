using System.Text.Json;

namespace Firecrawl.Cli.Tests;

[TestClass]
public sealed class CliLiveIntegrationTests
{
    [TestMethod]
    [TestCategory("Live")]
    public async Task Scrape_command_returns_success_when_api_key_is_available()
    {
        var apiKey = RequireApiKey();

        var result = await CliTestSupport.RunCliAsync(
            ["scrape", "https://example.com", "--format", "markdown", "--json", "--api-key", apiKey],
            timeout: TimeSpan.FromMinutes(3)).ConfigureAwait(false);

        result.ExitCode.Should().Be(0, result.StandardError);
        using var json = JsonDocument.Parse(result.StandardOutput);
        json.RootElement.GetProperty("success").GetBoolean().Should().BeTrue();
        json.RootElement.GetProperty("data").TryGetProperty("markdown", out _).Should().BeTrue();
    }

    [TestMethod]
    [TestCategory("Live")]
    public async Task Crawl_command_wait_returns_status_when_api_key_is_available()
    {
        var apiKey = RequireApiKey();

        var result = await CliTestSupport.RunCliAsync(
            [
                "crawl",
                "start",
                "https://example.com",
                "--limit",
                "1",
                "--wait",
                "--poll-interval",
                "2s",
                "--wait-timeout",
                "2m",
                "--json",
                "--api-key",
                apiKey,
            ],
            timeout: TimeSpan.FromMinutes(4)).ConfigureAwait(false);

        result.ExitCode.Should().Be(0, result.StandardError);
        using var json = JsonDocument.Parse(result.StandardOutput);
        json.RootElement.TryGetProperty("status", out _).Should().BeTrue();
    }

    [TestMethod]
    [TestCategory("Live")]
    public async Task Team_credit_usage_returns_success_when_api_key_is_available()
    {
        var apiKey = RequireApiKey();

        var result = await CliTestSupport.RunCliAsync(
            ["team", "credit-usage", "--json", "--api-key", apiKey],
            timeout: TimeSpan.FromMinutes(2)).ConfigureAwait(false);

        result.ExitCode.Should().Be(0, result.StandardError);
        using var json = JsonDocument.Parse(result.StandardOutput);
        json.RootElement.GetProperty("success").GetBoolean().Should().BeTrue();
    }

    private static string RequireApiKey()
    {
        var apiKey = Environment.GetEnvironmentVariable("FIRECRAWL_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            apiKey = TryReadDotEnvValue("FIRECRAWL_API_KEY");
        }

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Assert.Inconclusive("Set FIRECRAWL_API_KEY or add it to .env to run live CLI integration tests.");
        }

        return apiKey;
    }

    private static string? TryReadDotEnvValue(string key)
    {
        var path = Path.Combine(CliTestSupport.RepositoryRoot, ".env");
        if (!File.Exists(path))
        {
            return null;
        }

        foreach (var rawLine in File.ReadLines(path))
        {
            var line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
            {
                continue;
            }

            var separatorIndex = line.IndexOf('=', StringComparison.Ordinal);
            if (separatorIndex <= 0)
            {
                continue;
            }

            var currentKey = line[..separatorIndex].Trim();
            if (!string.Equals(currentKey, key, StringComparison.Ordinal))
            {
                continue;
            }

            return line[(separatorIndex + 1)..].Trim().Trim('"');
        }

        return null;
    }
}
