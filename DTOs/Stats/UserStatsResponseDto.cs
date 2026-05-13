namespace StudyHub_API.DTOs.Stats;

public class UserStatsResponseDto
{
    public int TotalStudyMinutes { get; set; }
    public int TotalStudySessions { get; set; }
    public int CompletedTodos { get; set; }
    public int PendingTodos { get; set; }
}