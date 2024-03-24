using Application.Helpers;
using Domain.Contracts;
using Domain.Models;
using Newtonsoft.Json;

namespace Application.Services;

public class TimeSlotFinderService : ITimeSlotFinderService
{
    private readonly ISchedulesRepository _schedulesRepository;

    public TimeSlotFinderService(ISchedulesRepository schedulesRepository)
    {
        ArgumentNullException.ThrowIfNull(schedulesRepository);

        _schedulesRepository = schedulesRepository;
    }

    public async Task<IEnumerable<string>> FindTimeSlots(int minNumberOfPersonnel)
    {
        var allSchedules = (await _schedulesRepository.GetAllSchedules()).ToArray();

        var notAvailableTimeSlotsList = TimeSlotHelpers.GetNotAvailableTimeKeys(allSchedules);
        var numberOfTotalPersonnel = allSchedules.Length;
        
        var workingDayStartTime = DateTime.Parse("2015-12-14 08:00:00");
        var workingDayEndTime = DateTime.Parse("2015-12-14 18:00:00");
        
        var availableTimeSlots = TimeSlotHelpers.GetAvailableTimeSlots(notAvailableTimeSlotsList, minNumberOfPersonnel, numberOfTotalPersonnel, workingDayStartTime, workingDayEndTime);

        return availableTimeSlots;
    }

}