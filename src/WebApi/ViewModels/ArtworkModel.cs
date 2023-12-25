using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class ArtworkModel
{
    [MaxLength(150)]
    public string Title { get; set; } = default!;
    [MaxLength(255)]
    public string Description { get; set; } = default!;
    public PrivacyEnum Privacy { get; set; } = default!;
}
