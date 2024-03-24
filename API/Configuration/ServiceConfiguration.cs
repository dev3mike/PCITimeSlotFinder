using Application.Configuration;

namespace API.Configuration;

    internal static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
            return services;
        }
    }

