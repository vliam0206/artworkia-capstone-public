using Nest;

namespace Application.Models;

public class ArtworksV2
{
    public Guid Id { get; set; }
    [Keyword]
    public string Title { get; set; } = default!;
    [Keyword]
    public string Description { get; set; } = default!;
    public string Thumbnail { get; set; } = default!; // url address
    public int ViewCount { get; set; } = default!;
    public int LikeCount { get; set; } = default!;
    public int CommentCount { get; set; } = default!;
    public string Privacy { get; set; } = default!;
    public string State { get; set; } = default!;
    public bool IsAIGenerated { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public AccountBasicInfoVM Account { get; set; } = default!;
    public LicenseTypeVM LicenseType { get; set; } = default!;
    public List<CategoryVM> CategoryList { get; set; } = default!;
    public List<TagVM> TagList { get; set; } = default!;
    public List<SoftwareUsedVM> SoftwareUseds { get; set; } = default!;
    public List<AssetVM>? Assets { get; set; }
    public List<ImageVM> Images { get; set; } = default!;
}