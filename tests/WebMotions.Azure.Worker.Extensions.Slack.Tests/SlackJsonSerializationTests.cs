using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Models;

namespace WebMotions.Azure.Worker.Extensions.Slack.Tests
{
    public class SlackJsonSerializationTests
    {
        [Fact]
        public void slackMessage_should_serialize_and_deserialize_correctly()
        {
            var messages = new List<SlackMessage>();
            var samples = new SlackMessageSample();

            var slackMessageSample1 = samples.GetSample1();
            messages.Add(slackMessageSample1);

            var slackMessageSample2 = samples.GetSample2();
            messages.Add(slackMessageSample2);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };

            var serialized = JsonSerializer.Serialize(messages, options);
            var deserialized = JsonSerializer.Deserialize<List<SlackMessage>>(serialized, options);

            deserialized.Should().NotBeNull();
            deserialized.Count.Should().Be(2);
            deserialized[0].Blocks.Count.Should().Be(7);
        }
    }
}
