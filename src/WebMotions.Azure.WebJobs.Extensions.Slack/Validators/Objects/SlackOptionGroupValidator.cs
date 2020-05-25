using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects
{
    public class SlackOptionGroupValidator : AbstractValidator<SlackOptionGroup>
    {
        public SlackOptionGroupValidator()
        {
            RuleFor(x => x.Label)
                .Must(x => x != null && x.Text.Length <= 75)
                .WithMessage("Label cannot be empty and the length should be 75 characters or less");
            RuleFor(x => x.Options)
                .Must(x => x != null && x.Count <= 100)
                .WithMessage("Collection cannot be null and the maximum of 100 elements can be included in an option group");

        }
    }
}