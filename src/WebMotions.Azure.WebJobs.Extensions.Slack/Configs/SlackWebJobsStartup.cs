using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using WebMotions.Azure.WebJobs.Extensions.Slack.Configs;

[assembly: WebJobsStartup(typeof(SlackWebJobsStartup))]

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Configs
{
    public class SlackWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSlack();
        }
    }
}