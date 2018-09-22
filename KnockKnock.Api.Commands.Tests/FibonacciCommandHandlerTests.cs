namespace KnockKnock.Api.Commands.Tests
{
#if (SUPPORTS_BIGINTEGER)
    using System.Collections.Generic;
    using System.Numerics;
    using KnockKnockApi.CommandHandlers;
    using KnockKnockApi.Commands;
    using Shouldly;
    using Xunit;
    
    public class FibonacciCommandHandlerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FibonacciValidation(int n, BigInteger expectedResult)
        {
            var handler= new FibonacciCommandHandler();
            var result = handler.ExecuteAsync(new FibonacciCommand {N = n}, 0).GetAwaiter().GetResult();
            result.ShouldBe(expectedResult);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {1, new BigInteger(1)},
                new object[] {2, new BigInteger(1)},
                new object[] {3, new BigInteger(2)},
                new object[] {4, new BigInteger(3)},
                new object[] {5, new BigInteger(5)},
                new object[] {6, new BigInteger(8)},
                new object[] {10, new BigInteger(55)},
                new object[] {20, new BigInteger(6765)},
                new object[] {38, new BigInteger(39088169)},
                new object[] {100, BigInteger.Parse("354224848179261915075")},
                new object[] {1000, BigInteger.Parse("43466557686937456435688527675040625802564660517371780402481729089536555417949051890403879840079255169295922593080322634775209689623239873322471161642996440906533187938298969649928516003704476137795166849228875")},
            };
    }
#endif
}