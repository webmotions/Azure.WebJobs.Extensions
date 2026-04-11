using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models
{
    [JsonConverter(typeof(Converters.JsonStringEnumConverter<SlackFilterType>))]
    public enum SlackFilterType
    {
        [EnumMember(Value = "im")]
        Im,
        [EnumMember(Value = "mpim")]
        Mpim,
        [EnumMember(Value = "private")]
        Private,
        [EnumMember(Value = "public")]
        Public
    }
}