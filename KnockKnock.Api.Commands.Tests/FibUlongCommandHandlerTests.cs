using System;

namespace KnockKnock.Api.Commands.Tests
{
#if !SUPPORTS_BIGINTEGER
    using System.Collections.Generic;
    using System.Numerics;
    using KnockKnockApi.CommandHandlers;
    using KnockKnockApi.Commands;
    using Shouldly;
    using Xunit;

    public class FibUlongCommandHandlerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FibUlongValidation(int n, ulong expectedResult)
        {
            var handler = new FibUlongCommandHandler();
            var result = handler.ExecuteAsync(new FibUlongCommand {N = n}, 0).GetAwaiter().GetResult();
            result.ShouldBe(expectedResult);
        }

        [Fact]
        public void FibUlongOverflowsSafely()
        {
            const int shouldCauseNumericOverflow = 94;
            var handler = new FibUlongCommandHandler();
            Should.Throw<OverflowException>(() =>
                handler.ExecuteAsync(new FibUlongCommand {N = shouldCauseNumericOverflow}, 0).GetAwaiter().GetResult());
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {1, (ulong) 1},
                new object[] {2, (ulong) 1},
                new object[] {3, (ulong) 2},
                new object[] {4, (ulong) 3},
                new object[] {5, (ulong) 5},
                new object[] {6, (ulong) 8},
                new object[] {10, (ulong) 55},
                new object[] {20, (ulong) 6765},
                new object[] {38, (ulong) 39088169},
                new object[] {90, (ulong) 2880067194370816120},
                new object[] {93, (ulong) 12200160415121876738}, //this is the biggest we can go with a ulong
            };
    }
#endif
}