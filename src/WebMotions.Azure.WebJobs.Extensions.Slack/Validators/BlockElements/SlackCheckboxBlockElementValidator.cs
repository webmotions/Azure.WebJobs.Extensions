using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackCheckboxBlockElementValidator : AbstractValidator<SlackCheckboxBlockElement>
    {
        public SlackCheckboxBlockElementValidator()
        {
            RuleFor(x => x.ActionId).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Options).NotEmpty();
        }
    }
}