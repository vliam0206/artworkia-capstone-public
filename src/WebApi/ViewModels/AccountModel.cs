using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class AccountModel
{
    [Required]
    [MaxLength(255)]
    public string? Username { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Email { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Fullname { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Bio { get; set; }
    [Required]
    public DateTime? Birthdate;
}

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
    public string Bio { get; set; }
    public DateTime? Birthdate;
    public RoleEnum Role { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
}