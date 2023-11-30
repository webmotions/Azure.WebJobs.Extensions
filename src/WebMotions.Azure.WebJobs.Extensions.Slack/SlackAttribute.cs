using Microsoft.Azure.WebJobs.Description;
using System;

namespace WebMotions.Azure.WebJobs.Extensions.Slack
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class SlackAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the WebHook url
        /// </summary>
        [AutoResolve]
        public string WebHookUrl { get; set; }

        /// <summary>
        /// Gets or sets the Slack API key
        /// </summary>
        [AutoResolve]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the bot's user name. May include binding parameters.
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
        /// The format for emoji is a keyword surrounded by ":". It supports custom emojis. See <see href="https://www.webfx.com/tools/emoji-cheat-sheet/">here</see>
        /// </remarks>
        /// <example>
        /// Example icon emoji for heart: ":heart:"
        /// </example>
        [AutoResolve]
        public string IconEmoji { get; set; }

        /// <summary>
        /// Gets or sets the icon url of the bot
        /// </summary>
        [AutoResolve]
        public string IconUrl { get; set; }
    }
}