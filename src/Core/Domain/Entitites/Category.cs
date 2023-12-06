using Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entitites;

public class Category : BaseEntity
{
    [MaxLength(255)]
    public string CategoryName { get; set; } = default!;
    public Guid? ParentCategory { get; set; }

    public virtual Category? Parent { get; set; }
    public virtual ICollection<Category> Children { get; set; } = new List<Category>();
    public virtual ICollection<CategoryServiceDetail> CategoryServiceDetails { get; set; } = new List<CategoryServiceDetail>();
}
