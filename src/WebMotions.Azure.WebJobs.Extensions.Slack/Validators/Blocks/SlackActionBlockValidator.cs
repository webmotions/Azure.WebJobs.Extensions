using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackActionBlockValidator : AbstractValidator<SlackActionBlock>
    {
        public SlackActionBlockValidator()
        {
            RuleFor(x => x.BlockId).MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.BlockId));
            RuleFor(x => x.Elements).Must(x => x != null && x.Count <= 5).WithMessage("Collection cannot be null and the maximum of 5 elements are allowed in the action block");
            RuleForEach(x => x.Elements)
                .Must(x => x is SlackButtonBlockElement ||
                           x is SlackMenuBlockElementBase ||
                           x is SlackOverflowMenuBlockElement ||
                           x is SlackDatePickerBlockElement)
                .WithMessage("Element objects can be buttons, select menus, overflow menus, or date pickers.");
        }
    }
}