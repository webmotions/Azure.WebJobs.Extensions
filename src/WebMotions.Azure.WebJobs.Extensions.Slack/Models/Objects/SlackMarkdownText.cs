namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    /// <summary>
    /// An object containing some text, formatted using Slack's proprietary markdown, that's just different enough from Markdown to frustrate you.
    /// </summary>
    public class SlackMarkdownText : SlackText
    {
        public SlackMarkdownText()
        {
        }

        /// <summary>
        /// Creates a text object, using Slack's proprietary markdown
        /// </summary>
        /// <param name="text">The text</param>
        public SlackMarkdownText(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Gets or sets the formatting to use
        /// </summary>
        public override SlackTextType Type => SlackTextType.Markdown;

        /// <summary>
        /// Gets or sets whether URLs will be auto-converted into links, conversation names will be link-ified, and certain mentions will be automatically parsed.
        /// When true will skip any preprocessing of this nature. Defaults to false
        /// </summary>
        /// <remarks>
        /// This field is only usable when <see cref="Type"/> is <see cref="SlackTextType.Markdown"/>
        /// </remarks>
        public bool Verbatim { get; set; }

        public static implicit operator SlackMarkdownText(string s) => new SlackMarkdownText() { Text = s };
    }
}