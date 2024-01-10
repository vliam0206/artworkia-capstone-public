namespace Application.Models;

public class AssetVM
{
    public Guid Id { get; set; }
    public Guid ArtworkId { get; set; }
    public int Order { get; set; } 
    public string AssetTitle { get; set; } = default!; 
    public string Description { get; set; } = default!;
    public string AssetName { get; set; } = default!; 
    public double Price { get; set; } = 0;
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
}
