namespace StudyHub_API.Models;

public class StudySession
{
    public int Id { get; set; }

    public string Subject { get; set; } = "";

    public int DurationMinutes { get; set; }

    public DateTime StudyDate { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;
}