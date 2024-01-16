using Domain.Entitites;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;

// View model for view details of an artwork
public class ArtworkVM
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Thumbnail { get; set; } = default!; // url address
    public int ViewCount { get; set; } = 999;
    public int LikeCount { get; set; } = 99;
    public int CommentCount { get; set; } = 5;
    public int BookmarkCount { get; set; } = 12;
    public PrivacyEnum Privacy { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public AccountBasicInfoVM Account { get; set; } = default!;
    public List<CategoryVM> CategoryList { get; set; } = default!;
    public List<TagVM> TagList { get; set; } = default!;
    public List<AssetVM>? Assets { get; set; }
    public List<ImageVM> Images { get; set; } = default!;
    public List<CommentVM>? Comments { get; set; }
}

// View model for search results
public class ArtworkPreviewVM
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Thumbnail { get; set; } = default!;
    public int ViewCount { get; set; } = 999;
    public int LikeCount { get; set; } = 99;
    public int CommentCount { get; set; } = 5;
    public int BookmarkCount { get; set; } = 12;
    public PrivacyEnum Privacy { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
}

public class SearchArtworkCriteria
{
    public string? Key { get; set; }
    public string? Category { get; set; }
    public string? Sort { get; set; }
    public string? Order { get; set; }
}