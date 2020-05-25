using Newtonsoft.Json;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// This is like a cross between a button and a select menu - when a user clicks on this overflow button, they will be presented with a list of options to choose from.
    /// Unlike the select menu, there is no typeahead field, and the button always appears with an ellipsis ("…") rather than customizable text.
    /// </summary>
    public class SlackOverflowMenuBlockElement
    {
        /// <summary>
        /// Gets the type of the block element.
        /// </summary>
        public string Type { get; } = "overflow";

        /// <summary>
        /// Gets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="SlackOption"/>
        /// </summary>
        public List<SlackOption> Options { get; } = new List<SlackOption>();

        /// <summary>
        /// Gets or sets a <see cref="SlackConfirmation"/> that defines an optional confirmation dialog after the button is clicked.
        /// </summary>
        public SlackConfirmation Confirm { get; set; }
    }
}