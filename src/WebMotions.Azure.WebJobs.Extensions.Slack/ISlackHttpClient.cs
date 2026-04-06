using System.Threading.Tasks;
using SlackMessage = WebMotions.Azure.WebJobs.Extensions.Slack.Models.SlackMessage;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public interface ISlackHttpClient
    {
        Task PostMessageAsync(SlackContext context, SlackMessage message);
    }
}