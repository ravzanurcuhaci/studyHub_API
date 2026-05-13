using Microsoft.AspNetCore.Mvc;
using StudyHub_API.DTOs.Auth;
using StudyHub_API.Interfaces;

namespace StudyHub_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        var result = await _authService.RegisterAsync(request);

        if (result == null)
            return BadRequest("Bu email zaten kayıtlı");

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);

        if (result == null)
            return Unauthorized("Email veya şifre hatalı");

        return Ok(result);
    }
}