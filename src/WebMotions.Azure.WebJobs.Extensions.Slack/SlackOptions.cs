namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public class SlackOptions
    {
        public static string AzureWebJobsSlackApiKey = "AzureWebJobsSlackApiKey";
        public static string AzureWebJobsSlackWebHookUrl = "AzureWebJobsSlackWebHookUrl";

        public string ApiKey { get; set; }
        public string WebHookUrl { get; set; }
    }
}