using Domain.Entitites;

namespace Domain.Repositories.Abstractions;
public interface IChatBoxRepository : IGenericRepository<ChatBox>
{
    Task<ChatBox?> GetChatBoxAsync(Guid audienceId, Guid creatorId);
}
