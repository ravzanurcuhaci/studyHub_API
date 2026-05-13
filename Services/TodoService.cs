using StudyHub_API.DTOs.Todos;
using StudyHub_API.Interfaces;
using StudyHub_API.Models;

namespace StudyHub_API.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<TodoResponseDto>> GetTodosAsync(int userId)
    {
        var todos = await _todoRepository.GetByUserIdAsync(userId);

        return todos.Select(todo => new TodoResponseDto
        {
            Id = todo.Id,
            Title = todo.Title,
            IsCompleted = todo.IsCompleted,
            CreatedAt = todo.CreatedAt
        }).ToList();
    }

    public async Task<TodoResponseDto?> GetTodoByIdAsync(int id, int userId)
    {
        var todo = await _todoRepository.GetByIdAsync(id, userId);

        if (todo == null)
            return null;

        return MapToResponse(todo);
    }

    public async Task<TodoResponseDto> CreateTodoAsync(CreateTodoRequestDto request, int userId)
    {
        var todo = new Todo
        {
            Title = request.Title,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow,
            UserId = userId
        };

        var createdTodo = await _todoRepository.CreateAsync(todo);

        return MapToResponse(createdTodo);
    }

    public async Task<TodoResponseDto?> UpdateTodoAsync(int id, UpdateTodoRequestDto request, int userId)
    {
        var todo = await _todoRepository.GetByIdAsync(id, userId);

        if (todo == null)
            return null;

        todo.Title = request.Title;
        todo.IsCompleted = request.IsCompleted;

        var updatedTodo = await _todoRepository.UpdateAsync(todo);

        return MapToResponse(updatedTodo!);
    }

    public async Task<bool> DeleteTodoAsync(int id, int userId)
    {
        var todo = await _todoRepository.GetByIdAsync(id, userId);

        if (todo == null)
            return false;

        return await _todoRepository.DeleteAsync(todo);
    }

    private TodoResponseDto MapToResponse(Todo todo)
    {
        return new TodoResponseDto
        {
            Id = todo.Id,
            Title = todo.Title,
            IsCompleted = todo.IsCompleted,
            CreatedAt = todo.CreatedAt
        };
    }
}