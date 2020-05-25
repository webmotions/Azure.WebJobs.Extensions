using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// This multi-select menu will populate its options with a list of Slack users visible to the current user in the active workspace.
    /// </summary>
    public class SlackMultiSelectMenuUserListBlockElement : SlackMenuBlockElementBase
    {
        public override string Type { get; } = "multi_users_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public override string ActionId { get; set; }

        /// <summary>
        /// Gets or sets a collection of user IDs of any valid users to be pre-selected when the menu loads.
        /// </summary>
        [JsonProperty("initial_users")]
        public List<string> InitialUsers { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items that can be selected in the menu.
        /// </summary>
        /// <remarks>
        /// Minimum is 1
        /// </remarks>
        [JsonProperty("max_selected_items")]
        public int? MaximumSelectedItems { get; set; }
    }
}