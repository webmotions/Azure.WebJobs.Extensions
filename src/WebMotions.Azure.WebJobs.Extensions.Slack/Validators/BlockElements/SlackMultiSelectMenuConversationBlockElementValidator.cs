using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackMultiSelectMenuConversationBlockElementValidator : AbstractValidator<SlackMultiSelectMenuConversationBlockElement>
    {
        public SlackMultiSelectMenuConversationBlockElementValidator()
        {
            Include(new SlackMenuBlockElementValidatorBase());
            RuleFor(x => x.MaximumSelectedItems).Must(x => x.Value >= 1).When(x => x.MaximumSelectedItems.HasValue);
        }
    }
}