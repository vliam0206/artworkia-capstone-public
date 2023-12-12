using Domain.Entities.Commons;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Account : BaseEntity, ICreation, IModification, ISoftDelete
{
    [MaxLength(255)]
    public string Username { get; set; } = default!;
    [MaxLength(255)]
    public string Password { get; set; } = default!; // remember to hash password before save/check
    [MaxLength(255)]
    public string Email { get; set; } = default!;
    [MaxLength(255)]
    public string Fullname { get; set; } = default!;
    [MaxLength(255)]
    public string Bio { get; set; } = string.Empty;
    public DateTime? Birthdate;
    public RoleEnum Role { get; set; } = RoleEnum.CommonUser;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    public virtual Wallet Wallet { get; set; } = new Wallet();
    public virtual ICollection<ChatBox> ChatBoxes_1 { get; set; } = new List<ChatBox>();
    public virtual ICollection<ChatBox> ChatBoxes_2 { get; set; } = new List<ChatBox>();    
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
