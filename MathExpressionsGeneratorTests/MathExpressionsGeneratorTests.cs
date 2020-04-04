using MathExpressions;
using NUnit.Framework;
using System.Linq;

namespace MathExpressionsGeneratorTests
{
    public class MathExpressionsGeneratorTests
    {
        private MathExpressionsGenerator mathExpressionsGenerator;

        [SetUp]
        public void Setup()
        {
            mathExpressionsGenerator = new MathExpressionsGenerator();
        }

        [TestCase(1, 0, "Solve 1 = 1 problem by adding 0 + signs.")]
        [TestCase(2, 3, "Wrong")]
        [TestCase(5, 5, "Solve 1 2 3 4 5 = 5 4 3 2 1 problem by adding 5 + signs.")]
        public void TestProblemStatement(int maxNumber, int signCount, string expectedResult)
        {
            var problemStatement = mathExpressionsGenerator.BuildProblemStatement(maxNumber, signCount);

            Assert.That(problemStatement, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 0, new[] { "1=1" })]
        [TestCase(1, 1, new string[] { })]
        [TestCase(4, 3, new[] { "12+34=43+2+1" })]
        [TestCase(5, 5, new[] { "12+34+5=5+43+2+1", "12+3+45=54+3+2+1" })]
        public void TestProblemSolution(int maxNumber, int signCount, string[] expectedSolutions)
        {
            var solutions = mathExpressionsGenerator.BuildSolutions(maxNumber, signCount).ToArray();

            Assert.That(solutions.Length, Is.EqualTo(expectedSolutions.Length));

            for(int i = 0; i < solutions.Length; ++i)
            {
                Assert.That(solutions[i], Is.EqualTo(expectedSolutions[i]));
            }
        }
    }
}