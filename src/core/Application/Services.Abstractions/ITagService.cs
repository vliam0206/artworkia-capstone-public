using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface ITagService
{
    Task<TagVM?> GetTagByIdAsync(Guid tagId);
    Task<List<TagVM>> GetAllTagsAsync();
    Task<List<TagVM>> SearchTagsByNameAsync(string keyword);
    Task DeleteTagAsync(Guid tagId);
    Task<TagVM> AddTagAsync(TagModel tagModel);
    Task EditTagAsync(Guid tagId, TagModel tagModel);
    bool IsTagValid(string tagName);
}
