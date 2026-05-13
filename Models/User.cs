namespace StudyHub_API.Models;

public class User
{

    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";

    public string PasswordHash { get; set; } = "";

    public List<Todo> Todo { get; set; } = new();

    public List<StudySession> StudySessions { get; set; } = new();

}