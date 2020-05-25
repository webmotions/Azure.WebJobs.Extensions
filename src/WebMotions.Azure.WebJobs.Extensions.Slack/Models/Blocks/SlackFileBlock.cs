using Newtonsoft.Json;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// Displays a remote file.
    /// </summary>
    public class SlackFileBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "file";

        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// Gets or sets the external unique ID.
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the source of the file
        /// </summary>
        /// <remarks>
        ///	At the moment, source will always be remote for a remote file.
        /// </remarks>
        public string Source { get; } = "remote";
    }
}