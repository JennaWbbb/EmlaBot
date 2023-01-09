using Microsoft.Extensions.DependencyInjection;

namespace EmlaBot.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmlaBot(this IServiceCollection services)
        {
            return services
                .AddSingleton<IEmlaLockConfig, EmlaLockConfig>()
                .AddSingleton<IEmlaLock, EmlaLock>();
        }
    }
}