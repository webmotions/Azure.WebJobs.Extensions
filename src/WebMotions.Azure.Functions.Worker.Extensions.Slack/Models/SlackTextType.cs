using System.Runtime.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models
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