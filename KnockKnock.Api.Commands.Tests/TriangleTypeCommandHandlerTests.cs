using System.Collections.Generic;
using KnockKnockApi.CommandHandlers;
using KnockKnockApi.Commands;
using Shouldly;
using Xunit;

namespace KnockKnock.Api.Commands.Tests
{
    public class TriangleTypeCommandHandlerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void TriangleType(int a, int b, int c, string expectedResult)
        {
            var command = new TriangleTypeCommand {A = a, B = b, C = c};
            var result = new TriangleTypeCommandHandler().ExecuteAsync(command, null).GetAwaiter().GetResult();
            result.ShouldBe(expectedResult);
        }
        
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                //error - invalid ranges
                new object[] {0, 0, 0, TriangleTypeCommandHandler.Error},
                new object[] {-1, 0, 0, TriangleTypeCommandHandler.Error},
                new object[] {1, 1, -1, TriangleTypeCommandHandler.Error},
                new object[] {10, -5, 10, TriangleTypeCommandHandler.Error},
                //error - valid ranges, but invalid lengths
                new object[] {1, 3, 1, TriangleTypeCommandHandler.Error},
                new object[] {2, 1, 1, TriangleTypeCommandHandler.Error},
                //equilateral
                new object[] {1, 1, 1, TriangleTypeCommandHandler.Equilateral},
                new object[] {int.MaxValue, int.MaxValue, int.MaxValue, TriangleTypeCommandHandler.Equilateral},
                //isosceles
                new object[] {2, 1, 2, TriangleTypeCommandHandler.Isosceles},
                new object[] {int.MaxValue, int.MaxValue, 50, TriangleTypeCommandHandler.Isosceles},
                //scalene
                new object[] {3, 4, 5, TriangleTypeCommandHandler.Scalene},
                new object[] {5, 4, 3, TriangleTypeCommandHandler.Scalene},
                new object[] {17, 12, 28, TriangleTypeCommandHandler.Scalene},
                
            };
    }
}