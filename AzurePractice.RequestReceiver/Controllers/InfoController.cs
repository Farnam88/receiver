using AzurePractice.RequestReceiver.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzurePractice.RequestReceiver.Controllers;

[ApiController]
[Route("api/info")]
public class InfoController : ControllerBase
{
    private readonly IServiceInfo _serviceInfo;

    public InfoController(IServiceInfo serviceInfo)
    {
        _serviceInfo = serviceInfo;
    }


    [HttpGet]
    public IActionResult GetServiceInfo()
    {
        try
        {
            var result = _serviceInfo.getSetServiceDetail();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}