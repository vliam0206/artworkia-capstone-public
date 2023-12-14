using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class TransactionHistoryRepository : GenericRepository<TransactionHistory>, ITransactionHistoryRepository
{
    public TransactionHistoryRepository(AppDBContext dBContext) : base(dBContext)
    {
    }
}
