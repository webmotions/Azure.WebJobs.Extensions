using System;
using Microsoft.Azure.WebJobs.Description;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class SlackAttribute : Attribute
    {
        [AppSetting]
        public string WebHookUrl { get; set; }

        /// <summary>
        /// Gets or sets the username for the outgoing request. May include binding parameters.
        /// </summary>
        [AutoResolve]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the channel the message is sent to. Use "#{name}" to send to a channel, and "@{name}" to send to a specific user.". May include binding parameters.
        /// </summary>
        [AutoResolve]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the icon emoji displayed for the message. Use ":{emoji_name}:" in your string. May include binding parameters.
        /// </summary>
        /// <remarks>
        /// The format for emoji is a keyword surrounded by ":". It supports custom emojis.
        /// </remarks>
        /// <example>
        /// Example Icon Emoji for heart: ":heart:"
        /// </example>
        [AutoResolve]
        public string IconEmoji { get; set; }

        /// <summary>
        /// Tells Slack whether or not to process this message as Markdown. Default value is true. May include binding parameters.
        /// </summary>
        public bool IsMarkdown { get; set; } = true;
    }
}