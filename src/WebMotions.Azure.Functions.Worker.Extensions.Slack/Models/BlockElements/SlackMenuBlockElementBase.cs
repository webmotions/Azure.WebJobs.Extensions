using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.BlockElements
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$kind")]
    [JsonDerivedType(typeof(SlackMultiSelectMenuExternalSourceBlockElement), "slackMultiSelectMenuExternalSourceBlockElement")]
    [JsonDerivedType(typeof(SlackSelectMenuExternalSourceBlockElement), "slackSelectMenuExternalSourceBlockElement")]
    [JsonDerivedType(typeof(SlackMultiSelectMenuConversationBlockElement), "slackMultiSelectMenuConversationBlockElement")]
    [JsonDerivedType(typeof(SlackSelectMenuConversationBlockElement), "slackSelectMenuConversationBlockElement")]
    [JsonDerivedType(typeof(SlackMultiSelectMenuStaticBlockElement), "slackMultiSelectMenuStaticBlockElement")]
    [JsonDerivedType(typeof(SlackSelectMenuStaticBlockElement), "slackSelectMenuStaticBlockElement")]
    [JsonDerivedType(typeof(SlackMultiSelectMenuUserListBlockElement), "slackMultiSelectMenuUserListBlockElement")]
    [JsonDerivedType(typeof(SlackSelectMenuUserListBlockElement), "slackSelectMenuUserListBlockElement")]
    [JsonDerivedType(typeof(SlackSelectMenuChannelBlockElement), "slackSelectMenuChannelBlockElement")]
    public abstract class SlackMenuBlockElementBase
    {
        /// <summary>
        /// Gets the type of the block element.
        /// </summary>
        public abstract string Type { get; }

        public abstract string? ActionId { get; set; }

        /// <summary>
        /// Gets or sets the placeholder text. 
        /// </summary>
        /// <remarks>
        /// Maximum length is 150 characters.
        /// </remarks>
        public SlackPlainText? Placeholder { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="SlackConfirmation"/> that defines an optional confirmation dialog after the button is clicked.
        /// </summary>
        public SlackConfirmation? Confirm { get; set; }
    }
}