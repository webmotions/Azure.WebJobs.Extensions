using Newtonsoft.Json;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    public class SlackActionBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "actions";

        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// A collection of interactive element objects - buttons, select menus, overflow menus, or date pickers. 
        /// </summary>
        /// <remarks>
        /// Maximum of 5 elements.
        /// </remarks>
        [JsonConverter(typeof(SlackBlockElementConverter))]
        public List<object> Elements { get; set; } = new List<object>();
    }
}