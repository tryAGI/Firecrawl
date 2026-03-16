using System.CommandLine;
using System.CommandLine.Parsing;

namespace Firecrawl.Cli;

internal static partial class CliCommands
{
    public static Command CreateAuthCommand()
    {
        var auth = new Command("auth", "Manage stored Firecrawl authentication.");
        auth.Subcommands.Add(CreateAuthSetCommand());
        auth.Subcommands.Add(CreateAuthClearCommand());
        auth.Subcommands.Add(CreateAuthStatusCommand());
        return auth;
    }

    private static Command CreateAuthSetCommand()
    {
        var apiKeyArgument = new Argument<string>("api-key")
        {
            Description = "API key to store under ~/.firecrawl/apiKey.txt.",
        };

        var command = new Command("set", "Store an API key for future CLI invocations.");
        command.Arguments.Add(apiKeyArgument);
        command.SetAction(async parseResult =>
        {
            var apiKey = parseResult.GetValue(apiKeyArgument);
            await File.WriteAllTextAsync(CliRuntime.GetApiKeyPath(), apiKey).ConfigureAwait(false);
            await CliRuntime.WriteOutputAsync(
                parseResult,
                new { success = true, source = "file", path = CliRuntime.GetApiKeyPath() },
                $"Stored API key at {CliRuntime.GetApiKeyPath()}",
                outputPath: null).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateAuthClearCommand()
    {
        var command = new Command("clear", "Delete the stored API key.");
        command.SetAction(async parseResult =>
        {
            var apiKeyPath = CliRuntime.GetApiKeyPath();
            if (File.Exists(apiKeyPath))
            {
                File.Delete(apiKeyPath);
            }

            await CliRuntime.WriteOutputAsync(
                parseResult,
                new { success = true, path = apiKeyPath },
                $"Cleared stored API key at {apiKeyPath}",
                outputPath: null).ConfigureAwait(false);
        });

        return command;
    }

    private static Command CreateAuthStatusCommand()
    {
        var outputOption = CliOptions.CreateOutputOption();

        var command = new Command("status", "Show which authentication source the CLI will use.");
        command.Options.Add(outputOption);
        command.SetAction(async parseResult =>
        {
            var status = await CliRuntime.GetAuthStatusAsync(parseResult).ConfigureAwait(false);
            var human = status.Authenticated
                ? $"authenticated: true{Environment.NewLine}source: {status.Source}{Environment.NewLine}api-key: {status.ApiKeyHint}{Environment.NewLine}path: {status.Path ?? "<none>"}"
                : $"authenticated: false{Environment.NewLine}source: {status.Source}{Environment.NewLine}path: {status.Path ?? "<none>"}";

            await CliRuntime.WriteOutputAsync(
                parseResult,
                status,
                human,
                parseResult.GetValue(outputOption)).ConfigureAwait(false);
        });

        return command;
    }
}
