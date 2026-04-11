using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// Displays message context, which can include both images and text.
    /// </summary>
    public class SlackContextBlock : SlackBlockBase
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type => "context";

        /// <summary>
        /// A collection of image elements and text objects.
        /// </summary>
        /// <remarks>
        /// Maximum of 5 elements.
        /// </remarks>
        [JsonConverter(typeof(SlackBlockElementConverter))]
        public List<object> Elements { get; set; } = new List<object>();
    }
}