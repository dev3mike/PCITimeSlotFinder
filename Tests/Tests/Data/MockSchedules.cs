using Domain.Models;
using Newtonsoft.Json;

namespace Tests.Data;

public static class MockSchedules
{
    public static readonly IEnumerable<Schedule> MockSchedulesResponse = new List<Schedule>
    {
        new()
        {
            ContractTimeMinutes = 480,
            Date = DateTime.Parse("2015-12-14 08:00:00"),
            IsFullDayAbsence = false,
            Name = "Sample Name",
            PersonId = "1111",
            Projection =
            [
                new Projection
                {
                    Color = "SAMPLE_COLOR",
                    Description = "short break",
                    Start = DateTime.Parse("2015-12-14 08:00:00"),
                    End = DateTime.Parse("2015-12-14 17:00:00")
                }
            ]
        },
        new()
        {
            ContractTimeMinutes = 480,
            Date = DateTime.Parse("2015-12-14 08:00:00"),
            IsFullDayAbsence = false,
            Name = "Sample Name2",
            PersonId = "1112",
            Projection =
            [
                new Projection
                {
                    Color = "SAMPLE_COLOR",
                    Description = "short break",
                    Start = DateTime.Parse("2015-12-14 09:00:00"),
                    End = DateTime.Parse("2015-12-14 17:00:00")
                }
            ]
        }
    };
}