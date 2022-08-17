namespace Arditi;

public sealed class Pagination
{
    public static Pagination New(int pageIndex, int pageSize, int indexFrom = 0) =>
        new(indexFrom, pageIndex, pageSize);

    private Pagination(int indexFrom, int pageIndex, int pageSize)
    {
        IndexFrom = Check.Range(indexFrom, nameof(indexFrom), 0, 1);
        PageIndex = Check.Range(pageIndex, nameof(pageIndex), IndexFrom);
        PageSize = Check.Range(pageSize, nameof(pageSize), 1);
    }

    private Pagination(int pageIndex, int pageSize, int indexFrom, int totalCount) : this(pageIndex, pageSize,
        indexFrom)
    {
        TotalCount = Check.Range(totalCount, nameof(totalCount), 0);
        if (TotalCount > 0)
        {
            TotalPages = TotalCount % PageSize + 1;
            HasPreviousPage = PageIndex - IndexFrom > 0;
            HasNextPage = PageIndex - IndexFrom < TotalPages;
        }
        else
        {
            TotalPages = 0;
            HasPreviousPage = false;
            HasNextPage = false;
        }
    }

    public Pagination Fill(int totalCount) => new(PageIndex, PageSize, IndexFrom, totalCount);

    public int IndexFrom { get; }

    public int PageIndex { get; }

    public int PageSize { get; }

    public int? TotalCount { get; }

    public int? TotalPages { get; }

    public bool? HasPreviousPage { get; }

    public bool? HasNextPage { get; }
}
