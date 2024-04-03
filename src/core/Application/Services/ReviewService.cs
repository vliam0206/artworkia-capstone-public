using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public ReviewService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IClaimService claimService
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<PagedList<ReviewVM>> GetReviewsAsync(ReviewCriteria criteria)
    {
        var listReview = await _unitOfWork.ReviewRepository.GetReviewsAsync(
            criteria.Keyword, criteria.SortColumn, criteria.SortOrder, criteria.PageNumber, criteria.PageSize);
        return _mapper.Map<PagedList<ReviewVM>>(listReview);
    }

    public async Task<PagedList<ReviewVM>> GetReviewsByAccountIdAsync(Guid accountId, PagedCriteria criteria)
    {
        bool isAccountExisted = await _unitOfWork.AccountRepository.IsExistedAsync(accountId);
        if (!isAccountExisted) {
            throw new NullReferenceException("Account does not existed.");
        }
        var reviews = await _unitOfWork.ReviewRepository.GetReviewsByAccountIdAsync(accountId, criteria.PageNumber, criteria.PageSize);
        return _mapper.Map<PagedList<ReviewVM>>(reviews);
    }

    public async Task<PagedList<ReviewVM>> GetReviewsByServiceIdAsync(Guid serviceId, PagedCriteria criteria)
    {
        bool isServiceExisted = await _unitOfWork.ServiceRepository.IsExistedAsync(serviceId);
        if (!isServiceExisted)
        {
            throw new NullReferenceException("Service does not existed.");
        }
        var reviews = await _unitOfWork.ReviewRepository.GetReviewsByServiceIdAsync(serviceId, criteria.PageNumber, criteria.PageSize);
        return _mapper.Map<PagedList<ReviewVM>>(reviews);
    }

    public async Task<ReviewVM> GetReviewByProposalIdAsync(Guid proposalId)
    {
        bool isProposalExisted = await _unitOfWork.ProposalRepository.IsExistedAsync(proposalId);
        if (!isProposalExisted)
        {
            throw new NullReferenceException("Proposal does not existed.");
        }
        var review = await _unitOfWork.ReviewRepository.GetReviewByProposalIdAsync(proposalId);
        var reviewVM = _mapper.Map<ReviewVM>(review);   
        return reviewVM;
    }

    public async Task<ReviewVM> GetReviewAsync(Guid id)
    {
        var review = await _unitOfWork.ReviewRepository.GetReviewDetailAsync(id);
        if (review == null)
        {
            throw new NullReferenceException("Review does not exist or already deleted!");
        }
        return _mapper.Map<ReviewVM>(review);
    }

    public async Task<ReviewVM> AddReviewAsync(ReviewModel model)
    {
        // kiem tra proposal co ton tai khong
        var proposal = await _unitOfWork.ProposalRepository.GetProposalDetailAsync(model.ProposalId);
        if (proposal == null)
        {
            throw new NullReferenceException("Proposal does not exist or already deleted!");
        }

        if (proposal.Review != null)
        {
            throw new Exception("Can not review, proposal is already reviewed!");
        }

        if (proposal.ProposalStatus != ProposalStateEnum.CompletePayment)
        {
            throw new Exception("Can not review, proposal is not completed yet!");
        }

        Guid accountId = _claimService.GetCurrentUserId ?? default;
        if (proposal.OrdererId != accountId)
        {
            throw new Exception("Can not review, you are not the orderer of this proposal.");
        }

        Review newReview = _mapper.Map<Review>(model);  
        await _unitOfWork.ReviewRepository.AddAsync(newReview);
        await _unitOfWork.SaveChangesAsync();
        var result = await _unitOfWork.ReviewRepository.GetByIdAsync(newReview.Id);
        return _mapper.Map<ReviewVM>(result);
    }

    public async Task<ReviewVM> UpdateReviewAsync(Guid reviewId, ReviewEM model)
    {
        Guid accountId = _claimService.GetCurrentUserId ?? default;
        var oldReview = await _unitOfWork.ReviewRepository.GetByIdAsync(reviewId);
        if (oldReview == null)
        {
            throw new NullReferenceException("Review does not exist or already deleted!");
        }
        if (oldReview.CreatedBy != accountId)
        {
            throw new Exception("You are not the owner of this review!");
        }

        oldReview.Vote = model.Vote;
        oldReview.Detail = model.Detail;
        _unitOfWork.ReviewRepository.Update(oldReview);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ReviewVM>(oldReview);
    }

    public async Task DeleteReviewAsync(Guid id)
    {
        var review = await _unitOfWork.ReviewRepository.GetByIdAsync(id);
        if (review == null)
        {
            throw new NullReferenceException("Review does not exist or already deleted!");
        }

        var currentRole = _claimService.GetCurrentRole;
        if (currentRole.Equals(RoleEnum.Moderator.ToString())
                || (currentRole.Equals(RoleEnum.CommonUser.ToString())
                && _claimService.GetCurrentUserId != review.CreatedBy))
        {
            throw new Exception("You are not authorized to delete this review!");
        }
        _unitOfWork.ReviewRepository.Delete(review);
        await _unitOfWork.SaveChangesAsync();
    }

}
