using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackDividerBlockValidator : AbstractValidator<SlackDividerBlock>
    {
        public SlackDividerBlockValidator()
        {
            RuleFor(x => x.BlockId).MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.BlockId));
        }
    }
}