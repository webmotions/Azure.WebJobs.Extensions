using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.Objects
{
    public class SlackFilterValidator : AbstractValidator<SlackFilter>
    {
        public SlackFilterValidator()
        {
            RuleFor(x => x.Include).NotEmpty();
        }
    }
}