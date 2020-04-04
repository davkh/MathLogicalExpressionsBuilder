using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MathExpressionsGeneratorTests")]
namespace MathExpressions
{
    internal class MathExpressionsGenerator : IMathExpressionsGenerator
    {
        public string BuildProblemStatement(int maxNumber, int signCount)
        {
            if(signCount > 2 * (maxNumber - 1))
            {
                return "Wrong";
            }

            var numberRange = Enumerable.Range(1, maxNumber);

            var problem = string.Concat(string.Join(' ', numberRange), " = ", string.Join(' ', numberRange.Reverse()));

            return $"Solve {problem} problem by adding {signCount} + signs.";
        }

        public IEnumerable<string> BuildSolutions(int maxNumber, int signCount)
        {
            return Generate(maxNumber, signCount)
                .Where(pair => Evaluate(pair.left) == Evaluate(pair.right))
                .Select(pair => pair.left + "=" + pair.right);
        }

        private bool HasExactSignCount(int number, int signCount)
        {
            return (number == 0 && signCount == 0) || (number > 0 && HasExactSignCount(number >> 1, signCount - number % 2));
        }

        private bool GetBit(int b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        private IEnumerable<(string left, string right)> Generate(int maxnumber, int signCount)
        {
            return Enumerable.Range(0, 1 << 2 * (maxnumber - 1)).Where(j => HasExactSignCount(j, signCount)).Select(j => {
                return (
                    string.Concat(Enumerable.Range(1, maxnumber).Select(i => i < maxnumber && GetBit(j, i - 1) ? i + "+" : i.ToString())),
                    string.Concat(Enumerable.Range(1, maxnumber).Reverse().Select(i => i > 1 && GetBit(j, 2 * (maxnumber - 1) - i + 1) ? i + "+" : i.ToString()))
                );
            });
        }

        private int Evaluate(string expression)
        {
            return Convert.ToInt32(new DataTable().Compute(expression, null));
        }
    }
}
