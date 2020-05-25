using Newtonsoft.Json;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    public class SlackSelectMenuStaticBlockElement : SlackMenuStaticBlockElementBase
    {
        public override string Type { get; } = "static_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public override string ActionId { get; set; }
    }
}