using Domain.Contracts;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

    public static class ServiceConfiguration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulesRepository, SchedulesRepository>();
            services.AddSingleton<IHttpService, HttpService>();
        }
    }

