using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Contracts;
using Infrastructure.Dtos;
using Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal class SchedulesRepository : ISchedulesRepository
{
    private readonly IHttpService _httpService;
    private readonly ILogger<SchedulesRepository> _logger;
    private readonly string _apiEndpoint = "https://rndfiles.blob.core.windows.net/pizzacabininc/2015-12-14.json";

    public SchedulesRepository(IHttpService httpService, ILogger<SchedulesRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(httpService);
        ArgumentNullException.ThrowIfNull(logger);

        _httpService = httpService;
        _logger = logger;
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedules()
    {
        var allSchedules = await _httpService.Get<SchedulesResponseDto>(_apiEndpoint);

        if (allSchedules is null)
        {
            _logger.LogError("Couldn't fetch list of all schedules");
            throw new FailedToFetchDataException("Failed to fetch all schedules");
        }

        return allSchedules.GetMappedScheduleList();
    }
}