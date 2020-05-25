using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    public abstract class SlackText
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract SlackTextType Type { get; }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        public string Text { get; set; }
    }
}