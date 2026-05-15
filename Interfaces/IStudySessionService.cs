using StudyHub_API.DTOs.StudySessions;

namespace StudyHub_API.Interfaces;

public interface IStudySessionService
{
    Task<List<StudySessionResponseDto>> GetSessionsAsync(int userId);
    Task<StudySessionResponseDto> CreateSessionAsync(CreateStudySessionRequestDto request, int userId);
    Task<bool> DeleteSessionAsync(int id, int userId);
}
