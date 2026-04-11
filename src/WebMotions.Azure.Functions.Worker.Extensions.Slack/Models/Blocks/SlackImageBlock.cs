using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Blocks
{
    public class SlackImageBlock : SlackBlockBase
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type => "image";

        /// <summary>
        /// Gets or sets the URL of the image to be displayed.
        /// </summary>
        /// <remarks>
        /// Maximum length is 3000 characters.
        /// </remarks>
        [JsonPropertyName("image_url")]
        public Uri? Url { get; set; }

        /// <summary>
        /// Gets or sets the plain-text summary of the image. This should not contain any markup
        /// </summary>
        /// <remarks>
        /// Maximum length is 2000 characters.
        /// </remarks>
        [JsonPropertyName("alt_text")]
        public string? AlternateText { get; set; }

        /// <summary>
        /// Gets or sets an optional title for the image
        /// </summary>
        /// <remarks>
        /// Maximum length is 2000 characters.
        /// </remarks>
        public SlackPlainText? Title { get; set; }
    }
}