
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ExtractResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("data")]
        public global::Firecrawl.ExtractResponseData? Data { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractResponse" /> class.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="data"></param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ExtractResponse(
            bool? success,
            global::Firecrawl.ExtractResponseData? data)
        {
            this.Success = success;
            this.Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractResponse" /> class.
        /// </summary>
        public ExtractResponse()
        {
        }
    }
}