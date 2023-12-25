using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(AppDBContext dBContext) : base(dBContext)
    {
    }
}
