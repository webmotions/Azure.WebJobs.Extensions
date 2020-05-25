using Newtonsoft.Json;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// This select menu will populate its options with a list of Slack users visible to the current user in the active workspace.
    /// </summary>
    public class SlackSelectMenuUserListBlockElement : SlackMenuBlockElementBase
    {
        public override string Type { get; } = "users_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public override string ActionId { get; set; }

        /// <summary>
        /// Gets or sets the user ID of any valid user to be pre-selected when the menu loads.
        /// </summary>
        [JsonProperty("initial_user")]
        public string InitialUser { get; set; }
    }
}