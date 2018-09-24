namespace KnockKnockApi.Commands
{
#if !SUPPORTS_BIGINTEGER
    using AzureFromTheTrenches.Commanding.Abstractions;
    
    public class FibLongCommand : ICommand<long>
    {
        public int N { get; set; }
    }
#endif
}