using Domain.Entitites;

namespace Domain.Repositories.Abstractions;
public interface IProposalRepository : IGenericRepository<Proposal>
{
    //Task<List<Proposal>> GetProposalsByChatIdAsync(Guid ChatId);
    //Task<List<Proposal>> GetProposalsByCreatorIdAsync(Guid creatorId);
    //Task<List<Proposal>> GetProposalsByServiceIdAsync(Guid serviceId);
}
