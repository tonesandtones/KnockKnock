using AzureFromTheTrenches.Commanding.Abstractions;

namespace KnockKnockApi.Commands
{
    public class TriangleTypeCommand : ICommand<string>
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
}