using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackSelectMenuExternalSourceBlockElementValidator : AbstractValidator<SlackSelectMenuExternalSourceBlockElement>
    {
        public SlackSelectMenuExternalSourceBlockElementValidator()
        {
            Include(new SlackMenuBlockElementValidatorBase());
        }
    }
}