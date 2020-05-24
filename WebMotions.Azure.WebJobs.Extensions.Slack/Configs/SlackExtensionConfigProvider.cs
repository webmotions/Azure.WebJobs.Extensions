using System;
using System.Linq;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Configs
{
    [Extension("Slack")]
    public class SlackExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly SlackOptions _options;

        public SlackExtensionConfigProvider(IOptions<SlackOptions> options)
        {
            _options = options.Value;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddConverter<JObject, SlackMessage>(ConvertSlackMessage);

            var rule = context.AddBindingRule<SlackAttribute>();

            rule.AddValidator(ValidateBinding);
        }


        /// <summary>
        /// Converts a JSON slack message to 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static SlackMessage ConvertSlackMessage(JObject obj)
        {
            var slackMessage = new SlackMessage();
            return slackMessage;
        }

        private void ValidateBinding(SlackAttribute attr, Type type)
        {
            var webHookUrl = new[] { attr.WebHookUrl, _options.WebHookUrl }.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));

            if (string.IsNullOrWhiteSpace(webHookUrl))
            {
                throw new InvalidOperationException($"The slack option {nameof(attr.WebHookUrl)} is missing");
            }
        }
    }
}