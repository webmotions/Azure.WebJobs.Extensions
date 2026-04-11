using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SlackTextType
    {
        [EnumMember(Value = "plain_text")]
        [EnumMetadataType(typeof(SlackPlainText))]
        [JsonStringEnumMemberName("plain_text")]
        Plain,
        [EnumMember(Value = "mrkdwn")]
        [EnumMetadataType(typeof(SlackMarkdownText))]
        [JsonStringEnumMemberName("mrkdwn")]
        Markdown
    }
}