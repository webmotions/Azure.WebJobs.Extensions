using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text.Json;
using WebMotions.Azure.WebJobs.Extensions.Slack.Bindings;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

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
            context.AddConverter<JsonElement, SlackMessage>(ConvertSlackMessage);

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

        internal static SlackMessage ConvertSlackMessage(JsonElement obj)
        {
            var slackMessage = new SlackMessage();
            slackMessage.AsUser = GetValueOrDefault<bool>(obj, "as_user");
            slackMessage.Channel = GetValueOrDefault<string>(obj, "channel");
            slackMessage.IconEmoji = GetValueOrDefault<string>(obj, "icon_emoji");
            slackMessage.IsMarkdown = GetValueOrDefault<bool>(obj, "mrkdwn");
            slackMessage.Username = GetValueOrDefault<string>(obj, "username");
            slackMessage.Text = GetValueOrDefault<string>(obj, "text");

            if (obj.TryGetProperty("unfurlLinks", out JsonElement unfurlLinks))
            {
                slackMessage.UnfurlLinks = unfurlLinks.GetBoolean();
            }

            slackMessage.UnfurlMedia = GetValueOrDefault<bool>(obj, "unfurlMedia");

            if (obj.TryGetProperty("blocks", out JsonElement blocksValue))
            {
                if (blocksValue.ValueKind == JsonValueKind.Array)
                {
                    var blocks = GetBlocks(blocksValue);
                    slackMessage.Blocks.AddRange(blocks);
                }
            }

            return slackMessage;
        }

        private void ValidateBinding(SlackAttribute attr, Type type)
        {
            var webHookUrl = Utility.FirstOrDefault(attr.WebHookUrl, _options.WebHookUrl);
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

            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                if (string.IsNullOrWhiteSpace(channel))
                {
                    throw new InvalidOperationException("No Slack channel was found. It is required when using an API Key");
                }

                if (!channel.StartsWith("#") && !channel.StartsWith("@"))
                {
                    throw new InvalidOperationException("A channel must start with # for channels or @ for users.");
                }
            }

            if (!string.IsNullOrEmpty(attr.IconUrl) && !string.IsNullOrEmpty(attr.IconEmoji))
            {
                throw new InvalidOperationException("Either an Icon emoji or Icon url must be set, but not both.");
            }
        }

        private static TValue GetValueOrDefault<TValue>(JsonElement messageObject, string propertyName)
        {
            if (messageObject.TryGetProperty(propertyName, out JsonElement result))
            {
                return result.Deserialize<TValue>()!;
            }

#pragma warning disable CS8603 // Possible null reference return.
            return default;
#pragma warning restore CS8603 // Possible null reference return.
        }

        private static IEnumerable<SlackBlockBase> GetBlocks(JsonElement blocksValue)
        {
            var blocks = new List<SlackBlockBase>();
            foreach (var block in blocksValue.EnumerateArray())
            {
                if (block.ValueKind != JsonValueKind.Object)
                {
                    continue;
                }

                if (!block.TryGetProperty("type", out JsonElement typeValue))
                {
                    continue;
                }

                var blockType = typeValue.GetString();

                if (string.IsNullOrWhiteSpace(blockType))
                {
                    continue;
                }

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