using Microsoft.AspNetCore.Mvc;

namespace PaymentsService.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok(new
        {
            status = "Healthy"
        });
    }
}