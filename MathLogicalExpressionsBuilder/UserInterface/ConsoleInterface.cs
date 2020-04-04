using System;
using System.ComponentModel;

namespace MathLogicalExpressionsBuilder.UserInterface
{
    public class ConsoleInterface : IUserInterface
    {
        public void PrintValue<T>(T value)
        {
            Console.WriteLine(value);
        }

        public T ReadValue<T>()
        {
            if (!TryParse<T>(Console.ReadLine(), out var value))
                return ReadValue<T>();
            return value;
        }

        public T ReadValue<T>(string variableName)
        {
            Console.Write($"{variableName} = ");
            return ReadValue<T>();
        }

        private bool TryParse<T>(string input, out T value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (converter != null && converter.IsValid(input))
            {
                value = (T)converter.ConvertFromString(input);
                return true;
            }
            value = default;
            return false;
        }
    }
}
