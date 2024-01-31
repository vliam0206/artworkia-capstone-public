namespace Domain.Pagination;

public class PagedList<T> : List<T>
{
    public int CurrentPage { get; private set; } // trang hien tai
    public int TotalPages { get; private set; } // tong so trang
    public int PageSize { get; private set; } // so luong item tren 1 trang
    public int TotalCount { get; private set; } // tong so item
    public bool HasPrevious => CurrentPage > 1; // co trang truoc
    public bool HasNext => CurrentPage < TotalPages; // co trang sau
    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    public static PagedList<T> GetPagedList(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items =  source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}
