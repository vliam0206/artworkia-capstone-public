using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;

public interface IMessageService
{
    Task<MessageVM> SendMessageAsync(MessageModel model);
    Task<List<MessageVM>> GetAllMessageAsync(Guid chatId);
}
