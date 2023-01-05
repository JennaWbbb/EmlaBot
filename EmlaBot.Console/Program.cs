using EmlaBot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmlaBot.Console
{
    internal static class Program
    {
        /// <summary>
        /// Set up the dependency injection, and call the real entry point
        /// </summary>
        private static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
               .AddLogging(l => l.AddConsole())
               .Configure<LoggerFilterOptions>(c => c.MinLevel = LogLevel.Trace)
               .AddSingleton<ConsoleMenu>()
               .AddEmlaBot()
               .BuildServiceProvider();

            var service = serviceProvider.GetService<ConsoleMenu>();

            if (service == null)
            {
                return;
            }

            await service.Process();
        }
    }
}