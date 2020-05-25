using FluentAssertions;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;
using Xunit;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Tests
{
    public class SlackBlockCleanerTests
    {
        [Fact]
        public void actionblock_with_menu_static_block_element_the_optiongroups_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.OptionGroups.Should().BeNull();
        }

        [Fact]
        public void actionblock_with_menu_static_block_element_the_options_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.Options.Should().BeNull();
        }

        [Fact]
        public void actionblock_with_menu_static_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void actionblock_with_multi_menu_static_block_element_the_optiongroups_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.OptionGroups.Should().BeNull();
        }

        [Fact]
        public void actionblock_with_multi_menu_static_block_element_the_options_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.Options.Should().BeNull();
        }

        [Fact]
        public void actionblock_with_multi_menu_static_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void actionblock_with_multi_menu_external_source_block_element_the_initialoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackMultiSelectMenuExternalSourceBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.InitialOptions.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_menu_static_block_element_the_optiongroups_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.OptionGroups.Should().BeNull();
        }

        [Fact]
        public void actionblock_with_checkbox_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackActionBlock();
            var element = new SlackCheckboxBlockElement();
            block.Elements.Add(element);

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_menu_static_block_element_the_options_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.Options.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_menu_static_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_multi_menu_static_block_element_the_optiongroups_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.OptionGroups.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_multi_menu_static_block_element_the_options_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.Options.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_multi_menu_static_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_multi_menu_external_source_block_element_the_initialoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackMultiSelectMenuExternalSourceBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.InitialOptions.Should().BeNull();
        }

        [Fact]
        public void sectionblock_fields_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            block.Fields.Should().BeNull();
        }

        [Fact]
        public void sectionblock_with_checkbox_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackSectionBlock();
            var element = new SlackCheckboxBlockElement();
            block.Accessory = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_menu_static_block_element_the_optiongroups_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.OptionGroups.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_menu_static_block_element_the_options_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.Options.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_menu_static_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackSelectMenuStaticBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_multi_menu_static_block_element_the_optiongroups_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.OptionGroups.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_multi_menu_static_block_element_the_options_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.Options.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_multi_menu_static_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackMultiSelectMenuStaticBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_multi_menu_external_source_block_element_the_initialoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackMultiSelectMenuExternalSourceBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.InitialOptions.Should().BeNull();
        }

        [Fact]
        public void inputblock_with_checkbox_block_element_the_selectedoptions_collection_should_be_null_if_it_contains_no_elements()
        {
            var block = new SlackInputBlock();
            var element = new SlackCheckboxBlockElement();
            block.Element = element;

            var blockCleaner = new SlackBlockCleaner(new[] { block });
            blockCleaner.Clean();

            element.SelectedOptions.Should().BeNull();
        }
    }
}