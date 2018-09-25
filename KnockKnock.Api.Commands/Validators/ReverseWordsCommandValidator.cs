using FluentValidation;
using FluentValidation.Results;
using KnockKnockApi.Commands;
using Microsoft.ApplicationInsights;

namespace KnockKnockApi.Validators
{
    public class ReverseWordsCommandValidator : TelemetrySenderValidator<ReverseWordsCommand>
    {
        public ReverseWordsCommandValidator(TelemetryClient telem = null) : base(telem)
        {
            RuleFor(x => x.Sentence).MaximumLength(5000);
        }
    }
}