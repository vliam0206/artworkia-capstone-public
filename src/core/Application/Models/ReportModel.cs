using Application.Models;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class ReportModel
{
    [Required]
    public ReportTypeEnum ReportType { get; set; } = default!;
    [MaxLength(500), MinLength(10)]
    public string Reason { get; set; } = default!;
    public ReportEntityEnum ReportEntity { get; set; } = default!;
    [Required]
    public Guid TargetId { get; set; }
}
public class ReportStateEM
{
    [Required]
    public StateEnum State { get; set; } = default!;
    [MaxLength(500), MinLength(10)]
    public string? Note { get; set; }
}

public class ReportVM
{
    public Guid Id { get; set; }
    public string ReportType { get; set; } = default!;
    public string Reason { get; set; } = default!;
    public string State { get; set; } = default!;
    public string ReportEntity { get; set; } = default!;
    public Guid TargetId { get; set; }
    public object? Target { get; set; }
    public string? Note { get; set; }   
    public Guid? CreatedBy { get; set; }
    public AccountBasicInfoVM AccountReport { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
}
