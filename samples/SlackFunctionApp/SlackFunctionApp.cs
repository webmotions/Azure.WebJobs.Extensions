using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebMotions.Azure.WebJobs.Extensions.Slack;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;

namespace SlackFunctionApp
{
    public class SlackFunctionApp
    {
        [FunctionName("SlackFunctionAppSample")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            [Slack(WebHookUrl = "https://hooks.slack.com/services/XXXXXXXX/XXXXXXXXXX/XXXXXXXXX",
                  Channel = "#devtest",
                  Username = "AzureFunctionBot")] IAsyncCollector<SlackMessage> messages,
            ILogger logger)
        {
            logger.LogInformation("Running slack app");

            var samples = new SlackMessageSample();

            var slackMessageSample1 = samples.GetSample1();
            await messages.AddAsync(slackMessageSample1);

            var slackMessageSample2 = samples.GetSample2();
            await messages.AddAsync(slackMessageSample2);
        }
    }
}