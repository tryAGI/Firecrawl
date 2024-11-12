
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScrapeResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Warning message to let you know of any issues.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("warning")]
        public string? Warning { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("data")]
        public global::Firecrawl.ScrapeResponseData? Data { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponse" /> class.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="warning">
        /// Warning message to let you know of any issues.
        /// </param>
        /// <param name="data"></param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ScrapeResponse(
            bool? success,
            string? warning,
            global::Firecrawl.ScrapeResponseData? data)
        {
            this.Success = success;
            this.Warning = warning;
            this.Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeResponse" /> class.
        /// </summary>
        public ScrapeResponse()
        {
        }
    }
}