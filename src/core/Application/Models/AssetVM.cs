using Firebase.Storage;

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
    public bool IsBought { get; set; } = default!;
    public FirebaseMetaData FileMetaData { get; set; } = default!;
    public DateTime? LastModificatedOn { get; set; }
}
