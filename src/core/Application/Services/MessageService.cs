using Application.Commons;
using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public MessageService(IUnitOfWork unitOfWork,
        IClaimService claimService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
        _mapper = mapper;
    }

    public async Task<List<MessageVM>> GetAllMessageAsync(Guid chatId)
    {
        var messages = await _unitOfWork.MessageRepository
                        .GetListByConditionAsync(x => x.ChatBoxId == chatId);
        return _mapper.Map<List<MessageVM>>(messages);
    }

    public async Task<PagedList<MessageVM>> GetAllMessagePaginationAsync(Guid chatId, PagedCriteria pagecriteria)
    {
        var messagesPagination = await _unitOfWork.MessageRepository
            .GetMessageByChatBoxPaginationAsync(chatId, pagecriteria.PageNumber, pagecriteria.PageSize);
        var viewModel = _mapper.Map<PagedList<MessageVM>>(messagesPagination);
        return viewModel;
    }

    public async Task<MessageVM> SendMessageAsync(MessageModel model)
    {
        // check if message model is valid
        if (model.Text.IsNullOrEmpty() && model.FileLocation.IsNullOrEmpty())
        { // text & file location can not be null at the same time
            throw new ArgumentException("Text or FileLocation can not be null at the same time.");
        }
        var accountExist = await _unitOfWork.AccountRepository.IsExistedAsync(model.ReceiverId);
        if (!accountExist)
        {
            throw new ArgumentException("Receiver account Id not found.");
        }
        var currentUserId = _claimService.GetCurrentUserId ?? default;
        if (model.ReceiverId == currentUserId)
        {
            throw new ArgumentException("You can not send message to yourself!");
        }
        var newMessage = _mapper.Map<Message>(model);
        // check if the chatbox is existed
        var senderId = _claimService.GetCurrentUserId ?? default;
        var chatBoxExist = await _unitOfWork.ChatBoxRepository.GetChatBoxAsync(senderId, model.ReceiverId);
        if (chatBoxExist is not null)
        {
            newMessage.ChatBoxId = chatBoxExist.Id;
        }
        else
        {
            ChatBox newChatBox = new ChatBox()
            {
                AccountId_1 = senderId,
                AccountId_2 = model.ReceiverId,
            };
            await _unitOfWork.ChatBoxRepository.AddAsync(newChatBox);
            newMessage.ChatBoxId = newChatBox.Id;
        }
        // save new message to db
        await _unitOfWork.MessageRepository.AddAsync(newMessage);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<MessageVM>(newMessage);
    }
}
