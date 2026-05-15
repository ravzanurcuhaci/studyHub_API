using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyHub_API.DTOs.StudySessions;
using StudyHub_API.Interfaces;
using System.Security.Claims;

namespace StudyHub_API.Controllers;

[Authorize]
[ApiController]
[Route("api/study-sessions")]
public class StudySessionsController : ControllerBase
{
    private readonly IStudySessionService _sessionService;

    public StudySessionsController(IStudySessionService sessionService)
    {
        _sessionService = sessionService;
    }

    private int GetUserId()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdString!);
    }

    [HttpGet]
    public async Task<IActionResult> GetSessions()
    {
        int userId = GetUserId();

        var sessions = await _sessionService.GetSessionsAsync(userId);

        return Ok(sessions);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession(CreateStudySessionRequestDto request)
    {
        int userId = GetUserId();

        var session = await _sessionService.CreateSessionAsync(request, userId);

        return Ok(session);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        int userId = GetUserId();

        var deleted = await _sessionService.DeleteSessionAsync(id, userId);

        if (!deleted)
            return NotFound();

        return Ok("Çalışma oturumu silindi");
    }
}
