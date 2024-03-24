using System.Text;
using Domain.Models;

namespace Application.Helpers;

public static class TimeSlotHelpers
{
    public static IEnumerable<string> GenerateTimeKeys(DateTime startTime, DateTime endTime)
    {
        const int intervalMinutes = 15;
        var totalIntervals = (int)((endTime - startTime).TotalMinutes / intervalMinutes);

        for (var i = 0; i < totalIntervals; i++)
        {
            var intervalStart = startTime.AddMinutes(i * intervalMinutes);
            var intervalEnd = intervalStart.AddMinutes(intervalMinutes);
            var timeKey = $"{intervalStart:HHmm}-{intervalEnd:HHmm}";
            yield return timeKey;
        }
    }
    
    public static IEnumerable<string> GetAvailableTimeSlots(IReadOnlyDictionary<string, int> notAvailableTimeSlotsList, int minNumberOfPersonnel, int numberOfTotalPersonnel, DateTime workingDayStartTime, DateTime workingDayEndTime)
    {
        var allDayTimeSlots = TimeSlotHelpers.GenerateTimeKeys(workingDayStartTime, workingDayEndTime).ToList();
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

    public static  Dictionary<string, int> GetNotAvailableTimeKeys(Schedule[] allSchedules)
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

                var timeKeys = TimeSlotHelpers.GenerateTimeKeys(projection.Start, projection.End);

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