using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace KnockKnockApi.Commands
{
    public class TriangleTypeCommand : ICommand<string>, IDictionaryCommandExtension
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public string CommandName => "TriangleTypeCommand";
        public IDictionary<string, string> Properties => new Dictionary<string, string>{{nameof(A), $"{A}"}, {nameof(B), $"{B}"}, {nameof(C), $"{C}"}};
    }
}