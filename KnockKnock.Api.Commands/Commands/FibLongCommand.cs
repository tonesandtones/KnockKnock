using System.Collections.Generic;

namespace KnockKnockApi.Commands
{
#if !SUPPORTS_BIGINTEGER
    using AzureFromTheTrenches.Commanding.Abstractions;

    public class FibLongCommand : ICommand<long>, IDictionaryCommandExtension
    {
        public int N { get; set; }

        public string CommandName => "FibLongCommand";

        public IDictionary<string, string> Properties => new Dictionary<string, string> {{nameof(N), $"{N}"}};
    }
#endif
}