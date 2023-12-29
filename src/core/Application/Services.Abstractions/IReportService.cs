using Domain.Entitites;
namespace Application.Services.Abstractions;

public interface IReportService
{
    Task<Report?> GetReportByIdAsync(Guid reportId);
    Task<List<Report>> GetAllReportsAsync();
    Task AddReportAsync(Report report);
    Task DeleteReportAsync(Guid reportId);
}
