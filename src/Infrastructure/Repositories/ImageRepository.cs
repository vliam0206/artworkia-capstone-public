using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    private readonly IClaimService _claimService;

    public ImageRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext)
    {
        _claimService = claimService;
    }
}
