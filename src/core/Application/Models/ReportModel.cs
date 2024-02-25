﻿using Application.Models;
using Domain.Enums;

namespace WebApi.ViewModels;

public class ReportModel
{
    public ReportTypeEnum ReportType { get; set; }
    public string Reason { get; set; } = default!;
    public ReportEntityEnum ReportEntity { get; set; }
    public Guid TargetId { get; set; }
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
    public Guid? CreatedBy { get; set; }
    public AccountBasicInfoVM AccountReport { get; set; } = default!;
    public DateTime CreatedOn { get; set; }

}