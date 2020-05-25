using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Bindings;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Configs
{
    [Microsoft.Azure.WebJobs.Description.Extension("Slack")]
    public class SlackExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly ISlackHttpClient _slackHttpClient;
        private readonly SlackOptions _options;
        private readonly ILogger _slackLogger;

        public SlackExtensionConfigProvider(IOptions<SlackOptions> options, ISlackHttpClient slackHttpClient, ILoggerFactory loggerFactory)
        {
            _slackHttpClient = slackHttpClient;
            _options = options.Value;
            _slackLogger = loggerFactory.CreateLogger("SlackExtension");
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddConverter<JObject, SlackMessage>(ConvertSlackMessage);

            var rule = context.AddBindingRule<SlackAttribute>();
            rule.AddValidator(ValidateBinding);
            rule.BindToCollector<SlackMessage>(attribute =>
            {
                var apiKey = Utility.FirstOrDefault(attribute.ApiKey, _options.ApiKey);
                var webHookUrl = Utility.FirstOrDefault(attribute.WebHookUrl, _options.WebHookUrl);
                var iconUrl = attribute.IconUrl;
                var iconEmoji = attribute.IconEmoji;
                var userName = attribute.Username;

                var slackContext = new SlackContext
                {
                    ApiKey = apiKey,
                    WebHookUrl = webHookUrl,
                    Channel = attribute.Channel,
                    IconUrl = iconUrl,
                    IconEmoji = iconEmoji,
                    UserName = userName
                };

                return new SlackMessageAsyncCollector(slackContext, _slackHttpClient, _slackLogger);
            });
        }

        internal static SlackMessage ConvertSlackMessage(JObject obj)
        {
            var slackMessage = new SlackMessage();
            slackMessage.AsUser = GetValueOrDefault<bool>(obj, "as_user");
            slackMessage.Channel = GetValueOrDefault<string>(obj, "channel");
            slackMessage.IconEmoji = GetValueOrDefault<string>(obj, "icon_emoji");
            slackMessage.IsMarkdown = GetValueOrDefault<bool>(obj, "mrkdwn");
            slackMessage.Username = GetValueOrDefault<string>(obj, "username");
            slackMessage.Text = GetValueOrDefault<string>(obj, "text");

            if (obj.TryGetValue("unfurlLinks", StringComparison.OrdinalIgnoreCase, out JToken unfurlLinks))
            {
                slackMessage.UnfurlLinks = unfurlLinks.Value<bool>();
            }

            slackMessage.UnfurlMedia = GetValueOrDefault<bool>(obj, "unfurlMedia");

            if (obj.TryGetValue("blocks", StringComparison.OrdinalIgnoreCase, out JToken blocksValue))
            {
                if (blocksValue.Type == JTokenType.Array)
                {
                    var blocks = GetBlocks((JArray)blocksValue);
                    slackMessage.Blocks.AddRange(blocks);
                }
            }

            return slackMessage;
        }

        private void ValidateBinding(SlackAttribute attr, Type type)
        {
            var webHookUrl = Utility.FirstOrDefault(attr.WebHookUrl, _options.ApiKey);
            var apiKey = Utility.FirstOrDefault(attr.ApiKey, _options.ApiKey);
            var channel = attr.Channel;

            if (!string.IsNullOrWhiteSpace(webHookUrl) && !string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("Either the Slack Webhook url or the API key need to set.");
            }

            if (string.IsNullOrWhiteSpace(webHookUrl) && string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("No Slack Webhook url or the API key were found. Either one of them need to be set");
            }

            if (string.IsNullOrWhiteSpace(channel))
            {
                throw new InvalidOperationException("No Slack channel was found.");
            }

            if (!channel.StartsWith("#") && !channel.StartsWith("@"))
            {
                throw new InvalidOperationException("A channel must start with # for channels or @ for users.");
            }

            if (!string.IsNullOrEmpty(attr.IconUrl) && !string.IsNullOrEmpty(attr.IconEmoji))
            {
                throw new InvalidOperationException("Either an Icon emoji or Icon url must be set, but not both.");
            }
        }

        private static TValue GetValueOrDefault<TValue>(JObject messageObject, string propertyName)
        {
            if (messageObject.TryGetValue(propertyName, StringComparison.OrdinalIgnoreCase, out JToken result))
            {
                return result.Value<TValue>();
            }

            return default;
        }

        private static IEnumerable<object> GetBlocks(JArray blocksValue)
        {
            var blocks = new List<object>();
            foreach (var blockObject in blocksValue)
            {
                if (blockObject.Type != JTokenType.Object)
                {
                    continue;
                }

                var block = (JObject)blockObject;
                if (!block.TryGetValue("type", out JToken typeValue))
                {
                    continue;
                }

                var blockType = typeValue.Value<string>();
                var concreteBlock = SlackConverterHelpers.GetBlock(blockType, block);
                if (concreteBlock != null)
                {
                    blocks.Add(concreteBlock);
                }
            }
            return blocks;
        }
    }
}