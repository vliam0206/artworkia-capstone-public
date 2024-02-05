using Domain.Entities.Commons;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Artwork : BaseEntity, ICreation, IModification, ISoftDelete
{
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(1000)]
    public string? Description { get; set; }
    public string Thumbnail { get; set; } = default!; // url address
    public string ThumbnailName { get; set; } = default!; // can ten thumbnail de xoa anh tren firebase
    public int ViewCount { get; set; } = default!;
    public int LikeCount { get; set; } = default!;
    public int CommentCount { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; } = default!;
    public StateEnum State { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual ICollection<CategoryArtworkDetail> CategoryArtworkDetails { get; set; } = new List<CategoryArtworkDetail>();
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<TagDetail> TagDetails { get; set; } = new List<TagDetail>();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
    public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();

}
