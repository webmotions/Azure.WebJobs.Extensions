using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackDatePickerBlockElementValidator : AbstractValidator<SlackDatePickerBlockElement>
    {
        public SlackDatePickerBlockElementValidator()
        {
            RuleFor(x => x.ActionId).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Placeholder).Must(x => x.Text.Length <= 150).When(x => x.Placeholder != null);
            RuleFor(x => x.Confirm).SetValidator(new SlackConfirmationValidator()).When(x => x.Confirm != null);
        }
    }
}