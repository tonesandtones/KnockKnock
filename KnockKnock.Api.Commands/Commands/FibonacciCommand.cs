namespace KnockKnockApi.Commands
{
#if (SUPPORTS_BIGINTEGER)
    using System.Numerics;
    using AzureFromTheTrenches.Commanding.Abstractions;

    //Requires the use of arbitrary precision arithmetic to get beyond about n = 30
    public class FibonacciCommand : ICommand<BigInteger>
    {
        public int N { get; set; }
    }
#endif
}