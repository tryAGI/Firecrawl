namespace Firecrawl.V2;

/// <summary>
/// Thin compatibility shim around <see cref="AutoSDKUploadFile"/>, kept so
/// existing callers using <c>Firecrawl.V2.ParseFile</c> keep compiling.
/// New code should construct <see cref="AutoSDKUploadFile"/> directly.
/// </summary>
public static class ParseFile
{
    /// <inheritdoc cref="AutoSDKUploadFile.FromBytes(string, byte[], string?)" />
    public static AutoSDKUploadFile FromBytes(string filename, byte[] content, string? contentType = null)
        => AutoSDKUploadFile.FromBytes(filename, content, contentType);

    /// <inheritdoc cref="AutoSDKUploadFile.FromPath(string, string?, string?)" />
    public static AutoSDKUploadFile FromPath(string path, string? filename = null, string? contentType = null)
        => AutoSDKUploadFile.FromPath(path, filename, contentType);

    /// <inheritdoc cref="AutoSDKUploadFile.FromStream(string, System.IO.Stream, string?, bool)" />
    public static AutoSDKUploadFile FromStream(string filename, System.IO.Stream stream, string? contentType = null, bool leaveOpen = false)
        => AutoSDKUploadFile.FromStream(filename, stream, contentType, leaveOpen);
}
