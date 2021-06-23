using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using FluentAssertions.Execution;
using WebMotions.Azure.WebJobs.Extensions.Slack.Configs;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;
using Xunit;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Tests
{
    public class SlackConfigurationTests
    {
        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_is_in_simple_form_and_unfurlLinks_and_blocks_are_not_present()
        {
            var expectedSlackMessage = new SlackMessage();
            expectedSlackMessage.Channel = "#test";
            expectedSlackMessage.IconEmoji = ":smiley:";
            expectedSlackMessage.IsMarkdown = false;
            expectedSlackMessage.Text = "My Super Text";
            expectedSlackMessage.Username = "MyAppBot";

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false
            }";

            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_is_in_simple_form_and_unfurlLinks_is_present()
        {
            var expectedSlackMessage = new SlackMessage();
            expectedSlackMessage.AsUser = false;
            expectedSlackMessage.Channel = "#test";
            expectedSlackMessage.IconEmoji = ":smiley:";
            expectedSlackMessage.IsMarkdown = false;
            expectedSlackMessage.Text = "My Super Text";
            expectedSlackMessage.Username = "MyAppBot";
            expectedSlackMessage.UnfurlMedia = false;
            expectedSlackMessage.UnfurlLinks = true;

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""unfurl_links"": true
            }";

            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_button_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackButtonBlockElement
            {
                Text = new SlackPlainText()
                {
                    Text = "Click Me",
                    Emoji = true
                },
                ActionId = "btn_action_123",
                Style = SlackButtonStyle.Primary,
                Url = new Uri("https://www.slack.com"),
                Value = "value-0",
                Confirm = new SlackConfirmation
                {
                    Title = "Are you sure?",
                    Text = new SlackMarkdownText
                    {
                        Text = "Wouldn't you prefer a good game of _chess_?"
                    },
                    Confirm = "Do it",
                    Deny = "Stop, I've changed my mind!"
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""btn_action_123"",
                      ""type"": ""button"",
                      ""text"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Click Me"",
                        ""emoji"": true
                      },
                      ""url"": ""https://www.slack.com"",
                      ""value"": ""value-0"",
                      ""style"": ""primary"",
                      ""confirm"": {
                        ""title"": ""Are you sure?"",
                        ""text"": {
                          ""type"": ""mrkdwn"",
                          ""text"": ""Wouldn't you prefer a good game of _chess_?""
                        },
                        ""confirm"": ""Do it"",
                        ""deny"": ""Stop, I've changed my mind!""
                      }
                    }
                  ]
                }
              ]
            }";

            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_checkbox_block_element()
        {
            var block = new SlackActionBlock();
            var option1 = new SlackOption
            {
                Description = "Checkbox 1",
                Value = "A1",
                Text = new SlackMarkdownText
                {
                    Text = "*Checkbox 1*"
                },
                Url = new Uri("https://www.slack.com")
            };
            block.Elements.Add(new SlackCheckboxBlockElement
            {
                ActionId = "this_is_an_action_id",
                Confirm = new SlackConfirmation
                {
                    Title = "Are you sure?",
                    Text = new SlackMarkdownText
                    {
                        Text = "Wouldn't you prefer a good game of _chess_?"
                    },
                    Confirm = "Do it",
                    Deny = "Stop, I've changed my mind!"
                },
                Options =
                {
                    option1,
                    new SlackOption
                    {
                        Description = "Checkbox 2",
                        Value = "A2",
                        Text = new SlackPlainText
                        {
                            Text = "Checkbox 2"
                        },
                        Url = new Uri("https://www.slack.com")
                    }
                },
                SelectedOptions =
                {
                    option1
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""type"": ""checkboxes"",
                      ""action_id"": ""this_is_an_action_id"",
                      ""initial_options"": [
                        {
                          ""value"": ""A1"",
                          ""description"": ""Checkbox 1"",
                          ""url"": ""https://www.slack.com"",
                          ""text"": {
                            ""type"": ""mrkdwn"",
                            ""text"": ""*Checkbox 1*""
                          }
                        }
                      ],
                      ""options"": [
                        {
                          ""value"": ""A1"",
                          ""description"": ""Checkbox 1"",
                          ""url"": ""https://www.slack.com"",
                          ""text"": {
                            ""type"": ""mrkdwn"",
                            ""text"": ""*Checkbox 1*""
                          }
                        },
                        {
                          ""value"": ""A2"",
                          ""description"": ""Checkbox 2"",
                          ""url"": ""https://www.slack.com"",
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""Checkbox 2""
                          }
                        }
                      ],
                      ""confirm"": {
                        ""title"": ""Are you sure?"",
                        ""text"": {
                          ""type"": ""mrkdwn"",
                          ""text"": ""Wouldn't you prefer a good game of _chess_?""
                        },
                        ""confirm"": ""Do it"",
                        ""deny"": ""Stop, I've changed my mind!""
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_multi_select_conversation_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackMultiSelectMenuConversationBlockElement
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select conversations",
                    Emoji = true
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""multi_conversations_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select conversations"",
                        ""emoji"": true
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_multi_select_channel_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackMultiSelectMenuChannelBlockElement
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select channels",
                    Emoji = true
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""multi_channels_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select channels"",
                        ""emoji"": true
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_multi_select_external_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackMultiSelectMenuExternalSourceBlockElement()
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select items",
                    Emoji = true
                },
                MinimumQueryLength = 4,
                InitialOptions =
                {
                    new SlackOption
                    {
                        Text = new SlackPlainText("This is plain text"),
                        Value = "value-0",
                        Url = new Uri("https://www.slack.com"),
                        Description = new SlackPlainText("A description")
                    }
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""multi_external_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select items"",
                        ""emoji"": true
                      },
                      ""min_query_length"": 4,
                      ""initial_options"": [
                        {
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""This is plain text""
                          },
                          ""value"": ""value-0"",
                          ""url"": ""https://www.slack.com"",
                          ""description"": {
                            ""type"": ""plain_text"",
                            ""text"": ""A description""
                          }
                        }
                      ]
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_multi_select_static_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackMultiSelectMenuStaticBlockElement()
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select items",
                    Emoji = true
                },
                Options =
                {
                    new SlackOption
                    {
                        Text = new SlackPlainText("This is plain text"),
                        Value = "value-0",
                        Url = new Uri("https://www.slack.com"),
                        Description = new SlackPlainText("A description")
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText("This is plain text"),
                        Value = "value-1",
                        Url = new Uri("https://www.slack.com"),
                        Description = new SlackPlainText("A description")
                    }
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""multi_static_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select items"",
                        ""emoji"": true
                      },
                      ""options"": [
                        {
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""This is plain text""
                          },
                          ""value"": ""value-0"",
                          ""url"": ""https://www.slack.com"",
                          ""description"": {
                            ""type"": ""plain_text"",
                            ""text"": ""A description""
                          }
                        },
                        {
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""This is plain text""
                          },
                          ""value"": ""value-1"",
                          ""url"": ""https://www.slack.com"",
                          ""description"": {
                            ""type"": ""plain_text"",
                            ""text"": ""A description""
                          }
                        }
                      ]
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_multi_select_user_list_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackMultiSelectMenuUserListBlockElement()
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select items",
                    Emoji = true
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""multi_users_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select items"",
                        ""emoji"": true
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_an_overflow_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackOverflowMenuBlockElement()
            {
                ActionId = "overflow",
                Options =
                {
                    new SlackOption
                    {
                        Text = new SlackPlainText("This is plain text"),
                        Value = "value-0",
                        Url = new Uri("https://www.slack.com"),
                        Description = new SlackPlainText("A description")
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText("This is plain text"),
                        Value = "value-1",
                        Url = new Uri("https://www.slack.com"),
                        Description = new SlackPlainText("A description")
                    }
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""overflow"",
                      ""type"": ""overflow"",
                      ""options"": [
                        {
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""This is plain text""
                          },
                          ""value"": ""value-0"",
                          ""url"": ""https://www.slack.com"",
                          ""description"": {
                            ""type"": ""plain_text"",
                            ""text"": ""A description""
                          }
                        },
                        {
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""This is plain text""
                          },
                          ""value"": ""value-1"",
                          ""url"": ""https://www.slack.com"",
                          ""description"": {
                            ""type"": ""plain_text"",
                            ""text"": ""A description""
                          }
                        }
                      ]
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_plain_text_input_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackPlainTextInputBlockElement()
            {
                ActionId = "plain_input",
                Placeholder = new SlackPlainText
                {
                    Text = "Enter some plain text",
                    Emoji = true
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""plain_input"",
                      ""type"": ""plain_text_input"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Enter some plain text"",
                        ""emoji"": true
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_radio_button_group_block_element()
        {
            var block = new SlackActionBlock();
            var option1 = new SlackOption
            {
                Text = new SlackPlainText("Radio 1"),
                Value = "A1"
            };
            block.Elements.Add(new SlackRadioButtonGroupBlockElement()
            {
                ActionId = "this_is_an_action_id",
                Options =
                {
                    option1,
                    new SlackOption
                    {
                        Text = new SlackPlainText("Radio 2"),
                        Value = "A2"
                    }
                },
                InitialOption = option1
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""type"": ""radio_buttons"",
                      ""action_id"": ""this_is_an_action_id"",
                      ""initial_option"": {
                        ""value"": ""A1"",
                        ""text"": {
                          ""type"": ""plain_text"",
                          ""text"": ""Radio 1""
                        }
                      },
                      ""options"": [
                        {
                          ""value"": ""A1"",
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""Radio 1""
                          }
                        },
                        {
                          ""value"": ""A2"",
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""Radio 2""
                          }
                        }
                      ]
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_select_conversation_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackSelectMenuConversationBlockElement
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select conversations",
                    Emoji = true
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""conversations_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select conversations"",
                        ""emoji"": true
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_select_channel_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackSelectMenuChannelBlockElement
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select channels",
                    Emoji = true
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""channels_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select channels"",
                        ""emoji"": true
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_select_external_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackSelectMenuExternalSourceBlockElement()
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select items",
                    Emoji = true
                },
                MinimumQueryLength = 4,
                InitialOption = new SlackOption
                {
                    Text = new SlackPlainText("This is plain text"),
                    Value = "value-0",
                    Url = new Uri("https://www.slack.com"),
                    Description = new SlackPlainText("A description")
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""external_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select items"",
                        ""emoji"": true
                      },
                      ""min_query_length"": 4,
                      ""initial_option"": {
                        ""text"": {
                          ""type"": ""plain_text"",
                          ""text"": ""This is plain text""
                        },
                        ""value"": ""value-0"",
                        ""url"": ""https://www.slack.com"",
                        ""description"": {
                          ""type"": ""plain_text"",
                          ""text"": ""A description""
                        }
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_select_static_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackSelectMenuStaticBlockElement()
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select items",
                    Emoji = true
                },
                Options =
                {
                    new SlackOption
                    {
                        Text = new SlackPlainText("This is plain text"),
                        Value = "value-0",
                        Url = new Uri("https://www.slack.com"),
                        Description = new SlackPlainText("A description")
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText("This is plain text"),
                        Value = "value-1",
                        Url = new Uri("https://www.slack.com"),
                        Description = new SlackPlainText("A description")
                    }
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""static_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select items"",
                        ""emoji"": true
                      },
                      ""options"": [
                        {
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""This is plain text""
                          },
                          ""value"": ""value-0"",
                          ""url"": ""https://www.slack.com"",
                          ""description"": {
                            ""type"": ""plain_text"",
                            ""text"": ""A description""
                          }
                        },
                        {
                          ""text"": {
                            ""type"": ""plain_text"",
                            ""text"": ""This is plain text""
                          },
                          ""value"": ""value-1"",
                          ""url"": ""https://www.slack.com"",
                          ""description"": {
                            ""type"": ""plain_text"",
                            ""text"": ""A description""
                          }
                        }
                      ]
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_block_of_type_action_and_a_select_user_list_block_element()
        {
            var block = new SlackActionBlock();
            block.Elements.Add(new SlackSelectMenuUserListBlockElement()
            {
                ActionId = "text1234",
                Placeholder = new SlackPlainText
                {
                    Text = "Select items",
                    Emoji = true
                }
            });
            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""actions"",
                  ""elements"": [
                    {
                      ""action_id"": ""text1234"",
                      ""type"": ""users_select"",
                      ""placeholder"": {
                        ""type"": ""plain_text"",
                        ""text"": ""Select items"",
                        ""emoji"": true
                      }
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_context_block()
        {
            var block = new SlackContextBlock();
            block.Elements.Add(new SlackImageBlockElement()
            {
                Url = new Uri("https://image.freepik.com/free-photo/red-drawing-pin_1156-445.jpg"),
                AlternateText = "images"
            });
            block.Elements.Add(new SlackMarkdownText("Location: **Dogpatch**"));

            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""context"",
                  ""elements"": [
                    {
                      ""type"": ""image"",
                      ""image_url"": ""https://image.freepik.com/free-photo/red-drawing-pin_1156-445.jpg"",
                      ""alt_text"": ""images""
                    },
                    {
                      ""type"": ""mrkdwn"",
                      ""text"": ""Location: **Dogpatch**""
                    }
                  ]
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_divider_block()
        {
            var block = new SlackDividerBlock();

            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""divider""
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_file_block()
        {
            var block = new SlackFileBlock
            {
                ExternalId = "ABCD1"
            };

            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""file"",
                  ""external_id"": ""ABCD1"",
                  ""source"": ""remote"",
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_an_image_block()
        {
            var block = new SlackImageBlock()
            {
                Title = new SlackPlainText("Please enjoy this photo of a kitten"),
                BlockId = "image4",
                Url = new Uri("http://placekitten.com/500/500"),
                AlternateText = "An incredibly cute kitten."
            };

            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""image"",
                  ""title"": {
                    ""type"": ""plain_text"",
                    ""text"": ""Please enjoy this photo of a kitten""
                  },
                  ""block_id"": ""image4"",
                  ""image_url"": ""http://placekitten.com/500/500"",
                  ""alt_text"": ""An incredibly cute kitten.""
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_section_block()
        {
            var block = new SlackSectionBlock()
            {
                Text = new SlackMarkdownText("A message *with some bold text* and _some italicized text_.")
            };

            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""section"",
                  ""text"": {
                    ""type"": ""mrkdwn"",
                    ""text"": ""A message *with some bold text* and _some italicized text_.""
                  }
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        [Fact]
        public void convertslackmessage_should_return_expected_result_when_the_message_contains_a_header_block()
        {
            var block = new SlackHeaderBlock()
            {
                Text = new SlackPlainText("A message with some bold text and some other text.")
            };

            var expectedSlackMessage = CreateSlackMessage(block);

            var json = @"{
              ""as_user"": false,
              ""channel"": ""#test"",
              ""icon_emoji"": "":smiley:"",
              ""mrkdwn"": false,
              ""text"": ""My Super Text"",
              ""username"": ""MyAppBot"",
              ""unfurl_media"": false,
              ""blocks"": [
                {
                  ""type"": ""header"",
                  ""text"": {
                    ""type"": ""plain_text"",
                    ""text"": ""A message with some bold text and some other text.""
                  }
                }
              ]
            }";
            var expectedSlackJsonMessage = JObject.Parse(json);

            var slackMessage = SlackExtensionConfigProvider.ConvertSlackMessage(expectedSlackJsonMessage);

            AssertMessage(slackMessage, expectedSlackMessage);
        }

        private SlackMessage CreateSlackMessage(object blockElement)
        {
            var slackMessage = new SlackMessage();
            slackMessage.AsUser = false;
            slackMessage.Channel = "#test";
            slackMessage.IconEmoji = ":smiley:";
            slackMessage.IsMarkdown = false;
            slackMessage.Text = "My Super Text";
            slackMessage.Username = "MyAppBot";
            slackMessage.Blocks.Add(blockElement);

            return slackMessage;
        }

        private void AssertMessage(SlackMessage actual, SlackMessage expected)
        {
            using (new AssertionScope())
            {
                actual.AsUser.Should().Be(expected.AsUser);
                actual.Channel.Should().Be(expected.Channel);
                actual.IconEmoji.Should().Be(expected.IconEmoji);
                actual.IsMarkdown.Should().Be(expected.IsMarkdown);
                actual.IconUrl.Should().Be(expected.IconUrl);
                actual.UnfurlLinks.Should().Be(expected.UnfurlLinks);
                actual.UnfurlMedia.Should().Be(expected.UnfurlMedia);
                actual.Username.Should().Be(expected.Username);
                actual.Text.Should().Be(expected.Text);
                actual.Blocks.Should().BeEquivalentTo(expected.Blocks);
            }
        }
    }
}
