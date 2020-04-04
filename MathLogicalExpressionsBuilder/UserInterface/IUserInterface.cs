using System;
using System.Collections.Generic;
using System.Text;

namespace MathLogicalExpressionsBuilder.UserInterface
{
    public interface IUserInterface
    {
        T ReadValue<T>();
        void PrintValue<T>(T value);
        T ReadValue<T>(string variableName);
    }
}
