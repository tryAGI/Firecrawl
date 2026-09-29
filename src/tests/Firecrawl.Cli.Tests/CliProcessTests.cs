using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Firecrawl.Cli.Tests;

[TestClass]
public sealed class CliProcessTests
{
    [TestMethod]
    public async Task Composite_scrape_and_migrated_credit_usage_keep_their_cli_options()
    {
        var scrape = await CliTestSupport.RunCliAsync(
            ["api", "scraping", "scrape-and-extract-from-url", "--help"]).ConfigureAwait(false);
        scrape.ExitCode.Should().Be(0, scrape.StandardError);
        scrape.StandardOutput.Should().Contain("<url>");
        scrape.StandardOutput.Should().Contain("--formats");
        scrape.StandardOutput.Should().Contain("--only-main-content");
        scrape.StandardOutput.Should().Contain("--input");

        var batch = await CliTestSupport.RunCliAsync(
            ["api", "scraping", "scrape-and-extract-from-urls", "--help"]).ConfigureAwait(false);
        batch.ExitCode.Should().Be(0, batch.StandardError);
        batch.StandardOutput.Should().Contain("--urls");
        batch.StandardOutput.Should().Contain("--ignore-invalid-urls");
        batch.StandardOutput.Should().Contain("--formats");

        var credit = await CliTestSupport.RunCliAsync(
            ["team", "credit-usage", "--help"]).ConfigureAwait(false);
        credit.ExitCode.Should().Be(0, credit.StandardError);
        credit.StandardOutput.Should().Contain("team credit-usage");
        credit.StandardOutput.Should().Contain("--output");
    }

    [TestMethod]
    public async Task Migrated_credit_usage_writes_the_existing_text_format_to_a_file()
    {
        var directory = CliTestSupport.CreateTemporaryDirectory();
        var outputPath = Path.Combine(directory, "credit-usage.txt");
        var server = new TcpListener(IPAddress.Loopback, 0);
        server.Start();
        using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
        try
        {
            var port = ((IPEndPoint)server.LocalEndpoint).Port;
            var requestTask = ReplyOnceAsync(
                server,
                "{\"success\":true,\"data\":{\"remaining_credits\":42}}",
                cancellation.Token);
            var result = await CliTestSupport.RunCliAsync(
                ["team", "credit-usage", "--api-key", "test-key",
                    "--base-url", $"http://127.0.0.1:{port}", "--output", outputPath],
                timeout: TimeSpan.FromSeconds(20)).ConfigureAwait(false);

            result.ExitCode.Should().Be(0, result.StandardError);
            (await requestTask.ConfigureAwait(false)).RequestLine
                .Should().Contain("GET /team/credit-usage ");
            (await File.ReadAllTextAsync(outputPath).ConfigureAwait(false))
                .Should().Contain("remaining-credits: 42");
        }
        finally
        {
            await cancellation.CancelAsync().ConfigureAwait(false);
            server.Stop();
            Directory.Delete(directory, recursive: true);
        }
    }

    [TestMethod]
    public async Task Composite_scrape_merges_flags_with_the_input_body()
    {
        var server = new TcpListener(IPAddress.Loopback, 0);
        server.Start();
        using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
        try
        {
            var port = ((IPEndPoint)server.LocalEndpoint).Port;
            var requestTask = ReplyOnceAsync(
                server,
                "{\"success\":true,\"data\":{\"markdown\":\"ok\"}}",
                cancellation.Token);
            var result = await CliTestSupport.RunCliAsync(
                ["api", "scraping", "scrape-and-extract-from-url", "https://from-flag.example",
                    "--formats", "markdown", "--only-main-content", "false",
                    "--input", "{\"url\":\"https://from-input.example\",\"maxAge\":123,\"formats\":[\"html\"],\"onlyMainContent\":true}",
                    "--api-key", "test-key", "--base-url", $"http://127.0.0.1:{port}", "--json"],
                timeout: TimeSpan.FromSeconds(20)).ConfigureAwait(false);

            result.ExitCode.Should().Be(0, result.StandardError);
            var request = await requestTask.ConfigureAwait(false);
            request.RequestLine.Should().Contain("POST /scrape ");
            using var body = JsonDocument.Parse(request.Body);
            body.RootElement.GetProperty("url").GetString().Should().Be("https://from-flag.example");
            body.RootElement.GetProperty("maxAge").GetInt32().Should().Be(123);
            body.RootElement.GetProperty("onlyMainContent").GetBoolean().Should().BeFalse();
            body.RootElement.GetProperty("formats")[0].GetString().Should().Be("markdown");
        }
        finally
        {
            await cancellation.CancelAsync().ConfigureAwait(false);
            server.Stop();
        }
    }

