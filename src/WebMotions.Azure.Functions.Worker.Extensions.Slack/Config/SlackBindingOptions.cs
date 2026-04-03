namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Config;

public class SlackBindingOptions
{
    public static string SectionName = "Slack";

    /// <summary>
    /// Gets or sets the ApiKey
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the Webhook URL
    /// </summary>
    public string? WebHookUrl { get; set; }
}