using System;

namespace KnockKnockApi.CommandHandlers
{
#if !SUPPORTS_BIGINTEGER
    using System.Threading.Tasks;
    using AzureFromTheTrenches.Commanding.Abstractions;
    using KnockKnockApi.Commands;

    public class FibLongCommandHandler : ICommandHandler<FibLongCommand, long>
    {
        public async Task<long> ExecuteAsync(FibLongCommand command, long previousResult)
        {
            var n = command.N;

            if (n < 0)
            {
                //see wikipedia for generalisation into the negative numbers
                return (long)Math.Round(Math.Pow(-1, n+1)) * await (ExecuteAsync(new FibLongCommand {N = Math.Abs(n)}, 0));
            }
            
            switch (n)
            {
                case 0: return 0;
                case 1: return 1;
                case 2: return 1;
                default:
                {
                    long n_1 = 1; //f(n-1)
                    long result = 2; //f(n)
                    for (var i = 3; i < n; i++)
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