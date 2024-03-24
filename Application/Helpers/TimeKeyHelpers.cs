using System.Text;

namespace Application.Helpers;

public static class TimeKeyHelpers
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
}