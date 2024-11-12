
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CrawlStatusResponseObj
    {
        /// <summary>
        /// Markdown content of the page if the `markdown` format was specified (default)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("markdown")]
        public string? Markdown { get; set; }

        /// <summary>
        /// HTML version of the content on page if the `html` format was specified
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("html")]
        public string? Html { get; set; }

        /// <summary>
        /// Raw HTML content of the page if the `rawHtml` format was specified
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("rawHtml")]
        public string? RawHtml { get; set; }

        /// <summary>
        /// Links on the page if the `links` format was specified
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("links")]
        public global::System.Collections.Generic.IList<string>? Links { get; set; }

        /// <summary>
        /// URL of the screenshot of the page if the `screenshot` or `screenshot@fullSize` format was specified
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("screenshot")]
        public string? Screenshot { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("metadata")]
        public global::Firecrawl.CrawlStatusResponseObjMetadata? Metadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlStatusResponseObj" /> class.
        /// </summary>
        /// <param name="markdown">
        /// Markdown content of the page if the `markdown` format was specified (default)
        /// </param>
        /// <param name="html">
        /// HTML version of the content on page if the `html` format was specified
        /// </param>
        /// <param name="rawHtml">
        /// Raw HTML content of the page if the `rawHtml` format was specified
        /// </param>
        /// <param name="links">
        /// Links on the page if the `links` format was specified
        /// </param>
        /// <param name="screenshot">
        /// URL of the screenshot of the page if the `screenshot` or `screenshot@fullSize` format was specified
        /// </param>
        /// <param name="metadata"></param>
        /// <param name="url"></param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public CrawlStatusResponseObj(
            string? markdown,
            string? html,
            string? rawHtml,
            global::System.Collections.Generic.IList<string>? links,
            string? screenshot,
            global::Firecrawl.CrawlStatusResponseObjMetadata? metadata,
            string? url)
        {
            this.Markdown = markdown;
            this.Html = html;
            this.RawHtml = rawHtml;
            this.Links = links;
            this.Screenshot = screenshot;
            this.Metadata = metadata;
            this.Url = url;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlStatusResponseObj" /> class.
        /// </summary>
        public CrawlStatusResponseObj()
        {
        }
    }
}