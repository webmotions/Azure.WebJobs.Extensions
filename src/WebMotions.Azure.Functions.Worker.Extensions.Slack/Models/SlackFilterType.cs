using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
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