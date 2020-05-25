using Newtonsoft.Json;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements
{
    public abstract class SlackMenuExternalSourceBlockElementBase : SlackMenuBlockElementBase
    {
        /// <summary>
        /// Gets or sets when the typeahead field is used, a request will be sent on every character change.
        /// If you prefer fewer requests or more fully ideated queries, use the min_query_length attribute to tell Slack the fewest number of typed characters required before dispatch.
        /// </summary>
        /// <remarks>
        /// If not set, the default value set by Slack is 3
        /// </remarks>
        [JsonProperty("min_query_length")]
        public int? MinimumQueryLength { get; set; }
    }
}