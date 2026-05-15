using StudyHub_API.DTOs.Stats;

namespace StudyHub_API.Interfaces;

public interface IStatsService
{
    Task<UserStatsResponseDto> GetSummaryAsync(int userId);
    Task<WeeklyStatsResponseDto> GetWeeklyAsync(int userId);
}
