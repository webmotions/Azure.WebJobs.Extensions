using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Config;

public class SlackBindingOptionsSetup : IConfigureNamedOptions<SlackBindingOptions>
{
    private readonly IConfiguration _configuration;

    public SlackBindingOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(SlackBindingOptions options)
    {
        Configure(Options.DefaultName, options);
    }

    public void Configure(string? name, SlackBindingOptions options)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            name = SlackBindingOptions.SectionName;
        }

        var configurationSection = _configuration.GetSection(name);

        // if the user has not configured it in the app settings, skip.
        if (!configurationSection.Exists())
        {
            return;
        }

        options.ApiKey = configurationSection.GetValue<string>("ApiKey");
        options.WebHookUrl = configurationSection.GetValue<string>("WebHookUrl");
    }
}