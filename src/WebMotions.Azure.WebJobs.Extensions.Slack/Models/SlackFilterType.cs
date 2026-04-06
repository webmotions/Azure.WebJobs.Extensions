using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models
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