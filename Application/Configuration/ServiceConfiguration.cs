using Application.Services;
using Domain.Contracts;
using Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ITimeSlotFinderService, TimeSlotFinderService>();
        services.AddInfrastructureServices();
        return services;
    }
}