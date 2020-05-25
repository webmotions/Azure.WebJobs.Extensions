using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackOverflowMenuBlockElementValidator : AbstractValidator<SlackOverflowMenuBlockElement>
    {
        public SlackOverflowMenuBlockElementValidator()
        {
            RuleFor(x => x.ActionId).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Options)
                .Must(x => x != null && x.Count <= 5 && x.Count >= 2)
                .WithMessage("Collection cannot be null and the maximum number of options is 5, minimum is 2.");
            RuleFor(x => x.Confirm).SetValidator(new SlackConfirmationValidator()).When(x => x.Confirm != null);
        }
    }
}