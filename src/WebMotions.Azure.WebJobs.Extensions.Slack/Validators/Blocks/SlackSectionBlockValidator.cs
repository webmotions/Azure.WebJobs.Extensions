using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackSectionBlockValidator : AbstractValidator<SlackSectionBlock>
    {
        public SlackSectionBlockValidator()
        {
            RuleFor(x => x.BlockId).MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.BlockId));
            RuleFor(x => x.Fields).Must(x => x != null && x.Count <= 10).WithMessage("Collection cannot be null and the maximum number of items is 10.");
            RuleForEach(x => x.Fields).Must(x => x.Text.Length <= 2000).WithMessage("Maximum length for the text is 2000 characters.");
            RuleFor(x => x.Accessory)
                .Must(x => x is SlackButtonBlockElement ||
                           x is SlackDatePickerBlockElement ||
                           x is SlackImageBlockElement ||
                           x is SlackMenuBlockElementBase ||
                           x is SlackPlainTextInputBlockElement ||
                           x is SlackOverflowMenuBlockElement ||
                           x is SlackRadioButtonGroupBlockElement)
                .WithMessage("Requires a block element")
                .When(x => x.Accessory != null);
        }
    }
}