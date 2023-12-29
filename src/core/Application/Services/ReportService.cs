using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class ReportService : IReportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;

    public ReportService(IUnitOfWork unitOfWork, IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
    }

    public async Task<List<Report>> GetAllReportsAsync()
    {
        return await _unitOfWork.ReportRepository.GetAllAsync();
    }

    public async Task<Report?> GetReportByIdAsync(Guid reportId)
    {
        return await _unitOfWork.ReportRepository.GetByIdAsync(reportId);
    }

    public async Task AddReportAsync(Report report)
    {

        await _unitOfWork.ReportRepository.AddAsync(report);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteReportAsync(Guid reportId)
    {
        var result = await _unitOfWork.ReportRepository.GetByIdAsync(reportId);
        if (result == null)
            throw new Exception("Cannot found report!");
        _unitOfWork.ReportRepository.Delete(result);
        await _unitOfWork.SaveChangesAsync();
    }
}
