using System.Text;
using System.Text.RegularExpressions;

var solutionDirectory = args.ElementAtOrDefault(0) ??
                        Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../.."));
var sampleDirectory = Path.Combine(solutionDirectory, "src", "tests", "IntegrationTests");
var mkDocsPath = Path.Combine(solutionDirectory, "mkdocs.yml");
var docsDirectory = Path.Combine(solutionDirectory, "docs");
var docsSamplesDirectory = Path.Combine(docsDirectory, "samples");

Directory.CreateDirectory(docsSamplesDirectory);

foreach (var path in Directory.EnumerateFiles(docsSamplesDirectory, "*.md", SearchOption.TopDirectoryOnly))
{
    File.Delete(path);
}

File.Copy(
    Path.Combine(solutionDirectory, "README.md"),
    Path.Combine(docsDirectory, "index.md"),
    overwrite: true);

Console.WriteLine($"Generating samples from {sampleDirectory}...");

var samples = Directory
    .EnumerateFiles(sampleDirectory, "Tests.*.cs", SearchOption.AllDirectories)
    .OrderBy(Path.GetFileName, StringComparer.Ordinal)
    .Select(LoadSample)
    .ToList();

if (samples.Count == 0)
{
    throw new InvalidOperationException($"No documentation samples were found in '{sampleDirectory}'.");
}

