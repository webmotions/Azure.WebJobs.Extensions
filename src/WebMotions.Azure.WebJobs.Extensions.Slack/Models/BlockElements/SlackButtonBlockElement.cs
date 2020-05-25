using Newtonsoft.Json;
using System;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// An interactive component that inserts a button. The button can be a trigger for anything from opening a simple link to starting a complex workflow.
    /// </summary>
    public class SlackButtonBlockElement
    {
        /// <summary>
        /// Gets the type of the block element.
        /// </summary>
        public string Type { get; } = "button";

        /// <summary>
        /// Gets or sets the text that defines the button's text.
        /// </summary>
        /// <remarks>
        /// Can only be plain text. Maximum length is 75 characters.
        /// </remarks>
        public SlackPlainText Text { get; set; }

        /// <summary>
        /// Gets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        /// <summary>
        /// Gets or sets the URL to load in the user's browser when the button is clicked.
        /// </summary>
        /// <remarks>
        /// Maximum length is 3000 characters.
        /// </remarks>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the value to send along with the interaction payload
        /// </summary>
        /// <remarks>
        /// Maximum length is 2000 characters.
        /// </remarks>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the button alternate visual color scheme. Defaults to the default style
        /// </summary>
        public SlackButtonStyle? Style { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="SlackConfirmation"/> that defines an optional confirmation dialog after the button is clicked.
        /// </summary>
        public SlackConfirmation Confirm { get; set; }
    }
}