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
    public PrivacyEnum Privacy { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public AccountArtworkVM Account { get; set; } = default!;
    public List<CategoryArtworkVM> CategoryArtworkDetails { get; set; } = default!;
    public List<TagDetailVM> TagDetails { get; set; } = default!;
    public List<AssetVM>? Assets { get; set; }
    public List<ImageVM> Images { get; set; } = default!;
    public List<Like> Likes { get; set; } = new List<Like>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<ServiceDetail>? ServiceDetails { get; set; }
    public class AccountArtworkVM
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Fullname { get; set; } = default!;
        public string? Avatar { get; set; }
    }
}

// View model for search results
public class ArtworkPreviewVM
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Thumbnail { get; set; } = default!; 
    public PrivacyEnum Privacy { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModificatedOn { get; set; }

    public List<CategoryArtworkDetail> CategoryArtworkDetails { get; set; } = new List<CategoryArtworkDetail>();
}
public class SearchArtworkCriteria
{
    public string? Key { get; set; }
    public string? Category { get; set; }
    public string? Sort { get; set; }
    public string? Order { get; set; }
}