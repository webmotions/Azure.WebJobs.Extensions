using System.Collections.Generic;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects
{
    /// <summary>
    /// Provides a way to group options in a select menu or multi-select menu.
    /// </summary>
    public class SlackOptionGroup
    {
        /// <summary>
        /// Gets or sets the label shown above this group of options
        /// </summary>
        /// <remarks>
        /// Maximum length for the text is 75 characters.
        /// </remarks>
        public SlackPlainText Label { get; set; }

        /// <summary>
        /// Gets a collection of option objects that belong to this specific group.
        /// </summary>
        /// <remarks>
        /// Maximum of 100 items.
        /// </remarks>
        public List<SlackOption> Options { get; set; } = new List<SlackOption>();
    }
}