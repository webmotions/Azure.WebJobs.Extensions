using System.Text.Json.Serialization;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// Displays a remote file.
    /// </summary>
    public class SlackFileBlock : SlackBlockBase
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type => "file";

        /// <summary>
        /// Gets or sets the external unique ID.
        /// </summary>
        [JsonPropertyName("external_id")]
        public string? ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the source of the file
        /// </summary>
        /// <remarks>
        ///	At the moment, source will always be remote for a remote file.
        /// </remarks>
        public string Source => "remote";
    }
}