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

    public class FibLongCommandHandlerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FibUlongValidation(int n, long expectedResult)
        {
            var handler = new FibLongCommandHandler();
            var result = handler.ExecuteAsync(new FibLongCommand {N = n}, 0).GetAwaiter().GetResult();
            result.ShouldBe(expectedResult);
        }

        [Fact]
        public void FibLongOverflowsSafely()
        {
            const int shouldCauseNumericOverflow = 93;
            var handler = new FibLongCommandHandler();
            Should.Throw<OverflowException>(() =>
                handler.ExecuteAsync(new FibLongCommand {N = shouldCauseNumericOverflow}, 0).GetAwaiter().GetResult());
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {0, (long) 0},
                new object[] {1, (long) 1},
                new object[] {2, (long) 1},
                new object[] {3, (long) 2},
                new object[] {4, (long) 3},
                new object[] {5, (long) 5},
                new object[] {6, (long) 8},
                new object[] {10, (long) 55},
                new object[] {20, (long) 6765},
                new object[] {38, (long) 39088169},
                new object[] {90, (long) 2880067194370816120},
                new object[] {92, (long) 7540113804746346429},
                new object[] {-1, (long) 1},
                new object[] {-2, (long) -1},
                new object[] {-3, (long) 2},
                new object[] {-4, (long) -3},
                new object[] {-5, (long) 5},
                new object[] {-6, (long) -8},
                new object[] {-10, (long) -55},
            };
    }
#endif
}