namespace KnockKnockApi.CommandHandlers
{
#if !SUPPORTS_BIGINTEGER
    using System.Threading.Tasks;
    using AzureFromTheTrenches.Commanding.Abstractions;
    using KnockKnockApi.Commands;

    public class FibUlongCommandHandler : ICommandHandler<FibUlongCommand, ulong>
    {
        public async Task<ulong> ExecuteAsync(FibUlongCommand command, ulong previousResult)
        {
            var n = command.N;
            switch (n)
            {
                case 1: return 1;
                case 2: return 1;
                default:
                {
                    ulong n_1 = 1; //f(n-1)
                    ulong result = 2; //f(n)
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