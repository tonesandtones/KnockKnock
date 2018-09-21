using System.Collections.Generic;
using KnockKnockApi.Commands;
using KnockKnockApi.Validators;
using Shouldly;
using Xunit;

namespace KnockKnock.Api.Commands.Tests
{
    public class ReverseWordsValidatorTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ReverseWordsValidation(string input, bool expectedResult)
        {
            var validator = new ReverseWordsCommandValidator();
            var result = validator.Validate(new ReverseWordsCommand() {Input = input});
            result.IsValid.ShouldBe(expectedResult);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {null, false},
                new object[] {"", true},
                new object[] {" ", true},
                new object[] {"a", true},
                new object[] {@"¯\_(ツ)_/¯", true},
                new object[] {@"this is a very long line that should not be considered valid even though it is 
perfectly valid but just too long so we arbitrarily reject it because it is too long and we should protect 
ourselves from trying to process to much data at once and there are no specs to say otherwise", 
                    false},
            };
    }
}