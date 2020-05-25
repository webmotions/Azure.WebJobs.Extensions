using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackSelectMenuChannelBlockElementValidator : AbstractValidator<SlackSelectMenuChannelBlockElement>
    {
        public SlackSelectMenuChannelBlockElementValidator()
        {
            Include(new SlackMenuBlockElementValidatorBase());
            RuleFor(x => x.InitialChannel)
                .Must(x => x.StartsWith("#")).WithMessage("The channel must start with #")
                .When(x => !string.IsNullOrWhiteSpace(x.InitialChannel));
        }
    }
}