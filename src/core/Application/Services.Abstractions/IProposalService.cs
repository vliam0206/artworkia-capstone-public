using Application.Models;
using Domain.Enums;

namespace Application.Services.Abstractions;

public interface IProposalService
{
    Task<List<ProposalVM>> GetAllProposalsAsync();
    Task<ProposalVM?> GetProposalByIdAsync(Guid proposalId);
    Task<List<ProposalVM>> GetProposalsByChatIdAsync(Guid chatId);
    Task<List<ProposalVM>> GetProposalsByAccountIdAsync(Guid accountId);
    Task<List<ProposalVM>> GetProposalsByServiceIdAsync(Guid serviceId);
    Task<ProposalVM> CreateProposalAsync(ProposalModel model);
    Task<ProposalVM> UpdateProposalStatusAsync(Guid id, ProposalUpdateStatusModel model);
    Task DeleteProposalAsync(Guid proposalId);
}
