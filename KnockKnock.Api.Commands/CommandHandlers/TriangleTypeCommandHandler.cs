using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using KnockKnockApi.Commands;

namespace KnockKnockApi.CommandHandlers
{
    public class TriangleTypeCommandHandler : ICommandHandler<TriangleTypeCommand, string>
    {
        public const string Error = "Error";
        public const string Isosceles = "Isosceles";
        public const string Scalene = "Scalene";
        public const string Equilateral = "Equilateral";


        public async Task<string> ExecuteAsync(TriangleTypeCommand command, string previousResult)
        {
            var sides = new List<int> {command.A, command.B, command.C};
            sides.Sort();

            var a = sides[0]; //shortest
            var b = sides[1]; //  middle-est
            var c = sides[2]; //longest

            if (a <= 0 || b <= 0 || c <= 0)
            {
                //one or more sides are zero or negative
                return Error;
            }

            var a_big = new BigInteger(a);
            var b_big = new BigInteger(b);
            var c_big = new BigInteger(c);

            if (c_big >= (a_big + b_big)) //only need BigInteger here because the + can overflow if args are big enough
            {
                //longest side is equal or longer than the sum of the other two
                return Error;
            }

            if (a == b && b == c)
            {
                //all sides the same
                return Equilateral;
            }

            if (a == b || b == c)
            {
                //2 sides the same, 1 not
                return Isosceles;
            }

            //any other case
            return Scalene;
        }
    }
}