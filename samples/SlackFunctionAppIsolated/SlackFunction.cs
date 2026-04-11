using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebMotions.Azure.Functions.Worker.Extensions.Slack;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models;

namespace SlackFunctionAppIsolated;

public class SlackFunction
{
    private readonly ILogger<SlackFunction> _logger;

    public SlackFunction(ILogger<SlackFunction> logger)
    {
        _logger = logger;
    }

    [Function("SlackFunctionAppSample")]
    [SlackOutput(WebHookUrl = "https://hooks.slack.com/services/XXXXXXXX/XXXXXXXXXX/XXXXXXXXX",
        Channel = "#devtest",
        Username = "AzureFunctionBot")]
    public Task<IEnumerable<SlackMessage>> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("Running slack app");

        var messages = new List<SlackMessage>();
        var samples = new SlackMessageSample();

        var slackMessageSample1 = samples.GetSample1();
        messages.Add(slackMessageSample1);

        var slackMessageSample2 = samples.GetSample2();
        messages.Add(slackMessageSample2);

        var json = JsonSerializer.Serialize(messages);
        _logger.LogInformation("Outgoing payload: {json}", json);

        return Task.FromResult<IEnumerable<SlackMessage>>(messages);
    }
}