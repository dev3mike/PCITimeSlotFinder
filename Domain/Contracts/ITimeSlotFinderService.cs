using Domain.Models;

namespace Domain.Contracts;

public interface ITimeSlotFinderService
{
    /// <summary>
    /// Looks for and returns a list of time slots where a specific number of people are available.
    /// </summary>
    /// <param name="minNumberOfPersonnel"></param>
    /// <returns>A list of time slots that shows when the specified number of people are all free to meet.</returns>
    Task<IEnumerable<string>> FindTimeSlots(int minNumberOfPersonnel);
}