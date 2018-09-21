using AzureFromTheTrenches.Commanding.Abstractions;

namespace KnockKnockApi.Commands
{
    public class ReverseWordsCommand : ICommand<string>
    {
        public string Input { get; set; }
    }
}