using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    /// <summary>
    /// Clean the message blocks in accordance to Slack API's contracts
    /// </summary>
    internal class SlackBlockCleaner
    {
        private readonly IEnumerable<object> _blocks;

        public SlackBlockCleaner(IEnumerable<object> blocks)
        {
            _blocks = blocks;
        }

        public void Clean()
        {
            foreach (var blockElement in _blocks)
            {
                if (blockElement is SlackActionBlock actionBlock)
                {
                    // see https://api.slack.com/reference/block-kit/block-elements#static_multi_select and
                    // https://api.slack.com/reference/block-kit/block-elements#static_select
                    foreach (var element in actionBlock.Elements)
                    {
                        if (element is SlackMenuStaticBlockElementBase staticBlockElementBase)
                        {
                            CleanStaticBlockElement(staticBlockElementBase);
                        }
                        else if (element is SlackCheckboxBlockElement checkboxBlock)
                        {
                            if (checkboxBlock.SelectedOptions?.Count == 0)
                            {
                                checkboxBlock.SelectedOptions = null;
                            }
                        }
                        else if (element is SlackMultiSelectMenuExternalSourceBlockElement multiSelectMenuExternalSourceBlockElement)
                        {
                            if (multiSelectMenuExternalSourceBlockElement?.InitialOptions.Count == 0)
                            {
                                multiSelectMenuExternalSourceBlockElement.InitialOptions = null;
                            }
                        }
                    }
                }
                if (blockElement is SlackContextBlock contextBlock)
                {
                    foreach (var element in contextBlock.Elements)
                    {
                        if (element is SlackMenuStaticBlockElementBase staticBlockElement)
                        {
                            CleanStaticBlockElement(staticBlockElement);
                        }

                        if (element is SlackMultiSelectMenuExternalSourceBlockElement multiSelectMenuExternalSourceBlockElement)
                        {
                            if (multiSelectMenuExternalSourceBlockElement?.InitialOptions.Count == 0)
                            {
                                multiSelectMenuExternalSourceBlockElement.InitialOptions = null;
                            }
                        }
                    }
                }
                else if (blockElement is SlackSectionBlock sectionBlock)
                {
                    var element = sectionBlock.Accessory;
                    if (element is SlackMenuStaticBlockElementBase staticBlockElement)
                    {
                        CleanStaticBlockElement(staticBlockElement);
                    }
                    else if (element is SlackCheckboxBlockElement checkboxBlock)
                    {
                        if (checkboxBlock.SelectedOptions?.Count == 0)
                        {
                            checkboxBlock.SelectedOptions = null;
                        }
                    }
                    else if (element is SlackMultiSelectMenuExternalSourceBlockElement multiSelectMenuExternalSourceBlockElement)
                    {
                        if (multiSelectMenuExternalSourceBlockElement?.InitialOptions.Count == 0)
                        {
                            multiSelectMenuExternalSourceBlockElement.InitialOptions = null;
                        }
                    }

                    if (sectionBlock.Fields?.Count == 0)
                    {
                        sectionBlock.Fields = null;
                    }
                }
                else if (blockElement is SlackInputBlock inputBlock)
                {
                    var element = inputBlock.Element;
                    if (element is SlackMenuStaticBlockElementBase staticBlockElement)
                    {
                        CleanStaticBlockElement(staticBlockElement);
                    }
                    else if (element is SlackCheckboxBlockElement checkboxBlock)
                    {
                        if (checkboxBlock.SelectedOptions?.Count == 0)
                        {
                            checkboxBlock.SelectedOptions = null;
                        }
                    }
                    else if (element is SlackMultiSelectMenuExternalSourceBlockElement multiSelectMenuExternalSourceBlockElement)
                    {
                        if (multiSelectMenuExternalSourceBlockElement?.InitialOptions.Count == 0)
                        {
                            multiSelectMenuExternalSourceBlockElement.InitialOptions = null;
                        }
                    }
                }
            }
        }

        private void CleanStaticBlockElement(SlackMenuStaticBlockElementBase staticBlockElement)
        {
            // if options is specified, option_groups field should not be.
            if (staticBlockElement.OptionGroups?.Count == 0)
            {
                staticBlockElement.OptionGroups = null;
            }

            // if option_groups is specified, options field should not be.
            if (staticBlockElement.Options?.Count == 0)
            {
                staticBlockElement.Options = null;
            }

            if (staticBlockElement.SelectedOptions?.Count == 0)
            {
                staticBlockElement.SelectedOptions = null;
            }
        }
    }
}