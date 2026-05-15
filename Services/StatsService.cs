using StudyHub_API.DTOs.Stats;
using StudyHub_API.Interfaces;

namespace StudyHub_API.Services;

public class StatsService : IStatsService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IStudySessionRepository _sessionRepository;

    public StatsService(ITodoRepository todoRepository, IStudySessionRepository sessionRepository)
    {
        _todoRepository = todoRepository;
        _sessionRepository = sessionRepository;
    }

    public async Task<UserStatsResponseDto> GetSummaryAsync(int userId)
    {
        var todos = await _todoRepository.GetByUserIdAsync(userId);
        var sessions = await _sessionRepository.GetByUserIdAsync(userId);

        return new UserStatsResponseDto
        {
            TotalStudyMinutes = sessions.Sum(s => s.DurationMinutes),
            TotalStudySessions = sessions.Count,
            CompletedTodos = todos.Count(t => t.IsCompleted),
            PendingTodos = todos.Count(t => !t.IsCompleted)
        };
    }

    public async Task<WeeklyStatsResponseDto> GetWeeklyAsync(int userId)
    {
        var todos = await _todoRepository.GetByUserIdAsync(userId);
        var sessions = await _sessionRepository.GetByUserIdAsync(userId);

        // Bu haftanın Pazartesi gününü bul
        var today = DateTime.UtcNow.Date;
        var daysSinceMonday = ((int)today.DayOfWeek + 6) % 7;
        var weekStart = today.AddDays(-daysSinceMonday);

        // Bu haftaya ait session'ları filtrele
        var weeklySessions = sessions
            .Where(s => s.StudyDate.Date >= weekStart && s.StudyDate.Date <= today)
            .ToList();

        // Bu haftaya ait tamamlanan todo'ları say (CreatedAt'e göre)
        var weeklyCompletedTodos = todos
            .Count(t => t.IsCompleted && t.CreatedAt.Date >= weekStart && t.CreatedAt.Date <= today);

        // Gün gün kırılım oluştur
        var dailyBreakdown = new List<DailyStudyDto>();

        for (int i = 0; i <= daysSinceMonday; i++)
        {
            var date = weekStart.AddDays(i);

            var dailyMinutes = weeklySessions
                .Where(s => s.StudyDate.Date == date)
                .Sum(s => s.DurationMinutes);

            dailyBreakdown.Add(new DailyStudyDto
            {
                Day = date.ToString("dddd"),
                Date = date,
                TotalMinutes = dailyMinutes
            });
        }

        return new WeeklyStatsResponseDto
        {
            WeeklyStudyMinutes = weeklySessions.Sum(s => s.DurationMinutes),
            WeeklySessionCount = weeklySessions.Count,
            WeeklyCompletedTodos = weeklyCompletedTodos,
            DailyBreakdown = dailyBreakdown
        };
    }
}
