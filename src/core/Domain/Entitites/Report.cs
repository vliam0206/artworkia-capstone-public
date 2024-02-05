using Domain.Entities.Commons;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitites;
public class Report : BaseEntity, ICreation
{
    public ReportTypeEnum ReportType { get; set; }
    public string Reason { get; set; } = default!;
    public ReportEntityEnum ReportEntity { get; set; }
    public StateEnum State { get; set; }
    public Guid TargetId { get; set; }
    [NotMapped]
    public object? Target { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public virtual Account AccountReport { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
}
