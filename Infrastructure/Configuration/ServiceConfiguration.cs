using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

    public static class ServiceConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // services.AddSingleton<IHubService, HubService>();
            return services;
        }
    }

