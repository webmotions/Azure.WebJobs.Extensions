using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models
{
    public class SlackMessage
    {
        /// <summary>
        /// Gets or sets the body text of the message
        /// </summary>
        /// <remarks>
        /// If you are using blocks, this is used as a fallback string to display in notifications. If you aren't, this is the main body text of the message.
        /// </remarks>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the channel the message is sent to. Use "#{name}" to send to a channel, and "@{name}" to send to a specific user.".
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets bot's user name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the icon emoji displayed for the message. Use ":{emoji_name}:" in your string.
        /// </summary>
        /// <remarks>
        /// The format for emoji is a keyword surrounded by ":". It supports custom emojis. See <see href="https://www.webfx.com/tools/emoji-cheat-sheet/">here</see>
        /// </remarks>
        /// <example>
        /// Example icon emoji for heart: ":heart:"
        /// </example>
        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        /// <summary>
        /// Gets or sets the icon of the bot application
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets to tell Slack whether or not to process this message as Markdown. Default value is true.
        /// </summary>
        [JsonProperty("mrkdwn")]
        public bool IsMarkdown { get; set; } = true;

        /// <summary>
        /// Gets or sets whether to post the message as the authed user, instead of as a bot. Defaults to false.
        /// </summary>
        /// <remarks>
        /// Works only when a user JWT is used
        /// </remarks>
        [JsonProperty("as_user")]
        public bool AsUser { get; set; }

        /// <summary>
        /// Gets the collection of the structured blocks
        /// </summary>
        public List<object> Blocks { get; set; } = new List<object>();

        /// <summary>
        /// Gets or sets whether to enable unfurling of primarily text-based content. Defaults to true.
        /// </summary>
        [JsonProperty("unfurl_links")]
        public bool UnfurlLinks { get; set; } = true;

        /// <summary>
        /// Gets or sets to enable unfurling of media content. Defaults to false.
        /// </summary>
        [JsonProperty("unfurl_media")]
        public bool UnfurlMedia { get; set; }

        /// <summary>
        /// Gets an internal identifier for correlation purposes
        /// </summary>
        [JsonIgnore]
        public Guid Id { get; } = Guid.NewGuid();
    }
}