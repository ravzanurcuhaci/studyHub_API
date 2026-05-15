using System.ComponentModel.DataAnnotations;

namespace StudyHub_API.DTOs.Auth;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
    [MinLength(2, ErrorMessage = "Kullanıcı adı en az 2 karakter olmalıdır")]
    [MaxLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "Email zorunludur")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Şifre zorunludur")]
    [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
    public string Password { get; set; } = "";
}