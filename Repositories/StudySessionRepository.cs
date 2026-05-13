using Microsoft.EntityFrameworkCore;
using StudyHub_API.Data;
using StudyHub_API.Interfaces;
using StudyHub_API.Models;

namespace StudyHub_API.Repositories;

public class StudySessionRepository : IStudySessionRepository
{
    private readonly AppDbContext _context;

    public StudySessionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudySession>> GetByUserIdAsync(int userId)
    {
        return await _context.StudySessions
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<StudySession?> GetByIdAsync(int id, int userId)
    {
        return await _context.StudySessions
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == userId);
    }

    public async Task<StudySession> CreateAsync(StudySession studySession)
    {
        _context.StudySessions.Add(studySession);

        await _context.SaveChangesAsync();

        return studySession;
    }

    public async Task<bool> DeleteAsync(StudySession studySession)
    {
        _context.StudySessions.Remove(studySession);

        await _context.SaveChangesAsync();

        return true;
    }
}