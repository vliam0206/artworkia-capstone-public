using Domain.Entitites;

namespace Domain.Repositories.Abstractions;
public interface ITagDetailRepository 
{
    Task<List<TagDetail>> GetAllTagDetailsOfArtworkAsync(Guid artworkId);
    Task AddTagDetailAsync(TagDetail tagDetail);
    void DeleteTagDetail(TagDetail tagDetail);
}
