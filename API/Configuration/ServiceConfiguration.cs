using Application.Configuration;

namespace API.Configuration;

    internal static class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddHttpClient();
        }
    }

