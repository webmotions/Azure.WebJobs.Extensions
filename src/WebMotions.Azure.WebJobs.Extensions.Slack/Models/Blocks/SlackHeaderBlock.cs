using Newtonsoft.Json;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// A plain-text block that displays in a larger, bold font. Use it to delineate between different groups of content in your app's surfaces.
    /// </summary>
    public class SlackHeaderBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "header";

        /// <summary>
        /// Gets or sets the text for the block
        /// </summary>
        /// <remarks>
        /// Maximum length is 150 characters. 
        /// </remarks>
        [Newtonsoft.Json.JsonConverter(typeof(SlackTextConverter))]
        public SlackPlainText Text { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }
    }
}