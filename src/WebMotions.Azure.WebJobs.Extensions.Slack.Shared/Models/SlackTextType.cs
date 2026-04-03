using System.Runtime.Serialization;
using WebMotions.Azure.WebJobs.Extensions.Slack.Shared.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Shared.Models
{
    public enum SlackTextType
    {
        [EnumMember(Value = "plain_text")]
        [EnumMetadataType(typeof(SlackPlainText))]
        Plain,
        [EnumMember(Value = "mrkdwn")]
        [EnumMetadataType(typeof(SlackMarkdownText))]
        Markdown
    }
}