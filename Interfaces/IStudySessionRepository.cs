using StudyHub_API.Models;

namespace StudyHub_API.Interfaces;

public interface IStudySessionRepository
{
    Task<List<StudySession>> GetByUserIdAsync(int userId);
    Task<StudySession?> GetByIdAsync(int id, int userId);
    Task<StudySession> CreateAsync(StudySession studySession);
    Task<bool> DeleteAsync(StudySession studySession);
}