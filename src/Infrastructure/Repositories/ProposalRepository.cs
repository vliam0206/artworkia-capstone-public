using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ProposalRepository : GenericCreationRepository<Proposal>, IProposalRepository
{
    public ProposalRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }

    public async Task<Proposal?> GetProposalDetailAsync(Guid proposalId)
    {
        return await _dbContext.Proposals
            .Include(x => x.Service)
            .Include(x => x.Account)
            .Include(x => x.ChatBox)
            .Include(x => x.ProposalAssets)
            .Include(x => x.Review)
            .Include(x => x.TransactionHistories)
            .Include(x => x.Milestones)
            .FirstOrDefaultAsync(x => x.Id == proposalId);
    }

    public async Task<Proposal?> GetProposalDetailWithReviewAsync(Guid proposalId)
    {
        return await _dbContext.Proposals
            .Include(x => x.Review)
            .FirstOrDefaultAsync(x => x.Id == proposalId);
    }
}
