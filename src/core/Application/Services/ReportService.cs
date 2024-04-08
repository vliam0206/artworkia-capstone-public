using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using static Application.Commons.VietnameseEnum;

namespace Application.Services;
public class ReportService : IReportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public ReportService(
        IUnitOfWork unitOfWork,
        IClaimService claimService,
        IMapper mapper
        )
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
        _mapper = mapper;
    }

    public async Task<IPagedList<ReportVM>> GetAllReportsAsync(ReportCriteria criteria)
    {
        var result = await _unitOfWork.ReportRepository.GetAllReportsAsync(
                       criteria.ReportEntity, criteria.State, criteria.Keyword, criteria.SortColumn,
                                  criteria.SortColumn, criteria.PageNumber, criteria.PageSize);

        result.Items.ForEach(r =>
        {
            r.Target = r.ReportEntity switch
            {
                ReportEntityEnum.Account => _mapper.Map<AccountBasicInfoVM>(r.Target),
                ReportEntityEnum.Comment => _mapper.Map<CommentVM>(r.Target),
                ReportEntityEnum.Artwork => _mapper.Map<ArtworkPreviewVM>(r.Target),
                _ => null
            };
        }
        );
        var resultVM = _mapper.Map<PagedList<ReportVM>>(result);
        return resultVM;
    }

    public async Task<ReportVM?> GetReportByIdAsync(Guid reportId)
    {
        var result = await _unitOfWork.ReportRepository.GetByIdAsync(reportId)
            ?? throw new KeyNotFoundException("Không tìm thấy báo cáo.");
        var resultVM = _mapper.Map<ReportVM>(result);
        return resultVM;
    }

    public async Task<ReportVM> AddReportAsync(ReportModel reportModel)
    {
        if (reportModel.ReportEntity == ReportEntityEnum.Comment)
        {
            var isExist = await _unitOfWork.CommentRepository.IsExistedAsync(reportModel.TargetId);
            if (!isExist)
                throw new KeyNotFoundException("Không tìm thấy bình luận.");
        }
        else if (reportModel.ReportEntity == ReportEntityEnum.Account)
        {
            var isExist = await _unitOfWork.AccountRepository.IsExistedAsync(reportModel.TargetId);
            if (!isExist)
                throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        }
        else if (reportModel.ReportEntity == ReportEntityEnum.Artwork)
        {
            var isExist = await _unitOfWork.ArtworkRepository.IsExistedAsync(reportModel.TargetId);
            if (!isExist)
                throw new KeyNotFoundException("Không tìm thấy tác phẩm.");
        }
        else
            throw new KeyNotFoundException("Không tìm thấy đối tượng báo cáo.");

        var report = _mapper.Map<Report>(reportModel);
        report.State = StateEnum.Waiting;
        await _unitOfWork.ReportRepository.AddAsync(report);
        await _unitOfWork.SaveChangesAsync();

        var resultVM = _mapper.Map<ReportVM>(report);
        return resultVM;
    }

    public async Task DeleteReportAsync(Guid reportId)
    {
        var result = await _unitOfWork.ReportRepository.GetByIdAsync(reportId)
            ?? throw new KeyNotFoundException("Không tìm thấy báo cáo.");
        _unitOfWork.ReportRepository.Delete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateReportState(Guid reportId, ReportStateEM reportStateEM)
    {
        var oldReport = await _unitOfWork.ReportRepository.GetByIdAsync(reportId);
        if (oldReport == null)
            throw new KeyNotFoundException("Không tìm thấy báo cáo.");
        if (oldReport.State != StateEnum.Waiting)
            throw new BadHttpRequestException($"Báo cáo này đã được giải quyết " +
                $"(trạng thái hiện tại là '{STATE_ENUM_VN[oldReport.State]}')");
        oldReport.State = reportStateEM.State;
        oldReport.Note = reportStateEM.Note;
        _unitOfWork.ReportRepository.Update(oldReport);
        await _unitOfWork.SaveChangesAsync();
    }
}
