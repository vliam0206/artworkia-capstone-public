﻿using Application.Commons;
using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class ProposalService : IProposalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;
    private readonly IMilestoneService _milstoneService;
    private readonly ITransactionHistoryService _transactionHistoryService;
    private readonly IWalletService _walletService;

    public ProposalService(IUnitOfWork unitOfWork, IMapper mapper,
        IClaimService claimService, IMilestoneService milstoneService,
        ITransactionHistoryService transactionHistoryService,
        IWalletService walletService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
        _milstoneService = milstoneService;
        _transactionHistoryService = transactionHistoryService;
        _walletService = walletService;
    }

    public async Task<ProposalVM> CreateProposalAsync(ProposalModel model)
    {
        #region validation
        // check whether service exist
        var service = await _unitOfWork.ServiceRepository.GetByIdAsync(model.ServiceId);
        if (service == null)
        {
            throw new KeyNotFoundException("Không tìm thấy dịch vụ.");
        }
        if (service.DeletedOn != null)
        {
            throw new KeyNotFoundException("Dịch vụ đã bị xóa.");
        }


        Guid audienceId = model.OrdererId;
        Guid creatorId = _claimService.GetCurrentUserId ?? default;
        if (creatorId != service.CreatedBy)
        {
            throw new BadHttpRequestException("Chỉ người sở hữu dịch vụ mới có quyền tạo thỏa thuận.");
        }
        if (audienceId == creatorId)
        {
            throw new BadHttpRequestException("Bạn không thể tạo thỏa thuận cho chính bạn.");
        }
        #endregion

        Proposal newProposal = _mapper.Map<Proposal>(model);
        await _unitOfWork.ProposalRepository.AddAsync(newProposal);

        var chatBoxExist = await _unitOfWork.ChatBoxRepository.GetChatBoxAsync(audienceId, creatorId);
        if (chatBoxExist is not null)
        {
            // create new message in that chatboxId
            var message = new Message
            {
                ChatBoxId = chatBoxExist.Id,
                ProposalId = newProposal.Id,
                CreatedBy = _claimService.GetCurrentUserId,
                CreatedOn = CurrentTime.GetCurrentTime
            };
            await _unitOfWork.MessageRepository.AddAsync(message);
        }
        else
        {
            ChatBox newChatBox = new()
            {
                AccountId_1 = audienceId,
                AccountId_2 = creatorId,
            };
            await _unitOfWork.ChatBoxRepository.AddAsync(newChatBox);

            // create new message in that chatboxId
            var message = new Message
            {
                ChatBoxId = newChatBox.Id,
                ProposalId = newProposal.Id,
                CreatedBy = _claimService.GetCurrentUserId,
                CreatedOn = CurrentTime.GetCurrentTime
            };
            await _unitOfWork.MessageRepository.AddAsync(message);
        }

        // create proposal successfully -> add Init milestone
        await _milstoneService.AddMilestoneToProposalAsync(newProposal.Id, "Thỏa thuận đã được tạo");

        await _unitOfWork.SaveChangesAsync();

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
        var proposal = await _unitOfWork.ProposalRepository.GetProposalDetailWithReviewAsync(proposalId);
        if (proposal == null)
        {
            throw new KeyNotFoundException("Không tìm thấy thỏa thuận.");
        }

        var proposalVM = _mapper.Map<ProposalVM>(proposal);
        return proposalVM;
    }

    public async Task<List<ProposalVM>> GetProposalsByChatIdAsync(Guid chatId)
    {
        // check whether chatSession exist
        var chatExist = await _unitOfWork.ChatBoxRepository.GetByIdAsync(chatId);
        if (chatExist == null)
        {
            throw new KeyNotFoundException("Không tìm thấy phiên chat.");
        }
        var listProposal = await _unitOfWork.ProposalRepository
                                .GetProposalsByChatIdAsync(chatId);
        var listProposalVM = _mapper.Map<List<ProposalVM>>(listProposal);
        return listProposalVM;
    }

    public async Task<List<ProposalVM>> GetProposalsByAccountIdAsync(Guid accountId)
    {
        bool isAccountExist = await _unitOfWork.AccountRepository.IsExistedAsync(accountId);
        if (!isAccountExist)
        {
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");
        }

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
        if (service == null)
        {
            throw new KeyNotFoundException("Không tìm thấy dịch vụ.");
        }
        if (service.DeletedOn != null)
        {
            throw new KeyNotFoundException("Dịch vụ đã bị xóa.");
        }
        var listProposal = await _unitOfWork.ProposalRepository
                                .GetListByConditionAsync(x => x.ServiceId == serviceId);
        var listProposalVM = _mapper.Map<List<ProposalVM>>(listProposal);
        return listProposalVM;
    }

    public async Task<ProposalVM> UpdateProposalStatusAsync(Guid id, ProposalUpdateStatusModel model)
    {
        var proposal = await _unitOfWork.ProposalRepository.GetProposalDetailWithReviewAsync(id);
        if (proposal == null)
        {
            throw new KeyNotFoundException("Không tìm thấy thỏa thuận.");
        }
        Guid currenUser = _claimService.GetCurrentUserId ?? default;
        if ((currenUser != proposal.CreatedBy && currenUser != proposal.OrdererId)
            || (currenUser == proposal.CreatedBy && model.Status != ProposalStateEnum.Cancelled)
            || (currenUser == proposal.OrdererId && model.Status == ProposalStateEnum.Cancelled))
        {
            throw new BadHttpRequestException("Bạn không có quyền cập nhật trạng thái thỏa thuận.");
        }
        proposal.ProposalStatus = model.Status;
        _unitOfWork.ProposalRepository.Update(proposal);

        // create proposal successfully -> add new milestone
        await _milstoneService.AddMilestoneToProposalAsync(id, "", model.Status);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ProposalVM>(proposal);
    }

    public async Task DeleteProposalAsync(Guid proposalId)
    {
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(proposalId);
        if (proposal == null)
        {
            throw new KeyNotFoundException("Không tìm thấy thỏa thuận.");
        }

        _unitOfWork.ProposalRepository.Delete(proposal);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<TransactionHistoryVM> InitPaymentProposalAsync(Guid proposalId)
    {
        #region check if payment is valid
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(proposalId);
        if (proposal == null)
        {
            throw new KeyNotFoundException("Không tìm thấy thỏa thuận.");
        }
        if (proposal.InitialPrice == 0)
        {
            throw new BadHttpRequestException("Thỏa thuận này không cần đặt cọc.");
        }
        if (proposal.ProposalStatus == ProposalStateEnum.InitPayment
            || proposal.ProposalStatus == ProposalStateEnum.CompletePayment)
        {
            throw new BadHttpRequestException("Thỏa thuận này đã được thanh toán.");
        }
        var currentId = _claimService.GetCurrentUserId ?? default;
        if (currentId != proposal.OrdererId)
        {
            throw new UnauthorizedAccessException("Bạn không có quyền thanh toán cho thỏa thuận này.");
        }
        #endregion

        // payment (coins)
        var amount = proposal.InitialPrice * proposal.Total;
        var creatorId = proposal.CreatedBy ?? default;
        // substract coins from audience wallet
        await _walletService.SubtrasctCoinsFromWallet(currentId, amount, false);
        // add coins to creator wallet
        await _walletService.AddCoinsToWallet(creatorId, amount, false);

        // payment successfully
        // 1. add new payment history for audience (createdBy) and creator (ToAccountId)
        var transactionHistory = new TransactionModel
        {
            ProposalId = proposalId,
            Detail = $"Đặt cọc thỏa thuận \"{proposal.ProjectTitle}\" ({proposal.InitialPrice * 100}%)",
            Price = amount,
            TransactionStatus = TransactionStatusEnum.Success,
            ToAccountId = creatorId
        };
        var transactionVM = await _transactionHistoryService.CreateTransactionHistory(transactionHistory);

        // 2. payment successfully -> add new miletone
        await _milstoneService.AddMilestoneToProposalAsync(proposalId, $"Đặt cọc thành công {amount} xu ({proposal.InitialPrice * 100}%)");

        // 3. update the proposal status
        proposal.ProposalStatus = ProposalStateEnum.InitPayment;
        _unitOfWork.ProposalRepository.Update(proposal);

        await _unitOfWork.SaveChangesAsync();

        return transactionVM;
    }

    public async Task<TransactionHistoryVM> CompletePaymentProposalAsync(Guid proposalId)
    {
        #region check if payment is valid
        var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(proposalId);
        if (proposal == null)
        {
            throw new KeyNotFoundException("Không tìm thấy thỏa thuận.");
        }
        if (proposal.ProposalStatus != ProposalStateEnum.Completed)
        {
            if (proposal.ProposalStatus != ProposalStateEnum.InitPayment)
            {
                throw new BadHttpRequestException("Thỏa thuận phải được đặt cọc trước khi tiến hành hoàn tất thanh toán.");
            }
            throw new BadHttpRequestException("Trạng thái dự án chưa được hoàn thành.");
        }
        if (proposal.ProposalStatus == ProposalStateEnum.CompletePayment)
        {
            throw new BadHttpRequestException("Thỏa thuận này đã được thanh toán.");
        }
        var currentId = _claimService.GetCurrentUserId ?? default;
        if (currentId != proposal.OrdererId)
        {
            throw new UnauthorizedAccessException("Bạn không có quyền thanh toán cho thỏa thuận này.");
        }
        #endregion

        // payment (coins)
        var amount = proposal.Total - (proposal.InitialPrice * proposal.Total);
        var creatorId = proposal.CreatedBy ?? default;
        // substract coins from audience wallet
        await _walletService.SubtrasctCoinsFromWallet(currentId, amount, false);
        // add coins to creator wallet
        await _walletService.AddCoinsToWallet(creatorId, amount, false);

        // payment successfully
        // 1. add new payment history for audience (createdBy) and creator (ToAccountId)
        var transactionHistory = new TransactionModel
        {
            ProposalId = proposalId,
            Detail = $"Hoàn tất thanh toán thỏa thuận \"{proposal.ProjectTitle}\" ({(1 - proposal.InitialPrice) * 100}%)",
            Price = amount,
            TransactionStatus = TransactionStatusEnum.Success,
            ToAccountId = creatorId
        };
        var transactionVM = await _transactionHistoryService.CreateTransactionHistory(transactionHistory);

        // 2. add new miletone
        await _milstoneService.AddMilestoneToProposalAsync(proposalId, $"Hoàn tất thanh toán {amount} xu ({(1 - proposal.InitialPrice) * 100}%)");

        // 3. update the proposal status
        proposal.ProposalStatus = ProposalStateEnum.CompletePayment;
        proposal.ActualDelivery = DateTime.UtcNow;

        _unitOfWork.ProposalRepository.Update(proposal);

        await _unitOfWork.SaveChangesAsync();

        return transactionVM;
    }
}
