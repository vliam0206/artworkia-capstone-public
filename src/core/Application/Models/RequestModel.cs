using System.ComponentModel.DataAnnotations;

namespace Application.Models;
public class RequestModel
{
    public Guid ServiceId { get; set; }
    [MaxLength(255)]
    [Required]
    public string Message { get; set; } = default!;
    [MaxLength(150)]
    [Required]
    public string Timeline { get; set; } = default!;
}
