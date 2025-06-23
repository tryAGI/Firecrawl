using System.CommandLine;

namespace Firecrawl.Cli.Commands;

internal sealed class MapCommand : Command
{
    private Argument<string> Url { get; } = new(
        name: "url")
    {
        DefaultValueFactory = _ => string.Empty,
        Description = "Input url",
    };
    
    private Option<string> OutputPath { get; } = new(
        name: "--output",
        aliases: ["-o"])
    {
        DefaultValueFactory = _ => string.Empty,
        Description = "Output path",
    };
    
    public MapCommand() : base(
        name: "map",
        description: "Attempts to output all website's urls in a few seconds.")
    {
        Arguments.Add(Url);
        Options.Add(OutputPath);
        
        SetAction(HandleAsync);
    }

    private async Task HandleAsync(ParseResult parseResult)
    {
        var url = parseResult.GetRequiredValue(Url);
        var outputPath = parseResult.GetRequiredValue(OutputPath);
        
        Console.WriteLine("Initializing...");
        
        var apiKey = await Helpers.GetApiKey().ConfigureAwait(false);
        using var api = new FirecrawlApp(apiKey);
        
        Console.WriteLine($"Maps {url}...");

        Console.WriteLine("Done.");
    }
}