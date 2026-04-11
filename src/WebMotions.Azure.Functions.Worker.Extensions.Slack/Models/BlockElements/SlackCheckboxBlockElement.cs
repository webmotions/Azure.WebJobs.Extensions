using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// A checkbox group that allows a user to choose multiple items from a list of possible options.
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$kind")]
    [JsonDerivedType(typeof(SlackCheckboxBlockElement), "slackCheckboxBlockElement")]
    public class SlackCheckboxBlockElement
    {
        /// <summary>
        /// Gets the type of the block element.
        /// </summary>
        public string Type => "checkboxes";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonPropertyName("action_id")]
        public string? ActionId { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="SlackOption"/>
        /// </summary>
        public List<SlackOption> Options { get; } = new List<SlackOption>();

        /// <summary>
        /// Gets a collection of options that will be selected when the checkbox group initially loads.
        /// </summary>
        /// <remarks>
        /// Have to be <see cref="SlackOption"/> that are included in the <see cref="Options"/> collection
        /// </remarks>
        [JsonPropertyName("initial_options")]
        public List<SlackOption>? SelectedOptions { get; set; } = new List<SlackOption>();

        /// <summary>
        /// Gets or sets a <see cref="SlackConfirmation"/> that defines an optional confirmation dialog after the button is clicked.
        /// </summary>
        public SlackConfirmation? Confirm { get; set; }
    }
}