namespace StudyHub_API.DTOs.StudySessions;

public class StudySessionResponseDto
{
    public int Id { get; set; }
    public string Subject { get; set; } = "";
    public int DurationMinutes { get; set; }
    public DateTime StudyDate { get; set; }
}