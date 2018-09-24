namespace KnockKnockApi.Validators
{
#if !SUPPORTS_BIGINTEGER
    using FluentValidation;
    using KnockKnockApi.Commands;
    
    public class FibLongCommandValidator : AbstractValidator<FibLongCommand>
    {
        public FibLongCommandValidator()
        {
            RuleFor(x => x.N).InclusiveBetween(-92, 92);
        }
    }
#endif
}