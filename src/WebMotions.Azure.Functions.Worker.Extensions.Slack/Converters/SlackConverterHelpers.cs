using System.Text.Json;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Blocks;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Converters
{
    public static class SlackConverterHelpers
    {
        internal static readonly IDictionary<string, Type> TextMapping = Utility.GetEnumMemberValueAndMetadata(typeof(SlackTextType));

        public static object? GetBlockElement(string? elementTypeValue, JsonElement item)
        {
            if (string.IsNullOrWhiteSpace(elementTypeValue))
            {
                return null;
            }

            if (TextMapping.TryGetValue(elementTypeValue, out var textClassType))
            {
                return (SlackText)item.Deserialize(textClassType)!;
            }

            return elementTypeValue switch
            {
                "button" => item.Deserialize<SlackButtonBlockElement>(),
                "checkboxes" => item.Deserialize<SlackCheckboxBlockElement>(),
                "datepicker" => item.Deserialize<SlackDatePickerBlockElement>(),
                "image" => item.Deserialize<SlackImageBlockElement>(),
                "multi_channels_select" => item.Deserialize<SlackMultiSelectMenuChannelBlockElement>(),
                "multi_conversations_select" => item.Deserialize<SlackMultiSelectMenuConversationBlockElement>(),
                "multi_external_select" => item.Deserialize<SlackMultiSelectMenuExternalSourceBlockElement>(),
                "multi_static_select" => item.Deserialize<SlackMultiSelectMenuStaticBlockElement>(),
                "multi_users_select" => item.Deserialize<SlackMultiSelectMenuUserListBlockElement>(),
                "overflow" => item.Deserialize<SlackOverflowMenuBlockElement>(),
                "plain_text_input" => item.Deserialize<SlackPlainTextInputBlockElement>(),
                "radio_buttons" => item.Deserialize<SlackRadioButtonGroupBlockElement>(),
                "channels_select" => item.Deserialize<SlackSelectMenuChannelBlockElement>(),
                "conversations_select" => item.Deserialize<SlackSelectMenuConversationBlockElement>(),
                "external_select" => item.Deserialize<SlackSelectMenuExternalSourceBlockElement>(),
                "static_select" => item.Deserialize<SlackSelectMenuStaticBlockElement>(),
                "users_select" => item.Deserialize<SlackSelectMenuUserListBlockElement>(),
                _ => null
            };
        }

        public static SlackBlockBase? GetBlock(string blockTypeValue, JsonElement item)
        {
            return blockTypeValue switch
            {
                "actions" => item.Deserialize<SlackActionBlock>(),
                "context" => item.Deserialize<SlackContextBlock>(),
                "divider" => item.Deserialize<SlackDividerBlock>(),
                "file" => item.Deserialize<SlackFileBlock>(),
                "image" => item.Deserialize<SlackImageBlock>(),
                "input" => item.Deserialize<SlackInputBlock>(),
                "section" => item.Deserialize<SlackSectionBlock>(),
                "header" => item.Deserialize<SlackHeaderBlock>(),
                _ => null
            };
        }
    }
}