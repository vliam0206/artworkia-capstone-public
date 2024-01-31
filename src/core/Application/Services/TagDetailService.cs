using Application.Models;
using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class TagDetailService : ITagDetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public TagDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

    public Task DeleteTagDetailAsync(Guid tagDetailId)
    {
        throw new NotImplementedException();
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
