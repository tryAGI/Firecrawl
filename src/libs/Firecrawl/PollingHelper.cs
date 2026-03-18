namespace Firecrawl;

internal static class PollingHelper
{
    /// <summary>
    /// Polls a status endpoint until the result satisfies a completion predicate.
    /// </summary>
    internal static async Task<T> PollUntilAsync<T>(
        Func<CancellationToken, Task<T>> fetchStatus,
        Func<T, bool> isComplete,
        string jobDescription,
        TimeSpan? pollingInterval = null,
        IProgress<T>? progress = null,
        TimeSpan? timeout = null,
        CancellationToken cancellationToken = default)
    {
        var delay = pollingInterval ?? TimeSpan.FromSeconds(1);

        using var cts = timeout.HasValue
            ? CancellationTokenSource.CreateLinkedTokenSource(cancellationToken)
            : null;
        cts?.CancelAfter(timeout!.Value);
        var token = cts?.Token ?? cancellationToken;

        try
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(delay, token).ConfigureAwait(false);

                var response = await fetchStatus(token).ConfigureAwait(false);

                progress?.Report(response);

                if (isComplete(response))
                {
                    return response;
                }
            }
        }
        catch (OperationCanceledException) when (timeout.HasValue && !cancellationToken.IsCancellationRequested)
        {
            throw new TimeoutException($"{jobDescription} did not complete within {timeout.Value}.");
        }
    }
}
