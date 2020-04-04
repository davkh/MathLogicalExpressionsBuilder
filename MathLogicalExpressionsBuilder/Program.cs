using MathExpressions;
using MathLogicalExpressionsBuilder.UserInterface;
using Microsoft.Extensions.DependencyInjection;

namespace MathLogicalExpressionsBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            // calls the Run method in App, which is replacing Main
            serviceProvider.GetService<App>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddMathExpressionsGenerator();
            services.AddTransient<IUserInterface, ConsoleInterface>();

            // required to run the application
            services.AddTransient<App>();

            return services;
        }
    }
}
