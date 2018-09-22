namespace KnockKnock.Api.Commands.Tests
{
#if !SUPPORTS_BIGINTEGER
    using System.Collections.Generic;
    using KnockKnockApi.Commands;
    using KnockKnockApi.Validators;
    using Shouldly;
    using Xunit;
    
    public class FibUlongCommandValidatorTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FibUlongValidation(int n, bool expectedResult)
        {
            var validator = new FibUlongCommandValidator();
            var result = validator.Validate(new FibUlongCommand {N = n});
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
                new object[] {93, true},
                new object[] {94, false}, //ulong tops out at f(93). f(94) will overflow
                new object[] {9999, false},
                new object[] {int.MaxValue, false},
                new object[] {int.MinValue, false},
            };
    }
#endif
}