using Microsoft.AspNetCore.Mvc;

namespace dotnet_proje.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("StudyHub API çalışıyor");
    }
}