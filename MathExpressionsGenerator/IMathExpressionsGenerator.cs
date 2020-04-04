using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressions
{
    public interface IMathExpressionsGenerator
    {
        string BuildProblemStatement(int maxNumber, int signCount);
        IEnumerable<string> BuildSolutions(int maxNumber, int signCount);
    }
}
