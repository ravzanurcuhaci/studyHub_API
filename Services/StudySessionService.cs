using StudyHub_API.DTOs.StudySessions;
using StudyHub_API.Interfaces;
using StudyHub_API.Models;

namespace StudyHub_API.Services;

public class StudySessionService : IStudySessionService
{
    private readonly IStudySessionRepository _sessionRepository;

    public StudySessionService(IStudySessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<List<StudySessionResponseDto>> GetSessionsAsync(int userId)
    {
        var sessions = await _sessionRepository.GetByUserIdAsync(userId);

        return sessions.Select(s => MapToResponse(s)).ToList();
    }

    public async Task<StudySessionResponseDto> CreateSessionAsync(CreateStudySessionRequestDto request, int userId)
    {
        var session = new StudySession
        {
            Subject = request.Subject,
            DurationMinutes = request.DurationMinutes,
            StudyDate = request.StudyDate,
            UserId = userId
        };

        var created = await _sessionRepository.CreateAsync(session);

        return MapToResponse(created);
    }

    public async Task<bool> DeleteSessionAsync(int id, int userId)
    {
        var session = await _sessionRepository.GetByIdAsync(id, userId);

        if (session == null)
            return false;

        return await _sessionRepository.DeleteAsync(session);
    }

    private StudySessionResponseDto MapToResponse(StudySession session)
    {
        return new StudySessionResponseDto
        {
            Id = session.Id,
            Subject = session.Subject,
            DurationMinutes = session.DurationMinutes,
            StudyDate = session.StudyDate
        };
    }
}
