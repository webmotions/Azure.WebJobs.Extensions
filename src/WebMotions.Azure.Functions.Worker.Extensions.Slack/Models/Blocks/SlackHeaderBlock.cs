using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Converters;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// A plain-text block that displays in a larger, bold font. Use it to delineate between different groups of content in your app's surfaces.
    /// </summary>
    public class SlackHeaderBlock : SlackBlockBase
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type => "header";

        /// <summary>
        /// Gets or sets the text for the block
        /// </summary>
        /// <remarks>
        /// Maximum length is 150 characters. 
        /// </remarks>
        [JsonConverter(typeof(SlackTextConverter))]
        public SlackPlainText? Text { get; set; }
    }
}