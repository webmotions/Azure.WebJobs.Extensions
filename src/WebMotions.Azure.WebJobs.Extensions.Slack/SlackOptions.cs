namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public class SlackOptions
    {
        public static string AzureWebJobsSlackApiKey = "AzureWebJobsSlackApiKey";
        public static string AzureWebJobsSlackWebHookUrl = "AzureWebJobsSlackWebHookUrl";

        /// <summary>
        /// Gets or sets the ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the Webhook URL
        /// </summary>
        public string WebHookUrl { get; set; }
    }
}