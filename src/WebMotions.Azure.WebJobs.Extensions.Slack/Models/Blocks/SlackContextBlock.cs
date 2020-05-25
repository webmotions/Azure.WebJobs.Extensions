using Newtonsoft.Json;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// Displays message context, which can include both images and text.
    /// </summary>
    public class SlackContextBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "context";

        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// A collection of image elements and text objects.
        /// </summary>
        /// <remarks>
        /// Maximum of 5 elements.
        /// </remarks>
        [Newtonsoft.Json.JsonConverter(typeof(SlackBlockElementConverter))]
        public List<object> Elements { get; set; } = new List<object>();
    }
}