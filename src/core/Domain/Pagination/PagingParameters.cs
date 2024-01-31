namespace Domain.Pagination;

public class PagingParameters
{
    const int maxPageSize = 50;

    public string? sortBy { set; get; }
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize; 
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}   
