using System;
using WebMotions.Azure.WebJobs.Extensions.Slack.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    /// <summary>
    /// An object that represents a single selectable item in a select menu, multi-select menu, checkbox group, radio button group, or overflow menu.
    /// </summary>
    public class SlackOption
    {
        /// <summary>
        /// Gets or sets the text shown in the option on the menu
        /// </summary>
        /// <remarks>
        /// Overflow, select, and multi-select menus can only use <see cref="SlackPlainText"/>, while radio buttons and checkboxes can use <see cref="SlackMarkdownText"/>. Maximum length is 75 characters.
        /// </remarks>
        [Newtonsoft.Json.JsonConverter(typeof(SlackTextConverter))]
        public SlackText Text { get; set; }

        /// <summary>
        /// Gets or sets the string value that will be passed to your app when this option is chosen
        /// </summary>
        /// <remarks>
        /// Maximum length is 75 characters.
        /// </remarks>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the line of descriptive text shown below the text field beside the radio button
        /// </summary>
        /// <remarks>
        /// Maximum length for the text contained within is 75 characters.
        /// </remarks>
        public SlackPlainText Description { get; set; }

        /// <summary>
        /// Gets or sets a URL to load in the user's browser when the option is clicked
        /// </summary>
        /// <remarks>
        /// The url attribute is only available in overflow menus. Maximum length is 3000 characters. 
        /// </remarks>
        public Uri Url { get; set; }
    }
}