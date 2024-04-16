using Domain.Entitites;

namespace Application.Models;

public class TopCreatorOfAssetTransVM
{
    public AccountBasicInfoVM Creator { get; set; } = default!;
    public int TotalBought { get; set; } //sô lượng được mua
    public double? TotalRevenue { get; set; } // doanh thu
}