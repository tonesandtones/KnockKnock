namespace KnockKnockApi.Validators
{
#if SUPPORTS_BIGINTEGER
    using FluentValidation;
    using KnockKnockApi.Commands;

    public class FibonacciCommandValidator : AbstractValidator<FibonacciCommand>
    {
        public FibonacciCommandValidator()
        {
            //arbitrary cutoff at 1000, the output starts getting crazy long by n=1000
            //as in, ~210 digits long...
            //n=1000 == 43466557686937456435688527675040625802564660517371780402481729089536555417949051890403879840079255169295922593080322634775209689623239873322471161642996440906533187938298969649928516003704476137795166849228875
            RuleFor(x => x.N).InclusiveBetween(1, 1000);
        }
    }
#endif
}