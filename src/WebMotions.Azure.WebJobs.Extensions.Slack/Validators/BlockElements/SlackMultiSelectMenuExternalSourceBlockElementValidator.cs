using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Objects;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackMultiSelectMenuExternalSourceBlockElementValidator : AbstractValidator<SlackMultiSelectMenuExternalSourceBlockElement>
    {
        public SlackMultiSelectMenuExternalSourceBlockElementValidator()
        {
            Include(new SlackMenuBlockElementValidatorBase());
            RuleFor(x => x.MaximumSelectedItems).Must(x => x.Value >= 1).When(x => x.MaximumSelectedItems.HasValue);
            RuleForEach(x => x.InitialOptions)
                .Must(x => x is SlackOption || x is SlackOptionGroup)
                .When(x => x.InitialOptions != null);
        }
    }
}