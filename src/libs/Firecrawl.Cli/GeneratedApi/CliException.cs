#nullable enable

namespace Firecrawl.Cli.GeneratedApi;

internal sealed class CliException : Exception
{
    public CliException()
    {
    }

    public CliException(string message) : base(message)
    {
    }

    public CliException(string message, Exception innerException) : base(message, innerException)
    {
    }
}