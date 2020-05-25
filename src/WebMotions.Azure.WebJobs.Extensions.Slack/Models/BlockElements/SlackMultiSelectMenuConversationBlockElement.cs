using Newtonsoft.Json;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// This multi-select menu will populate its options with a list of public and private channels, DMs, and MPIMs visible to the current user in the active workspace.
    /// </summary>
    public class SlackMultiSelectMenuConversationBlockElement : SlackMenuConversationBlockElementBase
    {
        public override string Type { get; } = "multi_conversations_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public override string ActionId { get; set; }

        /// <summary>
        /// Gets or sets a collection of one or more IDs of any valid conversations to be pre-selected when the menu loads.
        /// </summary>
        [JsonProperty("initial_conversations")]
        public List<string> InitialConversations { get; } = new List<string>();

        /// <summary>
        /// Gets or sets a <see cref="SlackFilter"/> that reduces the list of available conversations using the specified criteria.
        /// </summary>
        public SlackFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items that can be selected in the menu
        /// </summary>
        /// <remarks>
        /// If set, the minimum number is 1
        /// </remarks>
        [JsonProperty("max_selected_items")]
        public int? MaximumSelectedItems { get; set; }
    }
}