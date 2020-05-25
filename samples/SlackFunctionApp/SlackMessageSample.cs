using System;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace SlackFunctionApp
{
    public class SlackMessageSample
    {
        public SlackMessage GetSample1()
        {
            var slackMessage = new SlackMessage();
            slackMessage.Text = "The assistant to the Regional Manager Dwight has an announcement!";

            var sectionBlock1 = new SlackSectionBlock();
            // can also use new SlackMarkdownText() {Text = "..."};
            SlackMarkdownText text1 = "Hello, Assistant to the Regional Manager Dwight! *Michael Scott* wants to know where you'd like to take the Paper Company investors to dinner tonight.\n\n *Please select a restaurant:*";
            sectionBlock1.Text = text1;
            slackMessage.Blocks.Add(sectionBlock1);

            var divider = new SlackDividerBlock();
            divider.BlockId = null; // to enable reuse
            slackMessage.Blocks.Add(divider);

            var sectionBlock2 = new SlackSectionBlock();
            SlackMarkdownText text2 = "*Farmhouse Thai Cuisine*\n:star::star::star::star: 1528 reviews\n They do have some vegan options, like the roti and curry, plus they have a ton of salad stuff and noodles can be ordered without meat!! They have something for everyone here";
            sectionBlock2.Text = text2;
            sectionBlock2.Accessory = new SlackImageBlockElement
            {
                Url = new Uri("https://s3-media3.fl.yelpcdn.com/bphoto/c7ed05m9lC2EmA3Aruue7A/o.jpg"),
                AlternateText = "alt text for image"
            };
            slackMessage.Blocks.Add(sectionBlock2);

            var sectionBlock3 = new SlackSectionBlock();
            SlackMarkdownText text3 = "*Kin Khao*\n:star::star::star::star: 1638 reviews\n The sticky rice also goes wonderfully with the caramelized pork belly, which is absolutely melt-in-your-mouth and so soft.";
            sectionBlock3.Text = text3;
            sectionBlock3.Accessory = new SlackImageBlockElement
            {
                Url = new Uri("https://s3-media2.fl.yelpcdn.com/bphoto/korel-1YjNtFtJlMTaC26A/o.jpg"),
                AlternateText = "alt text for image"
            };
            slackMessage.Blocks.Add(sectionBlock3);

            var sectionBlock4 = new SlackSectionBlock();
            SlackMarkdownText text4 = "*Ler Ros*\n:star::star::star::star: 2082 reviews\n I would really recommend the  Yum Koh Moo Yang - Spicy lime dressing and roasted quick marinated pork shoulder, basil leaves, chili & rice powder.";
            sectionBlock4.Text = text4;
            sectionBlock4.Accessory = new SlackImageBlockElement
            {
                Url = new Uri("https://s3-media2.fl.yelpcdn.com/bphoto/DawwNigKJ2ckPeDeDM7jAg/o.jpg"),
                AlternateText = "alt text for image"
            };
            slackMessage.Blocks.Add(sectionBlock4);

            slackMessage.Blocks.Add(divider);

            var actionBlock = new SlackActionBlock();

            var buttonElement1 = new SlackButtonBlockElement();
            SlackPlainText text5 = "Farmhouse";
            text5.Emoji = true;
            buttonElement1.Text = text5;
            buttonElement1.Value = "click_me_123";
            actionBlock.Elements.Add(buttonElement1);

            var buttonElement2 = new SlackButtonBlockElement();
            SlackPlainText text6 = "Kin Khao";
            text5.Emoji = true;
            buttonElement2.Text = text6;
            buttonElement2.Value = "click_me_123";
            actionBlock.Elements.Add(buttonElement2);

            var buttonElement3 = new SlackButtonBlockElement();
            SlackPlainText text7 = "Ler Ros";
            text5.Emoji = true;
            buttonElement3.Text = text7;
            buttonElement3.Value = "click_me_123";
            actionBlock.Elements.Add(buttonElement3);

            slackMessage.Blocks.Add(actionBlock);

            return slackMessage;
        }

        public SlackMessage GetSample2()
        {
            var slackMessage = new SlackMessage();
            slackMessage.Text = "The assistant to the Regional Manager Dwight has an announcement!";

            var sectionBlock1 = new SlackSectionBlock();
            sectionBlock1.Text = new SlackMarkdownText { Text = "Take a look at this image." };
            sectionBlock1.Accessory = new SlackImageBlockElement
            {
                Url = new Uri("https://api.slack.com/img/blocks/bkb_template_images/palmtree.png"),
                AlternateText = "palm tree"
            };

            var sectionBlock2 = new SlackSectionBlock();
            sectionBlock2.Text = new SlackMarkdownText { Text = "You can add a button alongside text in your message." };
            sectionBlock2.Accessory = new SlackButtonBlockElement()
            {
                Text = new SlackPlainText { Emoji = false, Text = "Button" },
                Value = "click_me_123"
            };

            var sectionBlock3 = new SlackSectionBlock();
            sectionBlock3.Text = new SlackMarkdownText { Text = "Pick one or more items from the list" };
            sectionBlock3.Accessory = new SlackMultiSelectMenuStaticBlockElement
            {
                Placeholder = "Select items",
                Options =
                {
                    new SlackOption
                    {
                        Text = new SlackPlainText {Text = "Choice 1"},
                        Value = "value-0"
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText {Text = "Choice 2"},
                        Value = "value-1"
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText {Text = "Choice 3"},
                        Value = "value-2"
                    }
                }
            };

            var sectionBlock4 = new SlackSectionBlock();
            sectionBlock4.Text = new SlackMarkdownText { Text = "This block has an overflow menu." };
            sectionBlock4.Accessory = new SlackOverflowMenuBlockElement
            {
                Options =
                {
                    new SlackOption
                    {
                        Text = new SlackPlainText {Text = "Choice 1"},
                        Value = "value-0"
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText {Text = "Choice 2"},
                        Value = "value-1"
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText {Text = "Choice 3"},
                        Value = "value-2"
                    },
                    new SlackOption
                    {
                        Text = new SlackPlainText {Text = "Choice 4"},
                        Value = "value-3"
                    }
                }
            };

            var sectionBlock5 = new SlackSectionBlock();
            sectionBlock5.Text = new SlackMarkdownText { Text = "Pick a date for the deadline." };
            sectionBlock5.Accessory = new SlackDatePickerBlockElement
            {
                InitialDate = new DateTime(1990, 04, 28),
                Placeholder = new SlackPlainText
                {
                    Text = "Select a date"
                }
            };

            var sectionBlock6 = new SlackSectionBlock();
            sectionBlock6.Fields.Add(new SlackPlainText { Text = "*this is plain_text text*" });
            sectionBlock6.Fields.Add(new SlackPlainText { Text = "*this is plain_text text*" });
            sectionBlock6.Fields.Add(new SlackPlainText { Text = "*this is plain_text text*" });
            sectionBlock6.Fields.Add(new SlackPlainText { Text = "*this is plain_text text*" });

            slackMessage.Blocks.AddRange(new[] { sectionBlock1, sectionBlock2, sectionBlock3, sectionBlock4, sectionBlock5, sectionBlock6 });

            return slackMessage;
        }
    }
}