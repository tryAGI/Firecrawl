using System.Text.Json;

namespace Firecrawl.Cli.Tests;

[TestClass]
public sealed class CliProcessTests
{
    [TestMethod]
    public async Task Auth_status_uses_file_then_environment_then_option_precedence()
    {
        var homeDirectory = CliTestSupport.CreateTemporaryDirectory();
        try
        {
            var baseEnvironment = new Dictionary<string, string?>
            {
                ["HOME"] = homeDirectory,
                ["FIRECRAWL_API_KEY"] = null,
            };

            var setResult = await CliTestSupport.RunCliAsync(
                ["auth", "set", "file-secret"],
                environmentVariables: baseEnvironment).ConfigureAwait(false);
            setResult.ExitCode.Should().Be(0, setResult.StandardError);

            var fileResult = await CliTestSupport.RunCliAsync(
                ["auth", "status", "--json"],
                environmentVariables: baseEnvironment).ConfigureAwait(false);
            fileResult.ExitCode.Should().Be(0, fileResult.StandardError);
            using (var fileJson = JsonDocument.Parse(fileResult.StandardOutput))
            {
                fileJson.RootElement.GetProperty("Authenticated").GetBoolean().Should().BeTrue();
                fileJson.RootElement.GetProperty("Source").GetString().Should().Be("file");
            }

            var environmentResult = await CliTestSupport.RunCliAsync(
                ["auth", "status", "--json"],
                environmentVariables: new Dictionary<string, string?>(baseEnvironment)
                {
                    ["FIRECRAWL_API_KEY"] = "env-secret",
                }).ConfigureAwait(false);
            environmentResult.ExitCode.Should().Be(0, environmentResult.StandardError);
            using (var environmentJson = JsonDocument.Parse(environmentResult.StandardOutput))
            {
                environmentJson.RootElement.GetProperty("Source").GetString().Should().Be("environment");
                environmentJson.RootElement.GetProperty("ApiKeyHint").GetString().Should().Be("env-...cret");
            }

            var optionResult = await CliTestSupport.RunCliAsync(
                ["auth", "status", "--json", "--api-key", "option-secret"],
                environmentVariables: new Dictionary<string, string?>(baseEnvironment)
                {
                    ["FIRECRAWL_API_KEY"] = "env-secret",
                }).ConfigureAwait(false);
            optionResult.ExitCode.Should().Be(0, optionResult.StandardError);
            using var optionJson = JsonDocument.Parse(optionResult.StandardOutput);
            optionJson.RootElement.GetProperty("Source").GetString().Should().Be("option");
            optionJson.RootElement.GetProperty("ApiKeyHint").GetString().Should().Be("opti...cret");
        }
        finally
        {
            Directory.Delete(homeDirectory, recursive: true);
        }
    }

    [TestMethod]
    public async Task Auth_clear_removes_the_stored_key()
    {
        var homeDirectory = CliTestSupport.CreateTemporaryDirectory();
        try
        {
            var environment = new Dictionary<string, string?>
            {
                ["HOME"] = homeDirectory,
                ["FIRECRAWL_API_KEY"] = null,
            };

            (await CliTestSupport.RunCliAsync(["auth", "set", "file-secret"], environment).ConfigureAwait(false))
                .ExitCode.Should().Be(0);

            var clearResult = await CliTestSupport.RunCliAsync(["auth", "clear"], environment).ConfigureAwait(false);
            clearResult.ExitCode.Should().Be(0, clearResult.StandardError);

            var statusResult = await CliTestSupport.RunCliAsync(["auth", "status", "--json"], environment).ConfigureAwait(false);
            statusResult.ExitCode.Should().Be(0, statusResult.StandardError);

            using var json = JsonDocument.Parse(statusResult.StandardOutput);
            json.RootElement.GetProperty("Authenticated").GetBoolean().Should().BeFalse();
            json.RootElement.GetProperty("Source").GetString().Should().Be("none");
        }
        finally
        {
            Directory.Delete(homeDirectory, recursive: true);
        }
    }
}
