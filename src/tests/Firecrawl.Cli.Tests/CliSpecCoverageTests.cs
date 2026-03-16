namespace Firecrawl.Cli.Tests;

[TestClass]
public sealed class CliSpecCoverageTests
{
    [TestMethod]
    public void Supported_operation_ids_match_openapi_spec()
    {
        var specPath = Path.Combine(CliTestSupport.RepositoryRoot, "src", "libs", "Firecrawl", "openapi.yaml");
        var expected = ExtractNonDeprecatedOperationIds(specPath);

        CliRoot.SupportedOperationIds.Should().OnlyHaveUniqueItems();
        CliRoot.SupportedOperationIds.Should().BeEquivalentTo(expected);
    }

    private static IReadOnlyCollection<string> ExtractNonDeprecatedOperationIds(string specPath)
    {
        var lines = File.ReadAllLines(specPath);
        var results = new List<string>();

        string? currentOperationId = null;
        var currentDeprecated = false;
        var currentMethodIndent = -1;

        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith('#'))
            {
                continue;
            }

            var indent = line.Length - line.TrimStart().Length;
            if (IsHttpMethodLine(trimmed))
            {
                FlushCurrentOperation();
                currentMethodIndent = indent;
                continue;
            }

            if (currentMethodIndent >= 0 && indent <= currentMethodIndent && trimmed.EndsWith(':'))
            {
                FlushCurrentOperation();
                currentMethodIndent = -1;
            }

            if (currentMethodIndent < 0)
            {
                continue;
            }

            if (trimmed.StartsWith("operationId:", StringComparison.Ordinal))
            {
                currentOperationId = trimmed["operationId:".Length..].Trim();
                continue;
            }

            if (trimmed.StartsWith("deprecated:", StringComparison.Ordinal))
            {
                currentDeprecated = string.Equals(
                    trimmed["deprecated:".Length..].Trim(),
                    "true",
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        FlushCurrentOperation();
        return results;

        void FlushCurrentOperation()
        {
            if (!string.IsNullOrWhiteSpace(currentOperationId) && !currentDeprecated)
            {
                results.Add(currentOperationId);
            }

            currentOperationId = null;
            currentDeprecated = false;
        }
    }

    private static bool IsHttpMethodLine(string trimmed)
    {
        return trimmed is "get:" or "post:" or "put:" or "patch:" or "delete:" or "head:" or "options:" or "trace:";
    }
}
