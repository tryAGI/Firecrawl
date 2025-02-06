
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GetCreditUsageResponse2
    {
        /// <summary>
        /// Example: false
        /// </summary>
        /// <example>false</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Example: Could not find credit usage information
        /// </summary>
        /// <example>Could not find credit usage information</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCreditUsageResponse2" /> class.
        /// </summary>
        /// <param name="success">
        /// Example: false
        /// </param>
        /// <param name="error">
        /// Example: Could not find credit usage information
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public GetCreditUsageResponse2(
            bool? success,
            string? error)
        {
            this.Success = success;
            this.Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCreditUsageResponse2" /> class.
        /// </summary>
        public GetCreditUsageResponse2()
        {
        }
    }
}