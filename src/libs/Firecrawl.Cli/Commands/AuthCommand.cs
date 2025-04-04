using System.CommandLine;

namespace Firecrawl.Cli.Commands;

internal sealed class AuthCommand : Command
{
    public AuthCommand() : base(
        name: "auth",
        description: "Authenticates with API key")
    {
        var apiKeyOption = new Argument<string>(
            name: "api-key",
            getDefaultValue: () => string.Empty,
            description: "API key");
        AddArgument(apiKeyOption);

        this.SetHandler(
            HandleAsync,
            apiKeyOption);
    }

    private static async Task HandleAsync(
        string apiKey)
    {
        Console.WriteLine("Authenticating with API key...");
        
        var apiKeyPath = Helpers.GetApiKeyPath();
        
        await File.WriteAllTextAsync(apiKeyPath, apiKey).ConfigureAwait(false);
        
        Console.WriteLine("Done.");
    }
}