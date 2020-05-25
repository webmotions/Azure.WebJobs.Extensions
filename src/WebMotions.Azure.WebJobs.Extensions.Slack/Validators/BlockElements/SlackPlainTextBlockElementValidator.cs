using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackPlainTextBlockElementValidator : AbstractValidator<SlackPlainTextInputBlockElement>
    {
        public SlackPlainTextBlockElementValidator()
        {
            RuleFor(x => x.ActionId).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Placeholder.Text).MaximumLength(150).When(x => x.Placeholder != null);
            RuleFor(x => x.MinimumLength.Value)
                .Must(x => x <= 3000).WithMessage("Maximum value is 3000")
                .When(x => x.MinimumLength.HasValue);
        }
    }
}