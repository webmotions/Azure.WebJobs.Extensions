using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackMultiSelectMenuChannelBlockElementValidator : AbstractValidator<SlackMultiSelectMenuChannelBlockElement>
    {
        public SlackMultiSelectMenuChannelBlockElementValidator()
        {
            Include(new SlackMenuBlockElementValidatorBase());
            RuleForEach(x => x.InitialChannels)
                .NotEmpty()
                .Must(x => x.StartsWith("#"))
                .WithMessage("The channel must start with #")
                .When(x => x.InitialChannels.Count > 0);
        }
    }
}