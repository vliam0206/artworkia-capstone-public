using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class RefreshTokenModel
{
    [Required]
    public string RefreshToken { get; set; } = default!;
}

public class AccessTokenModel
{
    [Required]
    public string AccessToken { get; set; } = default!;
}
