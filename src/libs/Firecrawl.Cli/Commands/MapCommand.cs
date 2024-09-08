using System.CommandLine;

namespace Firecrawl.Cli.Commands;

public class MapCommand : Command
{
    public MapCommand() : base(
        name: "map",
        description: "Attempts to output all website's urls in a few seconds.")
    {
        var url = new Argument<string>(
            name: "url",
            getDefaultValue: () => string.Empty,
            description: "Input url");
        AddArgument(url);
        
        var outputPath = new Option<string>(
            aliases: ["--output", "-o"],
            getDefaultValue: () => string.Empty,
            description: "Output path");
        AddOption(outputPath);
        
        this.SetHandler(
            HandleAsync,
            url,
            outputPath);
    }

    private static async Task HandleAsync(
        string url,
        string outputPath)
    {
        Console.WriteLine("Initializing...");
        
        var apiKey = await Helpers.GetApiKey().ConfigureAwait(false);
        using var api = new FirecrawlApp(apiKey);
        
        Console.WriteLine($"Maps {url}...");

        Console.WriteLine("Done.");
    }
}