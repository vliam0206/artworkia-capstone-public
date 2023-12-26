using Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class CommentModel
{
    [Required]
    public string CommentText { get; set; } = default!;
}

public class CommentVM
{
    public Guid Id { get; set; }
    public Guid? ReplyId { get; set; }
    public Guid ArtworkId { get; set; }
    public Guid? CreatedBy { get; set; }
    public string Content { get; set; } = default!;    
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
    public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
}
