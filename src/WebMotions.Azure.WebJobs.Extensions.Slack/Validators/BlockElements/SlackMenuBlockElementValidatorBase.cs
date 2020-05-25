using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackMenuBlockElementValidatorBase : AbstractValidator<SlackMenuBlockElementBase>
    {
        public SlackMenuBlockElementValidatorBase()
        {
            RuleFor(x => x.ActionId).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Placeholder).Must(x => x != null && x.Text.Length <= 150).WithMessage("Maximum length is 150 characters");
            RuleFor(x => x.Confirm).SetValidator(new SlackConfirmationValidator()).When(x => x.Confirm != null);
        }
    }
}