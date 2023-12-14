using Domain.Entitites;
using Infrastructure.Repositories.Commons;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Application.Services.Abstractions;

namespace Infrastructure.Repositories;
public class ReportRepository : GenericCreationRepository<Report>, IReportRepository
{
    public ReportRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }
}
