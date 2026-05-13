namespace StudyHub_API.DTOs.Todos;

public class UpdateTodoRequestDto
{
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
}