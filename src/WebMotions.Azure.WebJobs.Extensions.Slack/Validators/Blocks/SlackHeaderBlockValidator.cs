using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackHeaderBlockValidator : AbstractValidator<SlackHeaderBlock>
    {
        public SlackHeaderBlockValidator()
        {
            RuleFor(x => x.Text).Must(x => x != null && x.Text.Length <= 150).WithMessage("Text cannot be null and the maximum length is 150 characters");
            RuleFor(x => x.BlockId).MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.BlockId));
        }
    }
}