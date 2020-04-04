using Microsoft.Extensions.DependencyInjection;

namespace MathExpressions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddMathExpressionsGenerator(this IServiceCollection serviceDescriptors)
            => serviceDescriptors.AddTransient<IMathExpressionsGenerator, MathExpressionsGenerator>();
    }
}
