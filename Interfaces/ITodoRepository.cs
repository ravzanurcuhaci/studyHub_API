using StudyHub_API.Models;
namespace StudyHub_API.Interfaces;

public interface ITodoRepository
{
    Task<List<Todo>> GetByUserIdAsync(int userId);
    Task<Todo?> GetByIdAsync(int id, int userId);
    Task<Todo> CreateAsync(Todo todo);
    Task<Todo?> UpdateAsync(Todo todo);
    Task<bool> DeleteAsync(Todo todo);
}