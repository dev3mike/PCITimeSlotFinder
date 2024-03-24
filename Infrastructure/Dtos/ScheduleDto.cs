using Newtonsoft.Json;

namespace Infrastructure.Dtos;

internal class ScheduleDto
{
    public int ContractTimeMinutes { get; set; }
    public DateTime Date { get; set; }
    public bool IsFullDayAbsence { get; set; }
    public string Name { get; set; }
    public string PersonId { get; set; }
    public List<ProjectionDto> Projection { get; set; }
}

