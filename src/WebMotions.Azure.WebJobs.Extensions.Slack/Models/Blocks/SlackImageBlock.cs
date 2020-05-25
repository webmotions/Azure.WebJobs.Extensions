using Newtonsoft.Json;
using System;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    public class SlackImageBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "image";

        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image to be displayed.
        /// </summary>
        /// <remarks>
        /// Maximum length is 3000 characters.
        /// </remarks>
        [JsonProperty("image_url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the plain-text summary of the image. This should not contain any markup
        /// </summary>
        /// <remarks>
        /// Maximum length is 2000 characters.
        /// </remarks>
        [JsonProperty("alt_text")]
        public string AlternateText { get; set; }

        /// <summary>
        /// Gets or sets an optional title for the image
        /// </summary>
        /// <remarks>
        /// Maximum length is 2000 characters.
        /// </remarks>
        public SlackPlainText Title { get; set; }
    }
}