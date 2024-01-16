namespace Application.Models;

public class AccountBasicInfoVM
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Fullname { get; set; } = default!;
    public string? Avatar { get; set; }
}
