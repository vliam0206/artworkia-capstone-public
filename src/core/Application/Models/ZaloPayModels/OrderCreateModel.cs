using System.ComponentModel.DataAnnotations;

namespace Application.Models.ZaloPayModels;

public class OrderCreateModel
{
    [Required]
    public long Amount { get; set; }
    [Required]
    public string Item { get; set; } = default!;
    public string BankCode { get; set; } = "";
    [Required]
    public string EmbedData { get; set; } = default!;
    //[Required]
    //public string CallbackUrl { get; set; } = default!;
}
