using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyHub_API.DTOs.Todos;
using StudyHub_API.Interfaces;
using System.Security.Claims;

namespace StudyHub_API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    private int GetUserId()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdString!);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        int userId = GetUserId();

        var todos = await _todoService.GetTodosAsync(userId);

        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        int userId = GetUserId();

        var todo = await _todoService.GetTodoByIdAsync(id, userId);

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(CreateTodoRequestDto request)
    {
        int userId = GetUserId();

        var todo = await _todoService.CreateTodoAsync(request, userId);

        return Ok(todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, UpdateTodoRequestDto request)
    {
        int userId = GetUserId();

        var todo = await _todoService.UpdateTodoAsync(id, request, userId);

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        int userId = GetUserId();

        var deleted = await _todoService.DeleteTodoAsync(id, userId);

        if (!deleted)
            return NotFound();

        return Ok("Todo silindi");
    }
}