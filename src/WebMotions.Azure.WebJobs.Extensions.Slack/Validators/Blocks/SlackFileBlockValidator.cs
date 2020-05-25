using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackFileBlockValidator : AbstractValidator<SlackFileBlock>
    {
        public SlackFileBlockValidator()
        {
            RuleFor(x => x.BlockId).MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.BlockId));
            RuleFor(x => x.ExternalId).NotEmpty();
            RuleFor(x => x.Source).NotEmpty();
        }
    }
}