using Newtonsoft.Json;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    public class SlackPlainTextInputBlockElement
    {
        /// <summary>
        /// Gets the type of the block element.
        /// </summary>
        public string Type { get; } = "plain_text_input";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        /// <summary>
        /// Gets or sets the placeholder text. 
        /// </summary>
        /// <remarks>
        /// Maximum length is 150 characters.
        /// </remarks>
        public SlackPlainText Placeholder { get; set; }

        /// <summary>
        /// Gets or sets the initial value in the plain-text input when it is loaded. 
        /// </summary>
        [JsonProperty("initial_value")]
        public string InitialValue { get; set; }

        /// <summary>
        /// Gets or sets whether the input will be a single line (false) or a larger textarea (true).
        /// </summary>
        public bool Multiline { get; set; }

        /// <summary>
        /// Gets or sets the minimum length of input that the user must provide. If the user provides less, they will receive an error.
        /// </summary>
        /// <remarks>
        /// Maximum value is 3000.
        /// </remarks>
        [JsonProperty("min_length")]
        public int? MinimumLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of input that the user can provide. If the user provides more, they will receive an error.
        /// </summary>
        [JsonProperty("max_length")]
        public int? MaximumLength { get; set; }
    }
}