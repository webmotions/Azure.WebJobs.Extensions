using FluentValidation;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models;
using WebMotions.Azure.WebJobs.Extensions.Slack.Models.Blocks;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators
{
    public class SlackMessageValidator : AbstractValidator<SlackMessage>
    {
        public SlackMessageValidator()
        {
            RuleFor(x => x.Text).NotEmpty().When(x => x.Blocks.Count == 0);
            RuleFor(x => x.Channel)
                .Must(x => x.StartsWith("#") || x.StartsWith("@"))
                .WithMessage("A channel must start with # for channels or @ for users.")
                .When(x => !string.IsNullOrWhiteSpace(x.Channel));
            RuleFor(x => x.IconEmoji)
                .Must(x => x.StartsWith(":") && x.EndsWith(":"))
                .WithMessage("An icon emoji must start and end with ':'.")
                .When(x => !string.IsNullOrWhiteSpace(x.IconEmoji));
            RuleForEach(x => x.Blocks)
                .Must(x => x is SlackActionBlock ||
                           x is SlackContextBlock ||
                           x is SlackDividerBlock ||
                           x is SlackFileBlock ||
                           x is SlackInputBlock ||
                           x is SlackHeaderBlock ||
                           x is SlackSectionBlock)
                .WithMessage("Requires a block element");
            RuleFor(x => x).Custom((message, context) =>
            {
                if (!string.IsNullOrWhiteSpace(message.IconEmoji) && !string.IsNullOrWhiteSpace(message.IconUrl))
                {
                    context.AddFailure("IconUrl", "Either an Icon emoji or Icon url must be set, but not both.");
                    context.AddFailure("IconEmoji", "Either an Icon emoji or Icon url must be set, but not both.");
                }
            });
        }
    }
}