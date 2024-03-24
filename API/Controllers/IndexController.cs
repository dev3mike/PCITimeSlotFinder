
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("/")]
[ApiController]
public class IndexController : Controller
{
    [HttpGet]
    public async Task<object> GetTodoItems()
    {
        return new {messsage= "Welcome to the API"};
    }

}