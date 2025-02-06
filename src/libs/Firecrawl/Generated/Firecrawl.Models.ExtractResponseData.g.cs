
#nullable enable

namespace Firecrawl
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ExtractResponseData
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("<property1>")]
        public string? x_property1_ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("<property2>")]
        public double? x_property2_ { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractResponseData" /> class.
        /// </summary>
        /// <param name="x_property1_"></param>
        /// <param name="x_property2_"></param>
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public ExtractResponseData(
            string? x_property1_,
            double? x_property2_)
        {
            this.x_property1_ = x_property1_;
            this.x_property2_ = x_property2_;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractResponseData" /> class.
        /// </summary>
        public ExtractResponseData()
        {
        }
    }
}