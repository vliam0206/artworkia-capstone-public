using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    public AssetRepository(AppDBContext dBContext) : base(dBContext)
    {
    }
}
