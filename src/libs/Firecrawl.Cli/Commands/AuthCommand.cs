using System.CommandLine;

namespace Firecrawl.Cli.Commands;

internal sealed class AuthCommand : Command
{
    public AuthCommand() : base(
        name: "auth",
        description: "Authenticates with API key")
    {
        var apiKeyOption = new Argument<string>(
            name: "api-key")
        {
            Description = "API key",
            DefaultValueFactory = _ => string.Empty,
        };
        Arguments.Add(apiKeyOption);

        SetAction(HandleAsync);
    }

    private static async Task HandleAsync(
        ParseResult parseResult)
    {
        var apiKey = parseResult.GetValue<string>("api-key");
        
        Console.WriteLine("Authenticating with API key...");
        
        var apiKeyPath = Helpers.GetApiKeyPath();
        
        await File.WriteAllTextAsync(apiKeyPath, apiKey).ConfigureAwait(false);
        
        Console.WriteLine("Done.");
    }
}