using StudyHub_API.DTOs.Todos;

namespace StudyHub_API.Interfaces;

public interface ITodoService
{
    Task<List<TodoResponseDto>> GetTodosAsync(int userId);
    Task<TodoResponseDto?> GetTodoByIdAsync(int id, int userId);
    Task<TodoResponseDto> CreateTodoAsync(CreateTodoRequestDto request, int userId);
    Task<TodoResponseDto?> UpdateTodoAsync(int id, UpdateTodoRequestDto request, int userId);
    Task<bool> DeleteTodoAsync(int id, int userId);
}