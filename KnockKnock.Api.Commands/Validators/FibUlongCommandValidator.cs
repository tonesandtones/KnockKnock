namespace KnockKnockApi.Validators
{
#if !SUPPORTS_BIGINTEGER
    using FluentValidation;
    using KnockKnockApi.Commands;
    
    public class FibUlongCommandValidator : AbstractValidator<FibUlongCommand>
    {
        public FibUlongCommandValidator()
        {
            RuleFor(x => x.N).InclusiveBetween(1, 93);
        }
    }
#endif
}