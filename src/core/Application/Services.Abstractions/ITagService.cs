using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface ITagService
{
    Task<Tag?> GetTagByIdAsync(Guid tagId);
    Task<List<Tag>> GetAllTagsAsync();
    Task DeleteTagAsync(Guid tagId);
    Task AddTagAsync(Tag tag);
    Task AddTagRangeAsync(List<Tag> tag);
}
