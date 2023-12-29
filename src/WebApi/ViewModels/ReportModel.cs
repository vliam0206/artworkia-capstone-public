using Domain.Enums;

namespace WebApi.ViewModels;

public class ReportModel
{
    public ReportTypeEnum ReportType { get; set; }
    public string Reason { get; set; } = default!;
    public ReportEntityEnum ReportEntity { get; set; }
    public Guid? ReportedId { get; set; }
}

public class ReportVM
{
    public ReportTypeEnum ReportType { get; set; }
    public string Reason { get; set; } = default!;
    public StateEnum State { get; set; }
    public ReportEntityEnum ReportEntity { get; set; }
    public Guid? ReportedId { get; set; }
    public Guid? CreatedBy { get; set; }
    public AccountVM AccountReport { get; set; } = default!;
    public DateTime CreatedOn { get; set; }

}
