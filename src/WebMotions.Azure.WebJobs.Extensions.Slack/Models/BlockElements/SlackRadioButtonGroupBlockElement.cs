using Newtonsoft.Json;
using System.Collections.Generic;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    /// <summary>
    /// A radio button group that allows a user to choose one item from a list of possible options.
    /// </summary>
    public class SlackRadioButtonGroupBlockElement
    {
        /// <summary>
        /// Gets the type of the block element.
        /// </summary>
        public string Type { get; } = "radio_buttons";

        /// <summary>
        /// Gets the identifier for the action. Defaults to rbtngrp_{NewGuid}
        /// </summary>
        /// <remarks>
        /// Should be unique among all other action_ids used elsewhere by your app. Maximum length is 255 characters.
        /// </remarks>
        [JsonProperty("action_id")]
        public string ActionId { get; set; }

        /// <summary>
        /// Gets a collection of <see cref="SlackOption"/>
        /// </summary>
        public List<SlackOption> Options { get; set; } = new List<SlackOption>();

        /// <summary>
        /// Gets or sets a <see cref="SlackOption"/> that exactly matches one of the options within <see cref="Options"/>.
        /// This option will be selected when the radio button group initially loads.
        /// </summary>
        [JsonProperty("initial_option")]
        public SlackOption InitialOption { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="SlackConfirmation"/> that defines an optional confirmation dialog after the button is clicked.
        /// </summary>
        public SlackConfirmation Confirm { get; set; }
    }
}