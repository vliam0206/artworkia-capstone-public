using Domain.Entities.Commons;

namespace Domain.Entitites;

public class UserToken : BaseEntity
{
    public Guid UserId { get; set; }
    public string JwtId { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
    public bool IsUsed { get; set; } = false;
    public bool IsRevoked { get; set; } = false;
    public DateTime IssuedDate { get; set; } = DateTime.UtcNow.ToLocalTime();
    public DateTime ExpiredDate { get; set; }

    public virtual Account User { get; set; } = default!;
}
