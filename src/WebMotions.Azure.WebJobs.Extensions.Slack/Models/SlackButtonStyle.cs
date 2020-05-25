using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SlackButtonStyle
    {
        /// <summary>
        /// Gives buttons a green outline and text, ideal for affirmation or confirmation actions
        /// </summary>
        [EnumMember(Value = "primary")]
        Primary,
        /// <summary>
        /// Gives buttons a red outline and text, and should be used when the action is destructive
        /// </summary>
        [EnumMember(Value = "danger")]
        Danger
    }
}