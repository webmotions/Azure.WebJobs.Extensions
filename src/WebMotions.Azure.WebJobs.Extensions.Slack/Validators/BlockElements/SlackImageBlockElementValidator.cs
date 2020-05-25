using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackImageBlockElementValidator : AbstractValidator<SlackImageBlockElement>
    {
        public SlackImageBlockElementValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.AlternateText).NotEmpty();
        }
    }
}