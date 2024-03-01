using Application.Models;

namespace Application.Services.Abstractions;

public interface IProposalAssetService
{
    Task<List<ProposalAssetVM>> GetProposalAssetsOfProposalAsync(Guid proposalId);
    Task<ProposalAssetVM> AddProposalAssetAsync(ProposalAssetModel proposalAssetModel);
}
