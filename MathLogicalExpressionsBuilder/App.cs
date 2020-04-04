using MathExpressions;
using MathLogicalExpressionsBuilder.UserInterface;

namespace MathLogicalExpressionsBuilder
{
    public class App
    {
        private readonly IUserInterface userInterface;
        private readonly IMathExpressionsGenerator mathExpressionsGenerator;

        public App(
            IUserInterface userInterface,
            IMathExpressionsGenerator mathExpressionsGenerator
            )
        {
            this.userInterface = userInterface;
            this.mathExpressionsGenerator = mathExpressionsGenerator;
        }

        public void Run()
        {
            userInterface.PrintValue("Please type following two parameters to generate the logical puzzle");

            var maxNumber = userInterface.ReadValue<int>("maxNumber");
            var signCount = userInterface.ReadValue<int>("signCount");

            userInterface.PrintValue("**************");
            userInterface.PrintValue("Statement");
            userInterface.PrintValue("--------------");
            userInterface.PrintValue(mathExpressionsGenerator.BuildProblemStatement(maxNumber, signCount));
            userInterface.PrintValue("--------------");
            userInterface.PrintValue("Solutions");
            userInterface.PrintValue("--------------");
            foreach (var solution in mathExpressionsGenerator.BuildSolutions(maxNumber, signCount))
            {
                userInterface.PrintValue(solution);
            }
            userInterface.PrintValue("**************");
        }
    }
}
