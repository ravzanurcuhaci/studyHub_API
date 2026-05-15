using System.ComponentModel.DataAnnotations;

namespace StudyHub_API.DTOs.Auth;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Email zorunludur")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Şifre zorunludur")]
    public string Password { get; set; } = "";
}