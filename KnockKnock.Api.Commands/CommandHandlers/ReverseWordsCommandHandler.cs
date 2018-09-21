using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using KnockKnockApi.Commands;

namespace KnockKnockApi.CommandHandlers
{
    public class ReverseWordsCommandHandler : ICommandHandler<ReverseWordsCommand, string>
    {
        public async Task<string> ExecuteAsync(ReverseWordsCommand command, string previousResult)
        {
            var input = command.Input;

            //including a capturing group in the split regex causes the Regex#Split()
            //operation to keep the captured group in the output array
            var regex = new Regex(@"(\s+)");
            var parts = regex.Split(input);
            for (var i = 0; i < parts.Length; i++)
            {
                var s = parts[i];
                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                {
                    //do nothing with it
                }
                else
                {
                    parts[i] = new string(s.Reverse().ToArray());
                }
            }

            return string.Join(string.Empty, parts);
        }
    }
}