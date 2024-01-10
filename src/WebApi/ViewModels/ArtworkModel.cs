using Domain.Enums;

namespace WebApi.ViewModels;

public class ArtworkDisplayModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public PrivacyEnum Privacy { get; set; } = default!;
    public string Thumbnail { get; set; } = default!;
    public AccountDisplayModel Author { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModificatedOn { get; set; }
}
