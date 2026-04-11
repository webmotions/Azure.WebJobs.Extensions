using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    public class SlackMultiSelectMenuChannelBlockElement : SlackMenuBlockElementBase
    {
        /// <summary>
        /// This multi-select menu will populate its options with a list of public channels visible to the current user in the active workspace.
        /// </summary>
        public override string Type => "multi_channels_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonPropertyName("action_id")]
        public override string? ActionId { get; set; }

        /// <summary>
        /// Gets or sets a collection of one or more IDs of any valid public channel to be pre-selected when the menu loads.
        /// </summary>
        [JsonPropertyName("initial_channels")]
        public List<string>? InitialChannels { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items that can be selected in the menu
        /// </summary>
        /// <remarks>
        /// If set, the minimum number is 1
        /// </remarks>
        [JsonPropertyName("max_selected_items")]
        public int? MaximumSelectedItems { get; set; }
    }
}