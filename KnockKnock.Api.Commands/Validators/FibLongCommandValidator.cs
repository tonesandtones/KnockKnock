using Microsoft.ApplicationInsights;

namespace KnockKnockApi.Validators
{
#if !SUPPORTS_BIGINTEGER
    using FluentValidation;
    using KnockKnockApi.Commands;
    
    public class FibLongCommandValidator : TelemetrySenderValidator<FibLongCommand>
    {
        public FibLongCommandValidator(TelemetryClient telem = null) : base(telem)
        {
            RuleFor(x => x.N).InclusiveBetween(-92, 92);
        }
    }
#endif
}