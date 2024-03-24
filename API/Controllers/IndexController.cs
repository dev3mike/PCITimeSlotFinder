
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("/")]
[ApiController]
public class IndexController : Controller
{
    private readonly ILogger<IndexController> _logger;

    public IndexController(ILogger<IndexController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<object> GetTodoItems()
    {
        return new {messsage= "Welcome to the api"};
    }

}