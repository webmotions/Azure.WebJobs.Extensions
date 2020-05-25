using Newtonsoft.Json.Converters;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Converters
{
    /// <summary>
    /// Converts a <see cref="System.DateTime"/> into an ISO date, ignoring the time
    /// </summary>
    public class JsonDateTimeIsoOverrideConverter : IsoDateTimeConverter
    {
        public JsonDateTimeIsoOverrideConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}