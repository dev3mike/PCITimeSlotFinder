using Domain.Models;
using Infrastructure.Dtos;

namespace Infrastructure.Extensions;

internal static class ScheduleMapper
{
    public static IEnumerable<Schedule> GetMappedScheduleList(this SchedulesResponseDto responseDto)
    {
        return responseDto.ScheduleResult.Schedules.Select(item =>
            new Schedule
            {
                ContractTimeMinutes = item.ContractTimeMinutes,
                Date = item.Date,
                IsFullDayAbsence = item.IsFullDayAbsence,
                Name = item.Name,
                PersonId = item.PersonId,
                Projection = item.Projection.Select(projection => new Projection
                {
                    Color = projection.Color,
                    Description = projection.Description,
                    Start = projection.Start,
                    End = projection.Start.Add(TimeSpan.FromMinutes(projection.Minutes)),
                }).ToList()
            });
    }
}