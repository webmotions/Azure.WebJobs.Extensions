using FluentValidation;
using FluentValidation.Results;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.BlockElements;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators.BlockElements
{
    public class SlackMultiSelectStaticMenuBlockElementValidator : AbstractValidator<SlackMultiSelectMenuStaticBlockElement>
    {
        public SlackMultiSelectStaticMenuBlockElementValidator()
        {
            Include(new SlackMenuBlockElementValidatorBase());
            RuleFor(x => x.Options).Must(x => x.Count <= 100).When(x => x.Options != null);
            RuleFor(x => x.OptionGroups).Must(x => x.Count <= 100).When(x => x.OptionGroups != null);
            RuleFor(x => x.MaximumSelectedItems).Must(x => x > 1).When(x => x.MaximumSelectedItems.HasValue);
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Options.Count > 0 && x.OptionGroups.Count > 0)
                {
                    context.AddFailure(new ValidationFailure("SlackMultiSelectStaticMenuBlockElement.Options", "The Options and OptionGroups cannot both contain elements"));
                    context.AddFailure(new ValidationFailure("SlackMultiSelectStaticMenuBlockElement.OptionGroups", "The Options and OptionGroups cannot both contain elements"));
                }
            });
        }
    }
}