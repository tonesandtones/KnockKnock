using System.Collections.Generic;
using KnockKnockApi.CommandHandlers;
using KnockKnockApi.Commands;
using Shouldly;
using Xunit;

namespace KnockKnock.Api.Commands.Tests
{
    public class ReverseWordsCommandHandlerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ReverseWords(string input, string expectedResult)
        {
            var command = new ReverseWordsCommand() {Sentence = input};
            var result = new ReverseWordsCommandHandler().ExecuteAsync(command, null).GetAwaiter().GetResult();
            result.ShouldBe(expectedResult);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {"", ""},
                new object[] {" ", ""},
                new object[] {"  ", ""},
                new object[] {"a", "a"},
                new object[] {" a", " a"},
                new object[] {"a ", "a"},
                new object[] {" a ", " a"},
                new object[] {"  a  ", "  a"},
                new object[] {"ab", "ba"},
                new object[] {"ab cd", "ba dc"},
                new object[] {"ab     cd", "ba     dc"},
                new object[] {"   ab     cd ", "   ba     dc"},
                new object[] {"the quic^ brown fox jump$ over the lazy d0g!", "eht ^ciuq nworb xof $pmuj revo eht yzal !g0d"},
                new object[] {@"¯\_(ツ)_/¯", @"¯/_)ツ(_\¯"},
            };
    }
}