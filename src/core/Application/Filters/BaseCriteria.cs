namespace Domain.Entities.Commons;

public class BaseCriteria
{
    const int maxPageSize = 50;

    public string? Keyword { set; get; }
    public string? SortColumn { set; get; }
    public string? SortOrder { set; get; }
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}
