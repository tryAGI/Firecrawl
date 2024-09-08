namespace Firecrawl.Cli;

public static class Helpers
{
    public static string GetSettingsFolder()
    {
        var folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".firecrawl");
        Directory.CreateDirectory(folder);

        return folder;
    }
    
    public static string GetApiKeyPath()
    {
        return Path.Combine(GetSettingsFolder(), "apiKey.txt");
    }

    public static async Task<string> GetApiKey()
    {
        var apiKeyPath = GetApiKeyPath();
        if (!File.Exists(apiKeyPath))
        {
            throw new InvalidOperationException("API key is not found. Please run 'auth' command first.");
        }
        
        return await File.ReadAllTextAsync(apiKeyPath).ConfigureAwait(false);
    }
}