namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public class SlackContext
    {
        internal string ApiKey { get; set; }
        internal string WebHookUrl { get; set; }
        internal string Channel { get; set; }
        internal string UserName { get; set; }
        internal string IconEmoji { get; set; }
        internal string IconUrl { get; set; }
    }
}