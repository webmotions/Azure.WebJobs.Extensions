using Newtonsoft.Json;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// This menu will load its options from an external data source, allowing for a dynamic list of options.
    /// </summary>
    public class SlackMultiSelectMenuExternalSourceBlockElement : SlackMenuExternalSourceBlockElementBase
    {
        public override string Type { get; } = "multi_external_select";

        /// <summary>
        /// Gets or sets the identifier for the action.
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public override string ActionId { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="SlackOption"/> or <see cref="SlackOptionGroup"/> objects that exactly match one or more of the options.
        /// These options will be selected when the menu initially loads.
        /// </summary>
        [JsonProperty("initial_options", ItemConverterType = typeof(SlackOptionsConverter))]
        public List<object> InitialOptions { get; set; } = new List<object>();

        /// <summary>
        /// Gets or sets the maximum number of items that can be selected in the menu
        /// </summary>
        /// <remarks>
        /// If set, the minimum number is 1
        /// </remarks>
        [JsonProperty("max_selected_items")]
        public int? MaximumSelectedItems { get; set; }
    }
}