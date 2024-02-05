using Application.Filters;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;
using WebApi.ViewModels;
namespace Application.Services.Abstractions;

public interface IReportService
{
    Task<ReportVM?> GetReportByIdAsync(Guid reportId);
    Task<IPagedList<ReportVM>> GetAllReportsAsync(ReportCriteria criteria);
    Task<ReportVM> AddReportAsync(ReportModel reportModel);
    Task UpdateReportState(Guid reportId, StateEnum state);
    Task DeleteReportAsync(Guid reportId);
}
