using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class TagDetailService : ITagDetailService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public TagDetailService(
        IUnitOfWork unitOfWork,
        IClaimService claimService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
        _mapper = mapper;
    }

    public async Task<TagListArtworkVM> GetTagListOfArtworkAsync(Guid artworkId)
    {
        var taglist = await _unitOfWork.TagDetailRepository.GetAllTagDetailsOfArtworkAsync(artworkId);
        TagListArtworkVM tagListArtworkVM = new TagListArtworkVM()
        {
            ArtworkId = artworkId,
            TagList = taglist.Select(x => new TagVM()
            {
                Id = x.TagId,
                TagName = x.Tag.TagName
            }).ToList()
        };
        return tagListArtworkVM;
    }

    public async Task AddTagListArtworkAsync(TagListArtworkModel tagListArtworkModel, bool isSaveChanges = true)
    {
        var artwork = _unitOfWork.ArtworkRepository.GetByIdAsync(tagListArtworkModel.ArtworkId);
        if (artwork == null)
        {
            throw new Exception("Artwork not found");
        }

        var tagList = tagListArtworkModel.TagList;
        foreach (string tag in tagList)
        {
            TagDetailModel tagDetailModel = new TagDetailModel()
            {
                ArtworkId = tagListArtworkModel.ArtworkId,
                TagName = tag
            };
            await AddTagDetailAsync(tagDetailModel);
        }
        if (isSaveChanges)
            await _unitOfWork.SaveChangesAsync();
        
    }

    public async Task DeleteTagDetailAsync(Guid artworkId, Guid tagId)
    {
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (artwork == null)
        {
            throw new NullReferenceException("This artwork not existed");
        }
        bool isAuthorized = _claimService.IsAuthorized(artwork.CreatedBy!.Value);
        if (!isAuthorized)
        {
            throw new UnauthorizedAccessException("You are not authorized to delete this tag. (only mod, admin or owner of this artwork)");
        }
        var oldTagDetail = await _unitOfWork.TagDetailRepository.GetTagDetailAsync(artworkId, tagId);
        if (oldTagDetail == null)
        {
            throw new NullReferenceException("This artwork never had this tag, or it did not exist.");
        }
        _unitOfWork.TagDetailRepository.DeleteTagDetail(oldTagDetail);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddTagDetailAsync(TagDetailModel tagDetailModel)
    {
        var tag = await _unitOfWork.TagRepository.GetTagByNameAsync(tagDetailModel.TagName);
        Guid? tagId = tag?.Id;
        if (tag == null)
        {
            Tag newTag = new Tag()
            {
                TagName = tagDetailModel.TagName
            };
            await _unitOfWork.TagRepository.AddAsync(newTag);
            tagId = newTag.Id;
        }
        if (tagId != null)
        {
            TagDetail tagDetail = new TagDetail()
            {
                ArtworkId = tagDetailModel.ArtworkId,
                TagId = tagId.Value
            };
            await _unitOfWork.TagDetailRepository.AddTagDetailAsync(tagDetail);
        }
        await _unitOfWork.SaveChangesAsync();
    }
}
