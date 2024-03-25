using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class AccountVM
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string Username { get; set; } = default!;
    [MaxLength(255)]
    public string Email { get; set; } = default!;
    [MaxLength(255)]
    public string Fullname { get; set; } = default!;
    [MaxLength(300)]
    public string? Bio { get; set; }
    public string? Avatar { get; set; }
    public DateTime? Birthdate;
    public string Role { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
}

public class AccountDisplayModel
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Fullname { get; set; } = default!;
    public string? Avatar { get; set; }
}

public class AccountBasicInfoVM
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Fullname { get; set; } = default!;
    public string? Avatar { get; set; }
}

public class HiredAccountVM
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Fullname { get; set; } = default!;
    public string? Avatar { get; set; }
    public bool IsVerified { get; set; }
    public int ProjectCompleted { get; set; } = 0;
}