using System.Text.Json.Serialization;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// This select menu will load its options from an external data source, allowing for a dynamic list of options.
    /// </summary>
    public class SlackSelectMenuExternalSourceBlockElement : SlackMenuExternalSourceBlockElementBase
    {
        public override string Type => "external_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonPropertyName("action_id")]
        public override string? ActionId { get; set; }

        /// <summary>
        /// Gets or sets the option that exactly matches one of the options within the <see cref="SlackOption"/> or <see cref="SlackOptionGroup"/> loaded from the external data source.
        /// </summary>
        [JsonPropertyName("initial_option")]
        public SlackOption? InitialOption { get; set; }
    }
}