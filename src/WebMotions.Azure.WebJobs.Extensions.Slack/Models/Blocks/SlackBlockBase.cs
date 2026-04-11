using System.Text.Json.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$kind")]
    [JsonDerivedType(typeof(SlackActionBlock), "slackActionBlock")]
    [JsonDerivedType(typeof(SlackContextBlock), "slackContextBlock")]
    [JsonDerivedType(typeof(SlackDividerBlock), "slackDividerBlock")]
    [JsonDerivedType(typeof(SlackFileBlock), "slackFileBlock")]
    [JsonDerivedType(typeof(SlackHeaderBlock), "slackHeaderBlock")]
    [JsonDerivedType(typeof(SlackImageBlock), "slackImageBlock")]
    [JsonDerivedType(typeof(SlackInputBlock), "slackInputBlock")]
    [JsonDerivedType(typeof(SlackSectionBlock), "slackSectionBlock")]
    public abstract class SlackBlockBase
    {
        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonPropertyName("block_id")]
        public string? BlockId { get; set; }
    }
}