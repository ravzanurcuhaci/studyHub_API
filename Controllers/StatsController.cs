using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyHub_API.Interfaces;
using System.Security.Claims;

namespace StudyHub_API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private readonly IStatsService _statsService;

    public StatsController(IStatsService statsService)
    {
        _statsService = statsService;
    }

    private int GetUserId()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdString!);
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        int userId = GetUserId();

        var stats = await _statsService.GetSummaryAsync(userId);

        return Ok(stats);
    }

    [HttpGet("weekly")]
    public async Task<IActionResult> GetWeekly()
    {
        int userId = GetUserId();

        var stats = await _statsService.GetWeeklyAsync(userId);

        return Ok(stats);
    }
}
