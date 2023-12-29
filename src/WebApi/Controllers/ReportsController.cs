using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;

        public ReportsController(IReportService reportService, IClaimService claimService, IMapper mapper)
        {
            _reportService = reportService;
            _claimService = claimService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var result = await _reportService.GetAllReportsAsync();
            return Ok(result);
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetAllReports(ReportEntityEnum type)
        {
            var reports = await _reportService.GetAllReportsAsync();
            var commentReports = reports.Where(report => report.ReportEntity == type);
            return Ok(commentReports);
        }

        [HttpGet("{reportId}")]
        public async Task<IActionResult> GetReportById(Guid reportId)
        {
            var result = await _reportService.GetReportByIdAsync(reportId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddReport(ReportModel reportModel)
        {
            if (reportModel == null)
                return BadRequest();
            var report = _mapper.Map<Report>(reportModel);
            report.State = StateEnum.Waiting;
            try
            {
                await _reportService.AddReportAsync(report);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { IsSuccess = true });
        }

        [HttpDelete("{reportId}")]
        //[Authorize]
        public async Task<IActionResult> DeleteReport(Guid reportId)
        {
            try
            {
                await _reportService.DeleteReportAsync(reportId);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { IsSuccess = true });
        }
    }
}
