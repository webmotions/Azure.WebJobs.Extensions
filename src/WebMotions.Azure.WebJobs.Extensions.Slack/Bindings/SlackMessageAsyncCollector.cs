using FluentValidation.Results;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;
using WebMotions.Azure.WebJobs.Extensions.Slack.Validators;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Bindings
{
    public class SlackMessageAsyncCollector : IAsyncCollector<SlackMessage>
    {
        private readonly SlackContext _context;
        private readonly ISlackHttpClient _slackHttpClient;
        private readonly ILogger _logger;
        private readonly ConcurrentQueue<SlackMessage> _messages = new ConcurrentQueue<SlackMessage>();

        public SlackMessageAsyncCollector(SlackContext context,
                                          ISlackHttpClient slackHttpClient,
                                          ILogger logger)
        {
            _context = context;
            _slackHttpClient = slackHttpClient;
            _logger = logger;
        }

        public Task AddAsync(SlackMessage message, CancellationToken cancellationToken = new CancellationToken())
        {
            var channel = Utility.FirstOrDefault(_context.Channel, message.Channel);
            var iconUrl = Utility.FirstOrDefault(_context.IconUrl, message.IconUrl);
            var iconEmoji = Utility.FirstOrDefault(_context.IconEmoji, message.IconEmoji);
            var userName = Utility.FirstOrDefault(_context.UserName, message.Username);

            if (!string.IsNullOrWhiteSpace(message.Username) && message.AsUser)
            {
                _logger.LogWarning("The AsUser flag cannot be used in conjunction with the username property. It was switched to false");
                message.AsUser = false;
            }

            message.Channel = channel;
            message.IconUrl = iconUrl;
            message.Username = userName;

            Validate(message);
            var blockCleaner = new SlackBlockCleaner(message.Blocks);
            blockCleaner.Clean();

            _messages.Enqueue(message);

            return Task.CompletedTask;
        }



        private void Validate(SlackMessage message)
        {
            var errors = new Dictionary<string, IList<ValidationFailure>>();
            var slackMessageValidator = new SlackMessageValidator();
            var results = slackMessageValidator.Validate(message);

            if (!results.IsValid)
            {
                errors.Add(nameof(SlackMessage), results.Errors);
                GenerateLogsAndThrow(errors);
            }

            if (message.Blocks.Count > 0)
            {
                var validator = new SlackBlockValidator();
                for (int i = 0; i < message.Blocks.Count; i++)
                {
                    var block = message.Blocks[i];
                    var result = validator.Validate(block);
                    if (!result.IsValid)
                    {
                        errors.Add($"Block[{i + 1}] - {block.GetType().Name}", result.Errors);
                    }
                }
            }

            if (errors.Count > 0)
            {
                GenerateLogsAndThrow(errors);
                throw new SlackValidationException();
            }
        }

        public async Task FlushAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            while (_messages.TryDequeue(out SlackMessage message))
            {
                await _slackHttpClient.PostMessageAsync(_context, message);
            }
        }

        private void GenerateLogsAndThrow(IDictionary<string, IList<ValidationFailure>> errors)
        {
            var correlationId = $"slackExtension_{Guid.NewGuid()}";
            var state = new Dictionary<string, object>()
            {
                { "CorrelationId", correlationId }
            };

            using (_logger.BeginScope(state))
            {
                foreach (var error in errors)
                {
                    var errorMessage = BuildErrorMessage(error.Key, error.Value);
                    _logger.LogError(errorMessage, error.Key);

                }
            }
            throw new SlackValidationException($"One of more validation error occured. Refer to your error logs with correction id {correlationId}");
        }

        private static string BuildErrorMessage(string name, IEnumerable<ValidationFailure> errors)
        {
            var arr = errors.Select(x => $"{Environment.NewLine}-- {x.PropertyName}: {x.ErrorMessage}");
            return "Validation failed [{Name}]:" + string.Join(string.Empty, arr);
        }
    }
}