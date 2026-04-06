using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackImageBlockValidator : AbstractValidator<SlackImageBlock>
    {
        public SlackImageBlockValidator()
        {
            RuleFor(x => x.BlockId).MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.BlockId));
            RuleFor(x => x.Url).Must(x => x != null && x.ToString().Length <= 3000).WithMessage("Url cannot be null and the maximum length is 3000 characters");
            RuleFor(x => x.AlternateText).NotEmpty().MaximumLength(2000);
        }
    }
}