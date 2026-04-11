using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    public class SlackActionBlock : SlackBlockBase
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type => "actions";

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