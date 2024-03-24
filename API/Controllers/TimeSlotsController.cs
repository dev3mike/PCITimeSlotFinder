
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

/// <summary>
/// Handles operations related to fetching available time slots.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TimeSlotsController : Controller
{
    private readonly ILogger<TimeSlotsController> _logger;
    private readonly ITimeSlotFinderService _timeSlotFinderService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeSlotsController"/> class.
    /// </summary>
    /// <param name="logger">The logger for recording logs.</param>
    /// <param name="timeSlotFinderService">The service to find available time slots.</param>
    public TimeSlotsController(ILogger<TimeSlotsController> logger, ITimeSlotFinderService timeSlotFinderService)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(timeSlotFinderService);
        
        _logger = logger;
        _timeSlotFinderService = timeSlotFinderService;
    }
    
    /// <summary>
    /// Gets a list of available time slots based on the number of people.
    /// </summary>
    /// <param name="numberOfPeople">The number of people to find time slots for. Defaults to 3 if not specified.</param>
    /// <returns>A list of strings representing available time slots.</returns>
    /// <response code="200">Returns the available time slots.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="500">If an internal server error occurs.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<string>), Description = "A list of available time slots.")]
    public async Task<IActionResult> GetTimeSlots([FromQuery] int numberOfPeople = 3)
    {
        try
        {
            var allTimeslots = await _timeSlotFinderService.FindTimeSlots(numberOfPeople);
            return Ok(allTimeslots);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Invalid argument for number of people");
            return BadRequest("Invalid request parameters.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching time slots");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching time slots.");
        }
    }

}