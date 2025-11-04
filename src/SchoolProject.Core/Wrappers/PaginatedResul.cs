namespace SchoolProject.Core.Wrappers;

public class PaginatedResult<T>
{
    public PaginatedResult(List<T> data)
    {
        Data = data;
    }
    public PaginatedResult(bool succeeded, List<T> data = default, int count = 0, int page = 1, int pageSize = 10)
    {
        Data = data;
        CurrentPage = page;
        Succeeded = succeeded;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
    }
    
    public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
    {
        return new(true, data, count, page, pageSize);
    }
    
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public List<T> Data { get; set; }
    public bool Succeeded { get; set; }
}