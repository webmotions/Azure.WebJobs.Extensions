using System.Text.Json.Serialization;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    [JsonConverter(typeof(SlackTextConverter))]
    public abstract class SlackText
    {
        public abstract SlackTextType Type { get; }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        public string? Text { get; set; }
    }
}