using System.Threading.Tasks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    public interface ISlackHttpClient
    {
        Task PostMessageAsync(SlackContext context, SlackMessage message);
    }
}