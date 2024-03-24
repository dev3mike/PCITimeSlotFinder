
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeSlotsController : Controller
{
    private readonly ILogger<TimeSlotsController> _logger;

    public TimeSlotsController(ILogger<TimeSlotsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<object> GetTodoItems()
    {
        
        return new {message= "This is home"};
    }

}