    [TestMethod]
    public async Task Composite_batch_scrape_merges_flags_with_the_input_body()
    {
        var server = new TcpListener(IPAddress.Loopback, 0);
        server.Start();
        using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
        try
        {
            var port = ((IPEndPoint)server.LocalEndpoint).Port;
            var requestTask = ReplyOnceAsync(
                server,
                "{\"success\":true,\"id\":\"test-batch\"}",
                cancellation.Token);
            var result = await CliTestSupport.RunCliAsync(
                ["api", "scraping", "scrape-and-extract-from-urls",
                    "--urls", "https://from-flag.example", "--ignore-invalid-urls", "false",
                    "--formats", "markdown",
                    "--input", "{\"urls\":[\"https://from-input.example\"],\"ignoreInvalidURLs\":true,\"formats\":[\"html\"],\"maxAge\":123}",
                    "--api-key", "test-key", "--base-url", $"http://127.0.0.1:{port}", "--json"],
                timeout: TimeSpan.FromSeconds(20)).ConfigureAwait(false);

            result.ExitCode.Should().Be(0, result.StandardError);
            var request = await requestTask.ConfigureAwait(false);
            request.RequestLine.Should().Contain("POST /batch/scrape ");
            using var body = JsonDocument.Parse(request.Body);
            body.RootElement.GetProperty("urls")[0].GetString().Should().Be("https://from-flag.example");
            body.RootElement.GetProperty("ignoreInvalidURLs").GetBoolean().Should().BeFalse();
            body.RootElement.GetProperty("formats")[0].GetString().Should().Be("markdown");
            body.RootElement.GetProperty("maxAge").GetInt32().Should().Be(123);
        }
        finally
        {
            await cancellation.CancelAsync().ConfigureAwait(false);
            server.Stop();
        }
    }

    private static async Task<(string RequestLine, string Body)> ReplyOnceAsync(
        TcpListener listener,
        string responseBody,
        CancellationToken cancellationToken)
    {
        using var client = await listener.AcceptTcpClientAsync(cancellationToken).ConfigureAwait(false);
        await using var stream = client.GetStream();
        using var reader = new StreamReader(stream, Encoding.ASCII, leaveOpen: true);
        var requestLine = await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false)
            ?? throw new InvalidOperationException("The CLI sent no HTTP request line.");
        var contentLength = 0;
        while (await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false) is { Length: > 0 } line)
        {
            if (line.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
            {
                contentLength = int.Parse(line["Content-Length:".Length..].Trim(),
                    System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        var bodyBuffer = new char[contentLength];
        var count = 0;
        while (count < bodyBuffer.Length)
        {
            var read = await reader.ReadAsync(bodyBuffer.AsMemory(count), cancellationToken).ConfigureAwait(false);
            if (read == 0)
            {
                throw new InvalidOperationException("The CLI closed the HTTP request body early.");
            }

            count += read;
        }

        var response = Encoding.UTF8.GetBytes(
            $"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {Encoding.UTF8.GetByteCount(responseBody)}\r\nConnection: close\r\n\r\n{responseBody}");
        await stream.WriteAsync(response, cancellationToken).ConfigureAwait(false);
        await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        return (requestLine, new string(bodyBuffer));
    }

    [TestMethod]
    public async Task Generated_api_help_lists_shared_root_options_once()
    {
        var result = await CliTestSupport.RunCliAsync(
            ["api", "llms-txt", "generate-llms-txt", "--help"]).ConfigureAwait(false);

        result.ExitCode.Should().Be(0, result.StandardError);
        var optionLines = result.StandardOutput.Split('\n')
            .Select(static line => line.TrimStart())
            .ToArray();
        optionLines.Count(static line =>
                line.StartsWith("-k, --api-key ", StringComparison.Ordinal) ||
                line.StartsWith("--api-key ", StringComparison.Ordinal))
            .Should().Be(1);
        optionLines.Count(static line => line.StartsWith("--base-url ", StringComparison.Ordinal))
            .Should().Be(1);
        optionLines.Count(static line => line.StartsWith("--json ", StringComparison.Ordinal))
            .Should().Be(1);
        optionLines.Count(static line =>
                line.StartsWith("-o, --output ", StringComparison.Ordinal) ||
                line.StartsWith("--output ", StringComparison.Ordinal))
            .Should().Be(1);

        var parseResult = CliTestSupport.RootCommand.Parse(
            ["api", "llms-txt", "generate-llms-txt", "https://example.com",
                "--api-key", "option-key", "--base-url", "https://api.example.com", "--json"]);
        parseResult.Errors.Should().BeEmpty();
        parseResult.GetValue(CliOptions.ApiKey).Should().Be("option-key");
        parseResult.GetValue(CliOptions.BaseUrl).Should().Be("https://api.example.com");
        parseResult.GetValue(CliOptions.Json).Should().BeTrue();
    }

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
