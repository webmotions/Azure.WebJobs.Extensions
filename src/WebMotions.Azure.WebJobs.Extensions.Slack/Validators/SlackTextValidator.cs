using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators
{
    public class SlackTextValidator : AbstractValidator<SlackText>
    {
        public SlackTextValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}