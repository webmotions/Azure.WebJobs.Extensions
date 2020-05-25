using Newtonsoft.Json;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// A block that collects information from users
    /// </summary>
    public class SlackInputBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "input";

        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// Gets or sets a label that appears above an input element
        /// </summary>
        /// <remarks>
        /// Maximum length is 2000 characters.
        /// </remarks>
        public SlackPlainText Label { get; set; }

        /// <summary>
        /// Gets or sets the type of element as input. Can be <see cref="SlackPlainText"/>, a select menu, a multi-select menu, or a <see cref="SlackDatePickerBlockElement"/>.
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(SlackBlockElementConverter))]
        public object Element { get; set; }

        /// <summary>
        /// Gets or sets an optional hint that appears below an input element in a lighter grey.
        /// </summary>
        /// <remarks>
        /// Maximum length is 2000 characters.
        /// </remarks>
        public SlackPlainText Hint { get; set; }

        /// <summary>
        /// Gets or sets whether the input element may be empty when a user submits the modal.
        /// </summary>
        public bool Optional { get; set; }
    }
}