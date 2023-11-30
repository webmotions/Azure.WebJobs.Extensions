using System;
using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

[assembly: ExtensionInformation("WebMotions.Azure.WebJobs.Extensions.Slack", "1.x.2")]

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Bindings
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]

    public class SlackOutputAttribute : OutputBindingAttribute
    {
        /// <summary>
        /// Gets or sets the WebHook url
        /// </summary>
        public string WebHookUrl { get; set; }

        /// <summary>
        /// Gets or sets the Slack API key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the bot's user name. May include binding parameters.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the channel the message is sent to. Use "#{name}" to send to a channel, and "@{name}" to send to a specific user.". May include binding parameters.
        /// </summary>
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
        public string IconEmoji { get; set; }

        /// <summary>
        /// Gets or sets the icon url of the bot
        /// </summary>
        public string IconUrl { get; set; }
    }
}