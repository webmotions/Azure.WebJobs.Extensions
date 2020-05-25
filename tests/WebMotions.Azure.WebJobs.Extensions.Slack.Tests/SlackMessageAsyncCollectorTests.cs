using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Threading.Tasks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Bindings;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;
using Xunit;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Tests
{
    public class SlackMessageAsyncCollectorTests
    {
        private readonly ISlackHttpClient _httpClient;
        private readonly ILogger _logger;

        public SlackMessageAsyncCollectorTests()
        {
            _httpClient = Substitute.For<ISlackHttpClient>();
            _logger = Substitute.For<ILogger>();
        }

        [Fact]
        public async Task collector_should_set_the_asUser_property_to_false_when_asUser_is_true_and_username_is_not_empty()
        {
            var context = new SlackContext();
            var slackMessage = new SlackMessage();
            slackMessage.Username = "username";
            slackMessage.AsUser = true;
            slackMessage.Channel = "#devtest";
            slackMessage.Text = "Hello!";

            var collector = new SlackMessageAsyncCollector(context, _httpClient, _logger);

            Func<Task> act = async () => { await collector.AddAsync(slackMessage); };
            await act();

            slackMessage.AsUser.Should().Be(false);
        }
    }
}