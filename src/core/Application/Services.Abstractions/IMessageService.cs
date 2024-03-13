using Application.Commons;
using Application.Models;
using Domain.Entities.Commons;
using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IMessageService
{
    Task<MessageVM> SendMessageAsync(MessageModel model);
    Task<List<MessageVM>> GetAllMessageAsync(Guid chatId);
    Task<PagedList<MessageVM>> GetAllMessagePaginationAsync(Guid chatId, PagedCriteria pagecriteria);
}
