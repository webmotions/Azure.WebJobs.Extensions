using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects
{
    public class SlackOptionValidator : AbstractValidator<SlackOption>
    {
        public SlackOptionValidator()
        {
            RuleFor(x => x.Text)
                .Must(x => x != null && x.Text.Length <= 75).WithMessage("Text cannot be null and the length should be 75 characters or less");
            RuleFor(x => x.Value).MaximumLength(75);
            RuleFor(x => x.Description.Text).MaximumLength(75).When(x => x.Description != null);
            RuleFor(x => x.Url.ToString()).MaximumLength(3000).When(x => x.Url != null);
        }
    }
}