using Domain.Entitites;
using Domain.Enums;

namespace WebApi.ViewModels;

public class CollectionVM
{
    public Guid Id { get; set; }
    public string CollectionName { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; }
    public AccountDisplayModel CreatedBy { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public ICollection<BookmarkVM> Artworks { get; set; } = new List<BookmarkVM>();
}

public class BookmarkVM
{
    public ArtworkDisplayModel Artwork { get; set; } = default!;
}
