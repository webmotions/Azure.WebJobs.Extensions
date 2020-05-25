using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects
{
    public class SlackConfirmationValidator : AbstractValidator<SlackConfirmation>
    {
        public SlackConfirmationValidator()
        {
            RuleFor(x => x.Title).Must(x => x != null && x.Text.Length <= 100).WithMessage("Must not be null and must have a maximum length of 100 characters");
            RuleFor(x => x.Text).Must(x => x != null && x.Text.Length <= 300).WithMessage("Must not be null and must have a maximum length of 300 characters");
            RuleFor(x => x.Confirm).Must(x => x != null && x.Text.Length <= 30).WithMessage("Must not be null and must have a maximum length of 30 characters");
            RuleFor(x => x.Deny).Must(x => x != null && x.Text.Length <= 30).WithMessage("Must not be null and must have a maximum length of 30 characters");
        }
    }
}