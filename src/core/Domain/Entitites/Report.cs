using Domain.Entities.Commons;
using Domain.Enums;

namespace Domain.Entitites;
public class Report : BaseEntity, ICreation
{
    public Guid? ReportedId { get; set; }
    public Guid? CreatedBy { get; set; }
    public virtual Account AccountReport { get; set; } = default!;
    public ReportTypeEnum ReportType { get; set; }
    public string Reason { get; set; } = default!;
    public StateEnum State { get; set; }
    public DateTime CreatedOn { get; set; }
}
