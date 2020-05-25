using Newtonsoft.Json;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// A content divider, like an hr HMTL tag, to split up different blocks inside of a message.
    /// </summary>
    public class SlackDividerBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "divider";

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