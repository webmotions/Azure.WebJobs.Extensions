using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackSelectMenuConversationBlockElementValidator : AbstractValidator<SlackSelectMenuConversationBlockElement>
    {
        public SlackSelectMenuConversationBlockElementValidator()
        {
            Include(new SlackMenuBlockElementValidatorBase());
        }
    }
}