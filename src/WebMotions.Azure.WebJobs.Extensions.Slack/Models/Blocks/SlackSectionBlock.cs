using Newtonsoft.Json;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// One of the most flexible blocks available - it can be used as a simple text block, in combination with text fields, or side-by-side with any of the available block elements.
    /// </summary>
    public class SlackSectionBlock
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type { get; } = "section";

        /// <summary>
        /// Gets or sets the unique identifier for the block.
        /// </summary>
        /// <remarks>
        /// Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// Gets or sets the text for the block
        /// </summary>
        /// <remarks>
        /// Maximum length is 3000 characters. 
        /// </remarks>
        [Newtonsoft.Json.JsonConverter(typeof(SlackTextConverter))]
        public SlackText Text { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="SlackPlainText"/> or <see cref="SlackMarkdownText"/> objects text objects included that will be rendered in a compact format that allows for 2 columns of side-by-side text. 
        /// </summary>
        /// <remarks>
        /// Maximum number of items is 10. Maximum length for the text in each item is 2000 characters.
        /// </remarks>
        [Newtonsoft.Json.JsonConverter(typeof(SlackTextConverter))]
        public List<SlackText> Fields { get; set; } = new List<SlackText>();

        /// <summary>
        /// Gets or sets a block element to be display within the block
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(SlackBlockElementConverter))]
        public object Accessory { get; set; }
    }
}