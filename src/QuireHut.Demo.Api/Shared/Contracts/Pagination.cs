namespace QuireHut.Demo.Api.Contracts.Responses;

public record Pagination
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }

    public static Pagination CreateNew(int currentPage, int pageSize, int totalRecords)
    {
        var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

        return new Pagination
        {
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalPages = totalPages,
            TotalRecords = totalRecords,
            HasPrevious = currentPage > 1,
            HasNext = currentPage < totalPages
        };
    }
}
