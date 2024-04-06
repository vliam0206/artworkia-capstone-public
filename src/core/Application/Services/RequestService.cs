using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class RequestService : IRequestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public RequestService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IClaimService claimService
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<RequestVM> AddRequestAsync(RequestModel requestModel)
    {
        // kiem tra service co ton tai khong
        var service = await _unitOfWork.ServiceRepository.GetByIdAsync(requestModel.ServiceId);
        if (service == null)
        {
            throw new KeyNotFoundException("Không tìm thấy dịch vụ.");
        }
        if (service.DeletedOn != null)
        {
            throw new Exception("Dịch vụ này đã bị xóa.");
        }

        // kiem tra budget co >= statingPrice cua service khong
        if (requestModel.Budget < service.StartingPrice)
        {
            throw new Exception("Ngân sách không được nhỏ hơn giá khởi điểm của dịch vụ.");
        }

        // kiem tra xem nguoi dung co the request service cua chinh minh khong
        Guid audienceId = _claimService.GetCurrentUserId ?? default;
        Guid creatorId = service.CreatedBy ?? default;
        if (audienceId == creatorId)
        {
            throw new Exception("Bạn không thể tạo yêu cầu cho chính dịch vụ của bạn.");
        }

        Request newRequest = _mapper.Map<Request>(requestModel);
        newRequest.RequestStatus = StateEnum.Waiting;

        var chatBoxExist = await _unitOfWork.ChatBoxRepository.GetChatBoxAsync(audienceId, creatorId);
        if (chatBoxExist is not null)
        {
            newRequest.ChatBoxId = chatBoxExist.Id;
        } else
        {
            ChatBox newChatBox = new ChatBox()
            {
                AccountId_1 = _claimService.GetCurrentUserId ?? default,
                AccountId_2 = service.CreatedBy ?? default,
            };
            await _unitOfWork.ChatBoxRepository.AddAsync(newChatBox);
            newRequest.ChatBoxId = newChatBox.Id;
        }
        await _unitOfWork.RequestRepository.AddAsync(newRequest);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<RequestVM>(newRequest);
    }

    public async Task<List<RequestVM>> GetAllRequestsAsync()
    {
        var listRequest = await _unitOfWork.RequestRepository.GetAllAsync();
        var listRequestVM = _mapper.Map<List<RequestVM>>(listRequest);
        return listRequestVM;
    }

    public async Task<RequestVM?> GetRequestByIdAsync(Guid requestId)
    {
        var request = await _unitOfWork.RequestRepository.GetByIdAsync(requestId);
        if (request == null)
        {
            throw new KeyNotFoundException("Không tìm thấy yêu cầu.");
        }

        var requestVM = _mapper.Map<RequestVM>(request);
        return requestVM;
    }

    public async Task<List<RequestVM>> GetRequestsByAudienceIdAsync()
    {
        var listRequest = await _unitOfWork.RequestRepository.GetRequestsByAudienceIdAsync();
        var listRequestVM = _mapper.Map<List<RequestVM>>(listRequest);
        return listRequestVM;
    }

    public async Task<List<RequestVM>> GetRequestsByChatboxIdIdAsync(Guid chatboxId)
    {
        var listRequest = await _unitOfWork.RequestRepository.GetRequestsByChatBoxIdAsync(chatboxId);
        var listRequestVM = _mapper.Map<List<RequestVM>>(listRequest);
        return listRequestVM;
    }

    public async Task<List<RequestVM>> GetRequestsByCreatorIdAsync()
    {
        var listRequest = await _unitOfWork.RequestRepository.GetRequestsByCreatorIdAsync();
        var listRequestVM = _mapper.Map<List<RequestVM>>(listRequest);
        return listRequestVM;
    }

    public async Task<List<RequestVM>> GetRequestsByServiceIdAsync(Guid serviceId)
    {
        var listRequest = await _unitOfWork.RequestRepository.GetRequestsByServiceIdAsync(serviceId);
        var listRequestVM = _mapper.Map<List<RequestVM>>(listRequest);
        return listRequestVM;
    }

    public async Task<RequestVM> UpdateRequestStatusAsync(Guid requestId, StateEnum requestStatus)
    {
        var oldRequest = await _unitOfWork.RequestRepository.GetByIdAsync(requestId);
        if (oldRequest == null)
        {
            throw new KeyNotFoundException("Không tìm thấy yêu cầu.");
        }

        oldRequest.RequestStatus = requestStatus;
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<RequestVM>(oldRequest);
    }
}
