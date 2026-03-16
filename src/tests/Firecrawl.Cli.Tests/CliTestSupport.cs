using System.CommandLine;
using System.Diagnostics;

namespace Firecrawl.Cli.Tests;

internal static class CliTestSupport
{
    public static RootCommand RootCommand { get; } = CliRoot.CreateRootCommand();

    public static string RepositoryRoot { get; } = FindRepositoryRoot();

    public static string CliAssemblyPath { get; } = FindCliAssemblyPath();

    public static string CreateTemporaryDirectory()
    {
        var path = Path.Combine(Path.GetTempPath(), $"firecrawl-cli-tests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(path);
        return path;
    }

    public static async Task<CliProcessResult> RunCliAsync(
        IReadOnlyList<string> args,
        IReadOnlyDictionary<string, string?>? environmentVariables = null,
        TimeSpan? timeout = null)
    {
        var startInfo = new ProcessStartInfo("dotnet")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            WorkingDirectory = RepositoryRoot,
        };

        startInfo.ArgumentList.Add(CliAssemblyPath);
        foreach (var arg in args)
        {
            startInfo.ArgumentList.Add(arg);
        }

        if (environmentVariables is not null)
        {
            foreach (var pair in environmentVariables)
            {
                if (pair.Value is null)
                {
                    startInfo.Environment.Remove(pair.Key);
                }
                else
                {
                    startInfo.Environment[pair.Key] = pair.Value;
                }
            }
        }

        using var process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Unable to start the Firecrawl CLI process.");

        var stdoutTask = process.StandardOutput.ReadToEndAsync();
        var stderrTask = process.StandardError.ReadToEndAsync();

        using var cancellationTokenSource = new CancellationTokenSource(timeout ?? TimeSpan.FromMinutes(2));
        try
        {
            await process.WaitForExitAsync(cancellationTokenSource.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException ex)
        {
            try
            {
                process.Kill(entireProcessTree: true);
            }
            catch (InvalidOperationException)
            {
            }

            throw new TimeoutException($"Timed out waiting for Firecrawl CLI: {string.Join(' ', args)}", ex);
        }

        var stdout = await stdoutTask.ConfigureAwait(false);
        var stderr = await stderrTask.ConfigureAwait(false);
        return new CliProcessResult(process.ExitCode, stdout, stderr);
    }

    public static IDisposable SetEnvironmentVariable(string key, string? value)
    {
        return new EnvironmentVariableScope(key, value);
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory is not null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "Firecrawl.slnx")))
            {
                return directory.FullName;
            }

            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Unable to locate the repository root.");
    }

    private static string FindCliAssemblyPath()
    {
        var binDirectory = Path.Combine(RepositoryRoot, "src", "libs", "Firecrawl.Cli", "bin");
        var assemblyPath = Directory
            .EnumerateFiles(binDirectory, "Firecrawl.Cli.dll", SearchOption.AllDirectories)
            .OrderByDescending(File.GetLastWriteTimeUtc)
            .FirstOrDefault();

        return assemblyPath
            ?? throw new FileNotFoundException("Unable to locate a built Firecrawl CLI assembly.", binDirectory);
    }

    private sealed class EnvironmentVariableScope : IDisposable
    {
        private readonly string _key;
        private readonly string? _originalValue;

        public EnvironmentVariableScope(string key, string? value)
        {
            _key = key;
            _originalValue = Environment.GetEnvironmentVariable(key);
            Environment.SetEnvironmentVariable(_key, value);
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable(_key, _originalValue);
        }
    }
}

internal sealed record CliProcessResult(int ExitCode, string StandardOutput, string StandardError);
