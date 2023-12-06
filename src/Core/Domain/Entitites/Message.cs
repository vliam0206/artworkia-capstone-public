using Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Message : BaseEntity, ICreation
{
    [MaxLength(1000)]
    public string? Text { get; set; }     // text or fileLocation not null at the same time
    public string? FileLocation { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public Guid ChatBoxId { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual ChatBox ChatBox { get; set; } = default!;
}
