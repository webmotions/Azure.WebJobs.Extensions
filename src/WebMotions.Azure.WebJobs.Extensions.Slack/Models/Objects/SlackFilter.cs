using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    /// <summary>
    /// Provides a way to filter the list of options in a conversations select menu or conversations multi-select menu.
    /// </summary>
    public class SlackFilter
    {
        /// <summary>
        /// Gets or sets the type of conversations should be included in the list. When this field is provided, any conversations that do not match will be excluded
        /// </summary>
        public List<SlackFilterType> Include { get; } = new List<SlackFilterType>();

        /// <summary>
        /// Gets or sets whether to exclude external shared channels from conversation lists.
        /// </summary>
        [JsonProperty("exclude_external_shared_channels")]
        public bool ExcludeExternalSharedChannels { get; set; }

        /// <summary>
        /// Gets or sets whether to exclude bot users from conversation lists
        /// </summary>
        [JsonProperty("exclude_bot_users")]
        public bool ExcludeBotUsers { get; set; }
    }
}