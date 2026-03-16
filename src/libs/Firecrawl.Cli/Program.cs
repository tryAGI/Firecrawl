using Firecrawl;
using Firecrawl.Cli;

try
{
    return await CliRoot
        .CreateRootCommand()
        .Parse(args)
        .InvokeAsync()
        .ConfigureAwait(false);
}
catch (CliException ex)
{
    await Console.Error.WriteLineAsync(ex.Message).ConfigureAwait(false);
    return 1;
}
catch (ApiException ex)
{
    await Console.Error.WriteLineAsync(CliRuntime.FormatApiException(ex)).ConfigureAwait(false);
    return 1;
}
