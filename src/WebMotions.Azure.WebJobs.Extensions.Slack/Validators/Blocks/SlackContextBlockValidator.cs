using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackContextBlockValidator : AbstractValidator<SlackContextBlock>
    {
        public SlackContextBlockValidator()
        {
            RuleFor(x => x.BlockId).MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.BlockId));
            RuleFor(x => x.Elements)
                .Must(x => x != null && x.Count <= 5).WithMessage("Collection cannot be empty and the maximum of 10 elements are allowed in the context block");
            RuleForEach(x => x.Elements)
                .Must(x => x is SlackText || x is SlackImageBlockElement)
                .WithMessage("Only text and image elements are allowed");
        }
    }
}