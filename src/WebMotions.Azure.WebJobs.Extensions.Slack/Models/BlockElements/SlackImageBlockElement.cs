using Newtonsoft.Json;
using System;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    public class SlackImageBlockElement
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "image";

        /// <summary>
        /// Gets or sets he URL of the image to be displayed.
        /// </summary>
        [JsonProperty("image_url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the plain-text summary of the image. This should not contain any markup.
        /// </summary>
        [JsonProperty("alt_text")]
        public string AlternateText { get; set; }
    }
}