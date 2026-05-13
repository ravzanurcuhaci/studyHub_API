using Microsoft.EntityFrameworkCore;
using StudyHub_API.Data;
using StudyHub_API.Interfaces;
using StudyHub_API.Models;

namespace StudyHub_API.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetByUserIdAsync(int userId)
    {
        return await _context.Todos
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id, int userId)
    {
        return await _context.Todos
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == userId);
    }

    public async Task<Todo> CreateAsync(Todo todo)
    {
        _context.Todos.Add(todo);

        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<Todo?> UpdateAsync(Todo todo)
    {
        _context.Todos.Update(todo);

        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<bool> DeleteAsync(Todo todo)
    {
        _context.Todos.Remove(todo);

        await _context.SaveChangesAsync();

        return true;
    }
}