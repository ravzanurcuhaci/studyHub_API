using System.ComponentModel.DataAnnotations;

namespace StudyHub_API.DTOs.StudySessions;

public class CreateStudySessionRequestDto
{
    [Required(ErrorMessage = "Konu zorunludur")]
    [MaxLength(100, ErrorMessage = "Konu en fazla 100 karakter olabilir")]
    public string Subject { get; set; } = "";

    [Range(1, 1440, ErrorMessage = "Çalışma süresi 1 ile 1440 dakika arasında olmalıdır")]
    public int DurationMinutes { get; set; }

    [Required(ErrorMessage = "Çalışma tarihi zorunludur")]
    public DateTime StudyDate { get; set; }
}