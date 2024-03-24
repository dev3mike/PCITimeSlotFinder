using Application.Helpers;
using Domain.Contracts;
using Domain.Models;

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
        
        var notAvailableTimeSlotsList = GetNotAvailableTimeKeys(allSchedules);
        var numberOfTotalPersonnel = allSchedules.Length;
        
        var workingDayStartTime = DateTime.Parse("2015-12-14 08:00:00");
        var workingDayEndTime = DateTime.Parse("2015-12-14 18:00:00");
        
        var availableTimeSlots = GetAvailableTimeSlots(notAvailableTimeSlotsList, minNumberOfPersonnel, numberOfTotalPersonnel, workingDayStartTime, workingDayEndTime);

        return availableTimeSlots;
    }

    private IEnumerable<string> GetAvailableTimeSlots(IReadOnlyDictionary<string, int> notAvailableTimeSlotsList, int minNumberOfPersonnel, int numberOfTotalPersonnel, DateTime workingDayStartTime, DateTime workingDayEndTime)
    {
        var allDayTimeSlots = TimeKeyHelpers.GenerateTimeKeys(workingDayStartTime, workingDayEndTime).ToList();
        var availableTimeSlotsList = new List<string>();

        for (var i = 0; i < allDayTimeSlots.Count; i++)
        {
            var timeKey = allDayTimeSlots[i];
            notAvailableTimeSlotsList.TryGetValue(timeKey, out var numberOfNotAvailablePersonnel);
            var availablePeople = numberOfTotalPersonnel - numberOfNotAvailablePersonnel;
            if(availablePeople >= minNumberOfPersonnel)
                availableTimeSlotsList.Add(timeKey);
        }

        return availableTimeSlotsList;
    }

    private Dictionary<string, int> GetNotAvailableTimeKeys(Schedule[] allSchedules)
    {
        var notAvailableTimesList = new Dictionary<string, int>();
        
        for (var i = 0; i < allSchedules.Length; i++)
        {
            var schedule = allSchedules[i];
            
            if (schedule.IsFullDayAbsence) continue;
            var projections = schedule.Projection.ToArray();
            for (var j = 0; j < projections.Length; j++)
            {
                var projection = projections[j];
                if(projection.Description.ToLower() != "lunch" && projection.Description.ToLower() !="short break") continue;

                var timeKeys = TimeKeyHelpers.GenerateTimeKeys(projection.Start, projection.End);

                foreach (var timeKey in timeKeys)
                {
                    notAvailableTimesList.TryGetValue(timeKey, out var numberOfNotAvailablePersonnel);
                    notAvailableTimesList[timeKey] = numberOfNotAvailablePersonnel + 1;
                }
            }
        }

        return notAvailableTimesList;
    }
}