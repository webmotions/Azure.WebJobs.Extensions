using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Converters;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// An element which lets users easily select a date from a calendar style UI.
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$kind")]
    [JsonDerivedType(typeof(SlackDatePickerBlockElement), "slackDatePickerBlockElement")]
    public class SlackDatePickerBlockElement
    {
        /// <summary>
        /// Gets the type of the block element.
        /// </summary>
        public string Type => "datepicker";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonPropertyName("action_id")]
        public string? ActionId { get; set; }

        /// <summary>
        /// Gets or sets the placeholder text. 
        /// </summary>
        /// <remarks>
        /// Maximum length is 150 characters.
        /// </remarks>
        public SlackPlainText? Placeholder { get; set; }

        /// <summary>
        /// Gets or sets the placeholder text shown on the datepicker. 
        /// </summary>
        [JsonPropertyName("initial_date")]
        [JsonConverter(typeof(JsonDateTimeIsoOverrideConverter))]
        public DateTime InitialDate { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="SlackConfirmation"/> that defines an optional confirmation dialog after the button is clicked.
        /// </summary>
        public SlackConfirmation? Confirm { get; set; }
    }
}