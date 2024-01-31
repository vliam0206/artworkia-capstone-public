namespace WebApi.ViewModels.Commons;
public class ListApiResponse
{
    public int CurrentPage { get; set; } // trang hien tai
    public int TotalPages { get; set; } // tong so trang
    public int PageSize { get; set; } // so luong item tren 1 trang
    public int TotalCount { get; set; } // tong so item
    public bool HasPrevious => CurrentPage > 1; // co trang truoc
    public bool HasNext => CurrentPage < TotalPages; // co trang sau
    public object? ItemList { get; set; }
}
