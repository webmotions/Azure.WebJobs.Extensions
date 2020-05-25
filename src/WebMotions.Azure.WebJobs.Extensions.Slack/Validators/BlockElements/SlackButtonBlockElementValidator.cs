using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackButtonBlockElementValidator : AbstractValidator<SlackButtonBlockElement>
    {
        public SlackButtonBlockElementValidator()
        {
            RuleFor(x => x.Text.Text).NotEmpty().MaximumLength(75);
            RuleFor(x => x.ActionId).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Url.ToString()).MaximumLength(3000).When(x => x.Url != null);
            RuleFor(x => x.Value).MaximumLength(2000);
            RuleFor(x => x.Confirm).SetValidator(new SlackConfirmationValidator()).When(x => x.Confirm != null);
        }
    }
}