using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$kind")]
    [JsonDerivedType(typeof(SlackMultiSelectMenuStaticBlockElement), "slackMultiSelectMenuStaticBlockElement")]
    [JsonDerivedType(typeof(SlackSelectMenuStaticBlockElement), "slackSelectMenuStaticBlockElement")]
    public abstract class SlackMenuStaticBlockElementBase : SlackMenuBlockElementBase
    {
        /// <summary>
        /// Gets or sets a collection of <see cref="SlackOption"/>
        /// </summary>
        /// <remarks>
        /// Maximum number of 100 items.
        /// </remarks>
        public List<SlackOption> Options { get; set; } = new List<SlackOption>();

        /// <summary>
        /// Gets or sets a collection of <see cref="SlackOptionGroup"/>
        /// </summary>
        /// <remarks>
        /// Maximum number of 100 items
        /// </remarks>
        [JsonPropertyName("option_groups")]
        public List<SlackOptionGroup> OptionGroups { get; set; } = new List<SlackOptionGroup>();

        /// <summary>
        /// Gets a collection of options that will be selected when the checkbox group initially loads.
        /// </summary>
        /// <remarks>
        /// Have to be <see cref="SlackOption"/> that are included in the <see cref="Options"/> or <see cref="OptionGroups"/> collection
        /// </remarks>
        [JsonPropertyName("initial_options")]
        public List<SlackOption> SelectedOptions { get; set; } = new List<SlackOption>();
    }
}