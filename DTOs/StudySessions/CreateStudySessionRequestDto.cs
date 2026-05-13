namespace StudyHub_API.DTOs.StudySessions;

public class CreateStudySessionRequestDto
{
    public string Subject { get; set; } = "";
    public int DurationMinutes { get; set; }
    public DateTime StudyDate { get; set; }
}