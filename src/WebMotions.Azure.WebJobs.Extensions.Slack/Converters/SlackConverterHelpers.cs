using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    internal static class SlackConverterHelpers
    {
        internal static readonly IDictionary<string, Type> TextMapping = Utility.GetEnumMemberValueAndMetadata(typeof(SlackTextType));

        internal static object GetBlockElement(string elementTypeValue, JObject item)
        {
            if (TextMapping.TryGetValue(elementTypeValue, out var textClassType))
            {
                return (SlackText)item.ToObject(textClassType);
            }

            return elementTypeValue switch
            {
                "button" => item.ToObject<SlackButtonBlockElement>(),
                "checkboxes" => item.ToObject<SlackCheckboxBlockElement>(),
                "datepicker" => item.ToObject<SlackDatePickerBlockElement>(),
                "image" => item.ToObject<SlackImageBlockElement>(),
                "multi_channels_select" => item.ToObject<SlackMultiSelectMenuChannelBlockElement>(),
                "multi_conversations_select" => item.ToObject<SlackMultiSelectMenuConversationBlockElement>(),
                "multi_external_select" => item.ToObject<SlackMultiSelectMenuExternalSourceBlockElement>(),
                "multi_static_select" => item.ToObject<SlackMultiSelectMenuStaticBlockElement>(),
                "multi_users_select" => item.ToObject<SlackMultiSelectMenuUserListBlockElement>(),
                "overflow" => item.ToObject<SlackOverflowMenuBlockElement>(),
                "plain_text_input" => item.ToObject<SlackPlainTextInputBlockElement>(),
                "radio_buttons" => item.ToObject<SlackRadioButtonGroupBlockElement>(),
                "channels_select" => item.ToObject<SlackSelectMenuChannelBlockElement>(),
                "conversations_select" => item.ToObject<SlackSelectMenuConversationBlockElement>(),
                "external_select" => item.ToObject<SlackSelectMenuExternalSourceBlockElement>(),
                "static_select" => item.ToObject<SlackSelectMenuStaticBlockElement>(),
                "users_select" => item.ToObject<SlackSelectMenuUserListBlockElement>(),
                _ => null
            };
        }

        internal static object GetBlock(string blockTypeValue, JObject item)
        {
            return blockTypeValue switch
            {
                "actions" => item.ToObject<SlackActionBlock>(),
                "context" => item.ToObject<SlackContextBlock>(),
                "divider" => item.ToObject<SlackDividerBlock>(),
                "file" => item.ToObject<SlackFileBlock>(),
                "image" => item.ToObject<SlackImageBlock>(),
                "input" => item.ToObject<SlackInputBlock>(),
                "section" => item.ToObject<SlackSectionBlock>(),
                "header" => item.ToObject<SlackHeaderBlock>(),
                _ => null
            };
        }
    }
}