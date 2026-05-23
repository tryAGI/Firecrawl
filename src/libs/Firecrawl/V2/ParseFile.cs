namespace Firecrawl.V2;

/// <summary>
/// Uploaded file payload for the <c>/v2/parse</c> endpoint.
/// </summary>
public sealed class ParseFile
{
    public string Filename { get; }
    public byte[] Content { get; }
    public string? ContentType { get; }

    public ParseFile(string filename, byte[] content, string? contentType = null)
    {
        if (string.IsNullOrWhiteSpace(filename))
            throw new ArgumentException("Filename cannot be empty.", nameof(filename));
        ArgumentNullException.ThrowIfNull(content);
        if (content.Length == 0)
            throw new ArgumentException("File content cannot be empty.", nameof(content));

        Filename = filename;
        Content = content;
        ContentType = contentType;
    }

    /// <summary>
    /// Build a <see cref="ParseFile"/> from raw bytes.
    /// </summary>
    public static ParseFile FromBytes(string filename, byte[] content, string? contentType = null)
        => new(filename, content, contentType);

    /// <summary>
    /// Build a <see cref="ParseFile"/> by reading a file from disk.
    /// </summary>
    public static ParseFile FromPath(string path, string? filename = null, string? contentType = null)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be empty.", nameof(path));
        if (!File.Exists(path))
            throw new FileNotFoundException($"Parse file not found: {path}", path);

        var bytes = File.ReadAllBytes(path);
        var resolvedName = filename ?? Path.GetFileName(path);
        return new ParseFile(resolvedName, bytes, contentType);
    }

    internal string ResolveContentType()
    {
        if (!string.IsNullOrWhiteSpace(ContentType))
            return ContentType;

        var extension = Path.GetExtension(Filename).ToLowerInvariant();
        return extension switch
        {
            ".html" or ".htm" => "text/html",
            ".pdf" => "application/pdf",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".doc" => "application/msword",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".xls" => "application/vnd.ms-excel",
            ".odt" => "application/vnd.oasis.opendocument.text",
            ".rtf" => "application/rtf",
            ".txt" => "text/plain",
            ".md" => "text/markdown",
            ".csv" => "text/csv",
            ".json" => "application/json",
            _ => "application/octet-stream",
        };
    }
}
