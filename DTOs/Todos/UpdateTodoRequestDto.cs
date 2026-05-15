using System.ComponentModel.DataAnnotations;

namespace StudyHub_API.DTOs.Todos;

public class UpdateTodoRequestDto
{
    [Required(ErrorMessage = "Başlık zorunludur")]
    [MaxLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir")]
    public string Title { get; set; } = "";

    public bool IsCompleted { get; set; }
}