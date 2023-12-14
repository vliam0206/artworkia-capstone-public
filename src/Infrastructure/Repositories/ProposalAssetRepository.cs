using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class ProposalAssetRepository : GenericCreationRepository<ProposalAsset>, IProposalAssetRepository
{
    public ProposalAssetRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }
}
