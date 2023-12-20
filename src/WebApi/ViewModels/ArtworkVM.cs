using Domain.Entitites;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class ArtworkVM
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string Description { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; } = DateTime.UtcNow.ToLocalTime();
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
}
