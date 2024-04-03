using Application.Models;
using Application.Services.Abstractions;
using Domain.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProposalsController : ControllerBase
{
    private readonly IProposalService _proposalService;
    private readonly IMilestoneService _milestoneService;
    private readonly IReviewService _reviewService;

    public ProposalsController(
        IProposalService proposalService, 
        IMilestoneService milestoneService,
        IReviewService reviewService)
    {
        _proposalService = proposalService;
        _milestoneService = milestoneService;
        _reviewService = reviewService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllProposals()
    {
        var proposal = await _proposalService.GetAllProposalsAsync();
        return Ok(proposal);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetProposalById(Guid id)
    {
        try
        {
            var proposal = await _proposalService.GetProposalByIdAsync(id);
            return Ok(proposal);
        } catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}/review")]
    public async Task<IActionResult> GetReviewByProposalId(Guid id)
    {
        try
        {
            var proposal = await _reviewService.GetReviewByProposalIdAsync(id);
            return Ok(proposal);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("/api/chats/{chatId}/[controller]")]
    [Authorize]
    public async Task<IActionResult> GetProposalByChatId(Guid chatId)
    {
        try
        {
            var proposal = await _proposalService.GetProposalsByChatIdAsync(chatId);
            return Ok(proposal);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("/api/accounts/{accountId}/[controller]")]
    [Authorize]
    public async Task<IActionResult> GetProposalByAccountId(Guid accountId)
    {
        try
        {
            var proposal = await _proposalService.GetProposalsByAccountIdAsync(accountId);
            return Ok(proposal);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("/api/services/{serviceId}/[controller]")]
    [Authorize]
    public async Task<IActionResult> GetProposalByServiceId(Guid serviceId)
    {
        try
        {
            var proposal = await _proposalService.GetProposalsByServiceIdAsync(serviceId);
            return Ok(proposal);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostProposal(ProposalModel model)
    {
        try
        {
            var proposal = await _proposalService.CreateProposalAsync(model);
            return CreatedAtAction("GetProposalById", new { id = proposal.Id}, proposal);
        } catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        } catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutProposal(Guid id, ProposalUpdateStatusModel model)
    {
        try
        {
            var proposal = await _proposalService.UpdateProposalStatusAsync(id, model);
            return Ok(proposal);
        } catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        } catch(BadHttpRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("milestones/{proposalId}")]
    [Authorize]
    public async Task<IActionResult> GetAllMilestinesOfProposal(Guid proposalId)
    {
        var milestones = await _milestoneService.GetMilestonesAsync(proposalId);
        return Ok(milestones);        
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteProposal(Guid id)
    {
        try
        {
            await _proposalService.DeleteProposalAsync(id);
            return NoContent();
        } catch( ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("init-payment/{id}")]
    [Authorize]
    public async Task<IActionResult> InitPaymentProposal(Guid id)
    {
        try
        {
            var transaction = await _proposalService.InitPaymentProposalAsync(id);
            return Ok(transaction);
        } catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }         
    }

    [HttpPost("complete-payment/{id}")]
    [Authorize]
    public async Task<IActionResult> CompletePaymentProposal(Guid id)
    {
        try
        {
            var transaction = await _proposalService.CompletePaymentProposalAsync(id);
            return Ok(transaction);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
