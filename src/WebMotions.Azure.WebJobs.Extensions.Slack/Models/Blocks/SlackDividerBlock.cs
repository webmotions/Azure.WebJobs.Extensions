namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks
{
    /// <summary>
    /// A content divider, like a hr HTML tag, to split up different blocks inside a message.
    /// </summary>
    public class SlackDividerBlock : SlackBlockBase
    {
        /// <summary>
        /// Gets the type of the block.
        /// </summary>
        public string Type => "divider";
    }
}