using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using System.Text.RegularExpressions;

namespace Application.Services;
public class TagService : ITagService
{
    private readonly IUnitOfWork _unitOfWork;

    public TagService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _unitOfWork.TagRepository.GetAllAsync();
    }

    public async Task<Tag?> GetTagByIdAsync(Guid tagId)
    {
        return await _unitOfWork.TagRepository.GetByIdAsync(tagId);
    }

    public async Task AddTagAsync(Tag tag)
    {
        var tagExist = await _unitOfWork.TagRepository.GetSingleByConditionAsync(x => x.TagName == tag.TagName);
        if (tagExist != null)
            throw new Exception($"Tag name '{tag.TagName}' is existed!");
        await _unitOfWork.TagRepository.AddAsync(tag);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTagAsync(Guid tagId)
    {
        var result = await _unitOfWork.TagRepository.GetByIdAsync(tagId);
        if (result == null)
            throw new Exception("Cannot found tag!");
        _unitOfWork.TagRepository.Delete(result);
        await _unitOfWork.SaveChangesAsync();
    }
}
