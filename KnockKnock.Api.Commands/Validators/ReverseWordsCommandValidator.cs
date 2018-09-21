using FluentValidation;
using KnockKnockApi.Commands;

namespace KnockKnockApi.Validators
{
    public class ReverseWordsCommandValidator : AbstractValidator<ReverseWordsCommand>
    {
        public ReverseWordsCommandValidator()
        {
            RuleFor(x => x.Input).NotNull().MaximumLength(256);
        }
    }
}