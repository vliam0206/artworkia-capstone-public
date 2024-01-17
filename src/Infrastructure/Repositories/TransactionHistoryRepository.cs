using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class TransactionHistoryRepository : GenericCreationRepository<TransactionHistory>, ITransactionHistoryRepository
{
    public TransactionHistoryRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }
}
