namespace StudyHub_API.DTOs.Stats;

public class WeeklyStatsResponseDto
{
    public int WeeklyStudyMinutes { get; set; }
    public int WeeklySessionCount { get; set; }
    public int WeeklyCompletedTodos { get; set; }
    public List<DailyStudyDto> DailyBreakdown { get; set; } = new();
}

public class DailyStudyDto
{
    public string Day { get; set; } = "";
    public DateTime Date { get; set; }
    public int TotalMinutes { get; set; }
}
