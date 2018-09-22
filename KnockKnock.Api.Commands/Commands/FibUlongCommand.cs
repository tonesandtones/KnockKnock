namespace KnockKnockApi.Commands
{
#if !SUPPORTS_BIGINTEGER
    using AzureFromTheTrenches.Commanding.Abstractions;
    
    public class FibUlongCommand : ICommand<ulong>
    {
        public int N { get; set; }
    }
#endif
}