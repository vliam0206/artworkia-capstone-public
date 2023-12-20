using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class TagModel
{
    [MaxLength(150)]
    [Required]
    public string TagName { get; set; } = default!;
}
