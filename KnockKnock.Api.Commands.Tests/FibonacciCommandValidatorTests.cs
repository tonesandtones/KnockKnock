using System.Collections.Generic;
using KnockKnockApi.Commands;
using KnockKnockApi.Validators;
using Shouldly;
using Xunit;

namespace KnockKnock.Api.Commands.Tests
{
    public class FibonacciCommandValidatorTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FibonacciValidation(int n, bool expectedResult)
        {
            var validator = new FibonacciCommandValidator();
            var result = validator.Validate(new FibonacciCommand {N = n});
            result.IsValid.ShouldBe(expectedResult);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {-1, false},
                new object[] {0, false},
                new object[] {1, true},
                new object[] {2, true},
                new object[] {50, true},
                new object[] {1000, true},
                new object[] {1001, false}, //arbitrary cutoff at 1000
                new object[] {9999, false},
                new object[] {int.MaxValue, false},
                new object[] {int.MinValue, false},
            };
    }
}