using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Core;
using WebMotions.Azure.Functions.Worker.Extensions.Slack;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Extensions;

[assembly: WorkerExtensionStartup(typeof(SlackExtensionStartup))]

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack;

public class SlackExtensionStartup: WorkerExtensionStartup
{
    public override void Configure(IFunctionsWorkerApplicationBuilder applicationBuilder)
    {
        if (applicationBuilder == null)
        {
            throw new ArgumentNullException(nameof(applicationBuilder));
        }

        applicationBuilder.ConfigureSlackExtension();
    }
}