namespace KnockKnockApi.CommandHandlers
{
#if (SUPPORTS_BIGINTEGER)
    using System.Numerics;
    using System.Threading.Tasks;
    using AzureFromTheTrenches.Commanding.Abstractions;
    using KnockKnockApi.Commands;

    public class FibonacciCommandHandler : ICommandHandler<FibonacciCommand, BigInteger>
    {
        private async Task<BigInteger> FibSlowRecusion(int n)
        {
            switch (n)
            {
                case 1: return 1;
                case 2: return 1;
                default:
                    //2 x tail recursion... disgusting, and really slow beyond about N = 15.
                    //Also StackOverflowExceptions are in your future...
                    return await ExecuteAsync(new FibonacciCommand {N = n - 1}, 0) +
                           await ExecuteAsync(new FibonacciCommand {N = n - 2}, 0);
            }
        }

        public async Task<BigInteger> ExecuteAsync(FibonacciCommand command, BigInteger previousResult)
        {
            var n = command.N;
            return FibFastLoop(n);

            //yeah.... don't use this one, but it's implemented as a reference.
//            return await FibSlowRecusion(n);
        }

        private static BigInteger FibFastLoop(int n)
        {
            switch (n)
            {
                case 1: return new BigInteger(1);
                case 2: return new BigInteger(1);
                default:
                {
                    var n_1 = new BigInteger(1); //f(n-1)
                    var result = new BigInteger(2); //f(n)
                    for (int i = 3; i < n; i++)
                    {
                        checked
                        {
                            var tmp = result + n_1;
                            n_1 = result;
                            result = tmp;
                        }
                    }

                    return result;
                }
            }
        }
    }

#endif
}