using Microsoft.EntityFrameworkCore;
using StudyHub_API.Models;

namespace StudyHub_API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Todo> Todos { get; set; }

    public DbSet<StudySession> StudySessions { get; set; }
}