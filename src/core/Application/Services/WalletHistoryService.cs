﻿using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class WalletHistoryService : IWalletHistoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WalletHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddWalletHistory(WalletHistory walletHistory)
    {
        await _unitOfWork.WalletHistoryRepository.AddAsync(walletHistory);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<WalletHistoryVM>> GetWalletHistoriesOfAccount(Guid accountId)
    {
        var result = (await _unitOfWork.WalletHistoryRepository
                                .GetListByConditionAsync(x => x.CreatedBy == accountId))
                                .OrderByDescending(x => x.CreatedOn);
        return _mapper.Map<List<WalletHistoryVM>>(result);
    }

    public async Task UpdateWalletHistory(Guid transactionId, WalletHistory walletHistory)
    {
        var oldWalletHistory = await _unitOfWork
                                    .WalletHistoryRepository
                                    .GetByIdAsync(transactionId);
        if (oldWalletHistory == null)
        {
            throw new Exception("TransactionId not found!");
        }
        // update status
        oldWalletHistory.AppTransId = walletHistory.AppTransId;
        oldWalletHistory.TransactionStatus = walletHistory.TransactionStatus;
        _unitOfWork.WalletHistoryRepository.Update(oldWalletHistory);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateWalletHistoryStatus(string appTransId, TransactionStatusEnum status)
    {
        var walletHistory = await _unitOfWork
                                    .WalletHistoryRepository
                                    .GetSingleByConditionAsync(x => x.AppTransId.Equals(appTransId));
        if (walletHistory == null)
        {
            throw new Exception("AppTransIs not found!");
        }
        // update status
        walletHistory.TransactionStatus = status;
        _unitOfWork.WalletHistoryRepository.Update(walletHistory);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateWalletHistoryStatus(Guid transactionId, TransactionStatusEnum status)
    {
        var walletHistory = await _unitOfWork
                                    .WalletHistoryRepository
                                    .GetByIdAsync(transactionId);
        if (walletHistory == null)
        {
            throw new Exception("TransactionId not found!");
        }
        // update status
        walletHistory.TransactionStatus = status;
        _unitOfWork.WalletHistoryRepository.Update(walletHistory);
        await _unitOfWork.SaveChangesAsync();
    }
}
