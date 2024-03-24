using Domain.Models;

namespace Domain.Contracts;

public interface ISchedulesRepository
{
    /// <summary>
    /// Gets a list of all schedules.
    /// </summary>
    Task<IEnumerable<Schedule>> GetAllSchedules();
}