foreach (var sample in samples)
{
    var newPath = Path.Combine(docsSamplesDirectory, $"{sample.Name}.md");
    await File.WriteAllTextAsync(newPath, $@"```csharp
{sample.Code}
```");
}

var mkDocs = NormalizeNewlines(await File.ReadAllTextAsync(mkDocsPath));
mkDocs = ReplaceBlock(
    mkDocs,
    "# EXAMPLES:START",
    "# EXAMPLES:END",
    BuildMkDocsExamples(samples));
await File.WriteAllTextAsync(mkDocsPath, mkDocs);

static SampleDocument LoadSample(string path)
{
    var source = NormalizeNewlines(File.ReadAllText(path));
    var body = TryExtractMethodBody(source) ??
               TryExtractMethodBody(UncommentDisabledCode(source)) ??
               throw new InvalidOperationException($"Could not extract a sample method body from '{path}'.");

    return new SampleDocument(
        GetSampleName(path),
        TransformCode(body));
}

static string? TryExtractMethodBody(string source)
{
    var match = Regex.Match(source, @"(?m)^[ \t]*public\s+(?:async\s+)?Task\s+\w+\s*\(");
    if (!match.Success)
    {
        return null;
    }

    var openBraceIndex = source.IndexOf('{', match.Index + match.Length);
    if (openBraceIndex < 0)
    {
        return null;
    }

    var closeBraceIndex = FindMatchingBrace(source, openBraceIndex);
    if (closeBraceIndex < 0)
    {
        return null;
    }

    return source[(openBraceIndex + 1)..closeBraceIndex];
}

static int FindMatchingBrace(string text, int openBraceIndex)
{
    var depth = 0;
    var inLineComment = false;
    var inBlockComment = false;
    var inString = false;
    var inChar = false;
    var isVerbatimString = false;

    for (var index = openBraceIndex; index < text.Length; index++)
    {
        var current = text[index];
        var next = index + 1 < text.Length ? text[index + 1] : '\0';
        var nextNext = index + 2 < text.Length ? text[index + 2] : '\0';

        if (inLineComment)
        {
            if (current == '\n')
            {
                inLineComment = false;
            }

            continue;
        }

        if (inBlockComment)
        {
            if (current == '*' && next == '/')
            {
                inBlockComment = false;
                index++;
            }

            continue;
        }

        if (inString)
        {
            if (isVerbatimString)
            {
                if (current == '"' && next == '"')
                {
                    index++;
                    continue;
                }

                if (current == '"')
                {
                    inString = false;
                    isVerbatimString = false;
                }
            }
            else
            {
                if (current == '\\')
                {
                    index++;
                    continue;
                }

                if (current == '"')
                {
                    inString = false;
                }
            }

            continue;
        }

        if (inChar)
        {
            if (current == '\\')
            {
                index++;
                continue;
            }

            if (current == '\'')
            {
                inChar = false;
            }

            continue;
        }

        if (current == '/' && next == '/')
        {
            inLineComment = true;
            index++;
            continue;
        }

        if (current == '/' && next == '*')
        {
            inBlockComment = true;
            index++;
            continue;
        }

        if (current == '@' && next == '"')
        {
            inString = true;
            isVerbatimString = true;
            index++;
            continue;
        }

        if (current == '$' && next == '"')
        {
            inString = true;
            isVerbatimString = false;
            index++;
            continue;
        }

        if ((current == '$' && next == '@' && nextNext == '"') ||
            (current == '@' && next == '$' && nextNext == '"'))
        {
            inString = true;
            isVerbatimString = true;
            index += 2;
            continue;
        }

        if (current == '"')
        {
            inString = true;
            isVerbatimString = false;
            continue;
        }

        if (current == '\'')
        {
            inChar = true;
            continue;
        }

        if (current == '{')
        {
            depth++;
        }
        else if (current == '}')
        {
            depth--;
            if (depth == 0)
            {
                return index;
            }
        }
    }

    return -1;
}

static string UncommentDisabledCode(string source)
{
    return string.Join(
        '\n',
        NormalizeNewlines(source)
            .Split('\n')
            .Select(UncommentLine));
}

static string UncommentLine(string line)
{
    var indentationLength = line.TakeWhile(char.IsWhiteSpace).Count();
    var indentation = line[..indentationLength];
    var remainder = line[indentationLength..];

    if (!remainder.StartsWith("//", StringComparison.Ordinal))
    {
        return line;
    }

    remainder = remainder[2..];
    if (remainder.StartsWith(' '))
    {
        remainder = remainder[1..];
    }

    return indentation + remainder;
}

static string TransformCode(string code)
{
    var lines = Deindent(code)
        .Split('\n')
        .Select(line => line.TrimEnd())
        .ToList();

    var output = new List<string>(lines.Count);
    var previousWasBlank = false;

    foreach (var originalLine in lines)
    {
        var line = originalLine
            .Replace("using var client = GetAuthenticatedClient();", "using var client = new FirecrawlClient(apiKey);");

        var trimmed = line.Trim();
        if (trimmed.Contains(".Should()", StringComparison.Ordinal) ||
            trimmed.Contains(".Should(", StringComparison.Ordinal) ||
            trimmed.StartsWith("Assert.", StringComparison.Ordinal))
        {
            continue;
        }

        if (string.IsNullOrWhiteSpace(line))
        {
            if (previousWasBlank)
            {
                continue;
            }

            previousWasBlank = true;
            output.Add(string.Empty);
            continue;
        }

        previousWasBlank = false;
        output.Add(line);
    }

    return string.Join('\n', output).Trim();
}

static string Deindent(string text)
{
    var lines = NormalizeNewlines(text).Split('\n').ToList();

    while (lines.Count > 0 && string.IsNullOrWhiteSpace(lines[0]))
    {
        lines.RemoveAt(0);
    }

    while (lines.Count > 0 && string.IsNullOrWhiteSpace(lines[^1]))
    {
        lines.RemoveAt(lines.Count - 1);
    }

    var indentation = lines
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Select(line => line.TakeWhile(char.IsWhiteSpace).Count())
        .DefaultIfEmpty(0)
        .Min();

    return string.Join(
        '\n',
        lines.Select(line => line.Length >= indentation ? line[indentation..] : line));
}

static string BuildMkDocsExamples(IReadOnlyList<SampleDocument> samples)
{
    var builder = new StringBuilder();
    builder.AppendLine("- Examples:");

    foreach (var sample in samples)
    {
        builder.AppendLine($"  - {sample.Name}: samples/{sample.Name}.md");
    }

    return builder.ToString().TrimEnd();
}

static string ReplaceBlock(string content, string startMarker, string endMarker, string replacement)
{
    var start = content.IndexOf(startMarker, StringComparison.Ordinal);
    if (start < 0)
    {
        throw new InvalidOperationException($"Start marker '{startMarker}' was not found.");
    }

    var end = content.IndexOf(endMarker, start + startMarker.Length, StringComparison.Ordinal);
    if (end < 0)
    {
        throw new InvalidOperationException($"End marker '{endMarker}' was not found.");
    }

    var before = content[..(start + startMarker.Length)];
    var after = content[end..];

    return $"{before}\n{replacement}\n{after}";
}

static string NormalizeNewlines(string text)
{
    return text.Replace("\r\n", "\n");
}

static string GetSampleName(string path)
{
    return Path.GetExtension(Path.GetFileNameWithoutExtension(path)).TrimStart('.');
}

internal sealed record SampleDocument(string Name, string Code);
