using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Blocks
{
    public class SlackInputBlockValidator : AbstractValidator<SlackInputBlock>
    {
        public SlackInputBlockValidator()
        {
            RuleFor(x => x.Label)
                .Must(x => x != null && x.Text.Length <= 2000).WithMessage("Label cannot be null and the maximum length must be 2000");
            RuleFor(x => x.Element)
                .Must(x => x != null && (x is SlackPlainText || x is SlackDatePickerBlockElement || x is SlackMenuBlockElementBase))
                .WithMessage("Element cannot be null and must of the type plaintext, datepicker, select or multi-select");
        }
    }
}