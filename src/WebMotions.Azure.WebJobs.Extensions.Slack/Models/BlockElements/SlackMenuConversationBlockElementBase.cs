using System.Text.Json.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$kind")]
    [JsonDerivedType(typeof(SlackMultiSelectMenuConversationBlockElement), "slackMultiSelectMenuConversationBlockElement")]
    [JsonDerivedType(typeof(SlackSelectMenuConversationBlockElement), "slackSelectMenuConversationBlockElement")]
    public abstract class SlackMenuConversationBlockElementBase : SlackMenuBlockElementBase
    {
        /// <summary>
        /// Gets or sets whether to pre-populate the select menu with the conversation that the user was viewing when they opened the modal, if available
        /// </summary>
        /// <remarks>
        /// If a initial conversation is supplied, it will be ignored
        /// </remarks>
        [JsonPropertyName("default_to_current_conversation")]
        public bool DefaultToCurrentConversation { get; set; }
    }
}