using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;
public class TagVM
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string TagName { get; set; } = default!;
}
