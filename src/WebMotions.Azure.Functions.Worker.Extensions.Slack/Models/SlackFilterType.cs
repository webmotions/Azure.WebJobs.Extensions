using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SlackFilterType
    {
        [EnumMember(Value = "im")]
        [JsonStringEnumMemberName("im")]
        Im,
        [EnumMember(Value = "mpim")]
        [JsonStringEnumMemberName("mpim")]
        Mpim,
        [EnumMember(Value = "private")]
        [JsonStringEnumMemberName("private")]
        Private,
        [EnumMember(Value = "public")]
        [JsonStringEnumMemberName("public")]
        Public
    }
}