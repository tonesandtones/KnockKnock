using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace KnockKnockApi.Commands
{
    public interface IDictionaryCommandExtension
    {
        IDictionary<string, string> Properties { get; }
        string CommandName { get; }
    }
}