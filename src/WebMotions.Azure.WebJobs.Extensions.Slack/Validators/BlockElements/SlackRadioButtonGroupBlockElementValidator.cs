using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackRadioButtonGroupBlockElementValidator : AbstractValidator<SlackRadioButtonGroupBlockElement>
    {
        public SlackRadioButtonGroupBlockElementValidator()
        {
            RuleFor(x => x.ActionId).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Options).NotEmpty();
            RuleFor(x => x.Confirm).SetValidator(new SlackConfirmationValidator()).When(x => x.Confirm != null);
        }
    }
}