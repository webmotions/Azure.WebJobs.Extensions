using FluentAssertions;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;
using Xunit;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Tests
{
    public class SlackTextTests
    {
        [Fact]
        public void slackplaintext_should_be_able_to_be_created_from_a_string()
        {
            var text = "My text";
            SlackPlainText actual = text;

            actual.Text.Should().Be(text);
        }

        [Fact]
        public void slackmarkdowntext_should_be_able_to_be_created_from_a_string()
        {
            var text = "My text";
            SlackMarkdownText actual = text;

            actual.Text.Should().Be(text);
        }
    }
}