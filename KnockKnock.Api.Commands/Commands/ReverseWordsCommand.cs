using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace KnockKnockApi.Commands
{
    public class ReverseWordsCommand : ICommand<string>, IDictionaryCommandExtension
    {
        public string Sentence { get; set; }

        public string CommandName => "ReverseWordsCommand";
        public IDictionary<string, string> Properties => new Dictionary<string, string> {{nameof(Sentence), Sentence}};
    }
}