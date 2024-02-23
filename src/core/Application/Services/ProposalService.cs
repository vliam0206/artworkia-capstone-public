using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class ProposalService : IProposalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;
    private readonly IMilestoneService _milstoneService;

    public ProposalService(IUnitOfWork unitOfWork, IMapper mapper, 
        IClaimService claimService, IMilestoneService milstoneService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
        _milstoneService = milstoneService;
    }

    public async Task<ProposalVM> CreateProposalAsync(ProposalModel model)
    {
        // check whether service exist
        var service = await _unitOfWork.ServiceRepository.GetByIdAsync(model.ServiceId);
        if (service == null || service.DeletedOn != null)
        {
            throw new ArgumentException("Service does not exist or already deleted!");
        }

        Guid audienceId = model.OrdererId;
        Guid creatorId = _claimService.GetCurrentUserId ?? default;
        if (creatorId != service.CreatedBy)
        {
            throw new ArgumentException("Invalid ServiceId! You can only create proposal your own Service.");
        }
        if (audienceId == creatorId)
        {
            throw new ArgumentException("Invalid OrdererId! You can not create proposal your own proposal.");
        }        

        Proposal newProposal = _mapper.Map<Proposal>(model);

        var chatBoxExist = await _unitOfWork.ChatBoxRepository.GetChatBoxAsync(audienceId, creatorId);
        if (chatBoxExist is not null)
        {
            newProposal.ChatBoxId = chatBoxExist.Id;
        }
        else
        {
            ChatBox newChatBox = new ChatBox()
            {
                AccountId_1 = audienceId,
                AccountId_2 = creatorId,
            };
            await _unitOfWork.ChatBoxRepository.AddAsync(newChatBox);
            newProposal.ChatBoxId = newChatBox.Id;
        }
        await _unitOfWork.ProposalRepository.AddAsync(newProposal);
        await _unitOfWork.SaveChangesAsync();

        // create proposal successfully -> add Init milestone
        await _milstoneService.AddMilestoneToProposalAsync(newProposal.Id, "Thỏa thuận đã được tạo");

        return _mapper.Map<ProposalVM>(newProposal);
    }

    public async Task<List<ProposalVM>> GetAllProposalsAsync()
    {
        var listProposal = await _unitOfWork.ProposalRepository.GetAllAsync();
        var listProposalVM = _mapper.Map<List<ProposalVM>>(listProposal);
        return listProposalVM;
    }

    public async Task<ProposalVM?> GetProposalByIdAsync(Guid proposalId)
    {
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(proposalId);
        if (proposal == null)
        {
            throw new ArgumentException("Proposal does not exist");
        }

        var proposalVM = _mapper.Map<ProposalVM>(proposal);
        return proposalVM;
    }

    public  async Task<List<ProposalVM>> GetProposalsByChatIdAsync(Guid chatId)
    {
        // check whether chatSession exist
        var chatExist = await _unitOfWork.ChatBoxRepository.GetByIdAsync(chatId);
        if (chatExist == null)
        {
            throw new ArgumentException("Chat Session does not exist!");
        }
        var listProposal = await _unitOfWork.ProposalRepository
                                .GetListByConditionAsync(x => x.ChatBoxId == chatId);
        var listProposalVM = _mapper.Map<List<ProposalVM>>(listProposal);
        return listProposalVM;
    }

    public async Task<List<ProposalVM>> GetProposalsByAccountIdAsync(Guid accountId)
    {
        var listProposal = await _unitOfWork.ProposalRepository
                                .GetListByConditionAsync(x => x.CreatedBy == accountId
                                                        || x.OrdererId == accountId);
        var listProposalVM = _mapper.Map<List<ProposalVM>>(listProposal);
        return listProposalVM;
    }

    public async Task<List<ProposalVM>> GetProposalsByServiceIdAsync(Guid serviceId)
    {
        // check whether service exist
        var service = await _unitOfWork.ServiceRepository.GetByIdAsync(serviceId);
        if (service == null || service.DeletedOn != null)
        {
            throw new ArgumentException("Service does not existor been deleted!");
        }
        var listProposal = await _unitOfWork.ProposalRepository
                                .GetListByConditionAsync(x => x.ServiceId == serviceId);
        var listProposalVM = _mapper.Map<List<ProposalVM>>(listProposal);
        return listProposalVM;
    }

    public async Task<ProposalVM> UpdateProposalStatusAsync(Guid id, ProposalUpdateStatusModel model)
    {
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(id);
        if (proposal == null)
        {
            throw new ArgumentException("Proposal does not exist");
        }
        Guid currenUser = _claimService.GetCurrentUserId ?? default;
        if ((currenUser != proposal.CreatedBy && currenUser != proposal.OrdererId)
            || (currenUser == proposal.CreatedBy && model.Status != StateEnum.Cancel)
            || (currenUser == proposal.OrdererId && model.Status == StateEnum.Cancel))
        {
            throw new BadHttpRequestException("You can not do this action!");
        }
        proposal.ProposalStatus = model.Status;
        await _unitOfWork.SaveChangesAsync();

        // create proposal successfully -> add new milestone
        await _milstoneService.AddMilestoneToProposalAsync(id, "", model.Status);

        return _mapper.Map<ProposalVM>(proposal);
    }

    public async Task DeleteProposalAsync(Guid proposalId)
    {
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(proposalId);
        if (proposal == null)
        {
            throw new ArgumentException("Proposal does not exist");
        }

        _unitOfWork.ProposalRepository.Delete(proposal);
        await _unitOfWork.SaveChangesAsync();
    }
}
