namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    /// <summary>
    /// An object containing some text, formatted in plain text
    /// </summary>
    public class SlackPlainText : SlackText
    {
        /// <summary>
        /// Create a text object, in plain form
        /// </summary>
        public SlackPlainText()
        {
        }

        /// <summary>
        /// Create a text object, in plain form
        /// </summary>
        /// <param name="text">The text</param>
        public SlackPlainText(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Create a text object, in plain form
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="emoji">Sets whether emojis in a text field should be escaped into the colon emoji format</param>
        public SlackPlainText(string text, bool emoji)
        {
            Text = text;
            Emoji = emoji;
        }

        /// <summary>
        /// Gets or sets the formatting to use
        /// </summary>
        public override SlackTextType Type => SlackTextType.Plain;

        /// <summary>
        /// Gets or sets whether emojis in a text field should be escaped into the colon emoji format
        /// </summary>
        public bool Emoji { get; set; }

        public static implicit operator SlackPlainText(string s) => new SlackPlainText() { Text = s };
    }
}