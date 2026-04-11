using System.Text.Json.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// This select menu will populate its options with a list of public and private channels, DMs, and MPIMs visible to the current user in the active workspace.
    /// </summary>
    public class SlackSelectMenuConversationBlockElement : SlackMenuConversationBlockElementBase
    {
        public override string Type => "conversations_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonPropertyName("action_id")]
        public override string? ActionId { get; set; }

        /// <summary>
        /// Gets or sets the ID of any valid conversation to be pre-selected when the menu loads. 
        /// </summary>
        [JsonPropertyName("initial_conversation")]
        public string? InitialConversation { get; set; }

        /// <summary>
        /// Gets or sets if the view_submission payload from the menu's parent view will contain a response_url. This response_url can be used for message responses.
        /// The target conversation for the message will be determined by the value of this select menu.
        /// </summary>
        /// <remarks>
        /// This field only works with menus in input blocks in modals.
        /// </remarks>
        [JsonPropertyName("response_url_enabled")]
        public bool ResponseUrlEnabled { get; set; }
    }
}