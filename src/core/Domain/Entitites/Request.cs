using Domain.Entities.Commons;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Request : BaseEntity, ICreation
{
    [MaxLength(255)]
    public string Message { get; set; } = default!;
    [MaxLength(255)]
    public string Timeline { get; set; } = default!;
    public StateEnums RequestStatus { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid ServiceId { get; set; }
    public Guid ChatBoxId { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual Service Service { get; set; } = default!;
    public virtual ChatBox ChatBox { get; set; } = default!;
}
