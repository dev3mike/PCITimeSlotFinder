using Newtonsoft.Json;

namespace Domain.Models;

public class Projection
{
    public string Color { get; set; }
    public string Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
}