
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class ChatBoxRepository : GenericRepository<ChatBox>, IChatBoxRepository
{
    public ChatBoxRepository(AppDBContext dBContext) : base(dBContext)
    {
    }
}