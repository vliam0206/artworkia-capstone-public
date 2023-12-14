using Domain.Entitites;
using Infrastructure.Repositories.Commons;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Application.Services.Abstractions;

namespace Infrastructure.Repositories;
public class ReviewRepository : GenericCreationRepository<Review>, IReviewRepository
{
    public ReviewRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }
}
