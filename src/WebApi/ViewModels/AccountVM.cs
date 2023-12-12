using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class AccountVM
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string Username { get; set; } = default!;    
    [MaxLength(255)]
    public string Email { get; set; } = default!;
    [MaxLength(255)]
    public string Fullname { get; set; } = default!;
    [MaxLength(255)]
    public string Bio { get; set; } = string.Empty;
    public DateTime? Birthdate;
    public RoleEnum Role { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
}
