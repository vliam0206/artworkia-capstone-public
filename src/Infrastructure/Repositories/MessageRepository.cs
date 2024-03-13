using Application.Services.Abstractions;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;
public class MessageRepository : GenericCreationRepository<Message>, IMessageRepository
{
    public MessageRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
    }

    public async Task<IPagedList<Message>> GetMessageByChatBoxPaginationAsync(Guid chatBoxId, int pageNumber, int pageSize)
    {
        var messagesList = _dbContext.Messages.Where(x => x.ChatBoxId == chatBoxId);
        var result = await this.ToPaginationAsync(messagesList, pageNumber, pageSize);
        return result;
    }
}
