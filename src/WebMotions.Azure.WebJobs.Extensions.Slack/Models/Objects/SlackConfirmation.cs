using Newtonsoft.Json;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    /// <summary>
    /// An object that defines a dialog that provides a confirmation step to any interactive element. This dialog will ask the user to confirm their action by offering a confirm and deny buttons.
    /// </summary>
    public class SlackConfirmation
    {
        /// <summary>
        /// Gets or sets the dialog's title.
        /// </summary>
        /// <remarks>
        /// Maximum length is 100 characters.
        /// </remarks>
        public SlackPlainText Title { get; set; }

        /// <summary>
        /// Gets or sets the explanatory text that appears in the confirm dialog
        /// </summary>
        /// <remarks>
        /// Maximum length is 300 characters. Use <see cref="SlackPlainText"/> or <see cref="SlackMarkdownText"/>
        /// </remarks>
        [Newtonsoft.Json.JsonConverter(typeof(SlackTextConverter))]
        public SlackText Text { get; set; }

        /// <summary>
        /// Gets or sets the text of the button that confirms the action.
        /// </summary>
        /// <remarks>
        /// Maximum length is 30 characters.
        /// </remarks>
        public SlackPlainText Confirm { get; set; }

        /// <summary>
        /// Gets or sets the text of the button that cancels the action
        /// </summary>
        /// <remarks>
        /// Maximum length is 30 characters.
        /// </remarks>
        public SlackPlainText Deny { get; set; }

        /// <summary>
        /// Gets or sets the color scheme applied to the confirm button
        /// </summary>
        [JsonProperty("style")]
        public SlackButtonStyle? ConfirmButtonStyle { get; set; }
    }
}