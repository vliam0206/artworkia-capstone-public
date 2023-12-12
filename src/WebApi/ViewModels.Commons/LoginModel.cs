using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels.Commons;

public class LoginModel
{
    [Required]
    public string Username { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
}
