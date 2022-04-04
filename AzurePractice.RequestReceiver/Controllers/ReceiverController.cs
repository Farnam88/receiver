using AzurePractice.RequestReceiver.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AzurePractice.RequestReceiver.Controllers;

[ApiController]
[Route("api/receiver")]
public class ReceiverController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ReceiverController> _logger;

    public ReceiverController(ILogger<ReceiverController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IActionResult Get()
    {
        var result = Enumerable.Range(3, 8).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        
        Thread.Sleep(500);
        
        return Ok(result);
    }
}