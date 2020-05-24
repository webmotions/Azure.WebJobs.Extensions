namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public class SlackMessage
    {
        public string Text { get; set; }
        public string Channel { get; set; }
        public string Username { get; set; }
        public string IconEmoji { get; set; }
        public string IsMarkdown { get; set; }
        public string AsUser { get; set; }
    }
}