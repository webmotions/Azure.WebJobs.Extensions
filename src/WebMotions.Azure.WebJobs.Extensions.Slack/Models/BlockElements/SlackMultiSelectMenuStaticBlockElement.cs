using Newtonsoft.Json;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// A multi-select menu allows a user to select multiple items from a list of options.
    /// Just like regular select menus, multi-select menus also include type-ahead functionality, where a user can type a part or all of an option string to filter the list.
    /// </summary>
    public class SlackMultiSelectMenuStaticBlockElement : SlackMenuStaticBlockElementBase
    {
        public override string Type { get; } = "multi_static_select";

        /// <summary>
        /// Gets or sets the identifier for the action. Defaults to msms_{NewGuid}
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public override string ActionId { get; set; }

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