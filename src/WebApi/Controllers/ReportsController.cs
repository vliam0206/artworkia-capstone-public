using Application.Services.Abstractions;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;
using Application.Filters;
using WebApi.ViewModels.Commons;

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
        [Authorize(Roles = "Moderator,Admin")]
        public async Task<IActionResult> GetAllReports([FromQuery] ReportCriteria criteria)
        {
            var result = await _reportService.GetAllReportsAsync(criteria);
            return Ok(result);
        }

        [HttpGet("report-entity-enum")]
        public IActionResult GetReportEntityEnum()
        {
            var reportEntityEnums = Enum.GetValues(typeof(ReportEntityEnum))
                .Cast<ReportEntityEnum>().Select(r => new { Id = (int)r, Name = r.ToString() });
            return Ok(reportEntityEnums);
        }

        [HttpGet("report-state-enum")]
        public IActionResult GetReportStateEnum()
        {
            var reportStateEnum = Enum.GetValues(typeof(StateEnum))
                .Cast<StateEnum>().Select(r => new { Id = (int)r, Name = r.ToString() });
            return Ok(reportStateEnum);
        }

        [HttpGet("report-type-enum")]
        public IActionResult GetReportTypeEnum()
        {
            var reportTypeEnum = Enum.GetValues(typeof(ReportTypeEnum))
                .Cast<ReportTypeEnum>().Select(r => new { Id = (int)r, Name = r.ToString() });
            return Ok(reportTypeEnum);
        }

        [HttpGet("{reportId}")]
        [Authorize(Roles = "Moderator,Admin")]
        public async Task<IActionResult> GetReportById(Guid reportId)
        {
            var result = await _reportService.GetReportByIdAsync(reportId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportModel reportModel)
        {
            try
            {
                var result = await _reportService.AddReportAsync(reportModel);
                return CreatedAtAction(nameof(GetReportById),
                new { reportId = result.Id }, result);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpPut, Route("/api/[controller]/{reportId}/state")]
        [Authorize(Roles = "Moderator,Admin")]
        public async Task<IActionResult> UpdateReportState(Guid reportId, [FromBody] ReportStateEM reportStateEM)
        {
            try
            {
                await _reportService.UpdateReportState(reportId, reportStateEM);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpDelete("{reportId}")]
        [Authorize(Roles = "Moderator,Admin")]
        public async Task<IActionResult> DeleteReport(Guid reportId)
        {
            try
            {
                await _reportService.DeleteReportAsync(reportId);
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
