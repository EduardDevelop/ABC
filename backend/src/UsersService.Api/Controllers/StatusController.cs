using Microsoft.AspNetCore.Mvc;
using UsersService.Api.Models;

namespace UsersService.Api.Controllers;

[ApiController]
[Route("status")]
public class StatusController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public StatusController(IWebHostEnvironment environment, IConfiguration configuration)
    {
        _environment = environment;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetStatus()
    {
        var response = new ApiStatusResponse
        {
            Service = _configuration["ServiceInfo:Name"] ?? "UsersService",
            Version = _configuration["ServiceInfo:Version"] ?? "1.0.0",
            Environment = _environment.EnvironmentName,
            Timestamp = DateTime.UtcNow
        };

        return Ok(response);
    }
}