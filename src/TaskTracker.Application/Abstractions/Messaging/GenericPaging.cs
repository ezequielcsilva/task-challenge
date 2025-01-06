using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Application.Abstractions.Messaging;

public static class GenericPaging
{
    public static Paginated<T> Page<T>(this IQueryable<T> query, int pageNumStart, int pageSize)
    {
        var totalCount = query.Count();
        var skipAmount = (pageNumStart - 1) * pageSize;

        var pagedData = query.Skip(skipAmount).Take(pageSize);

        return new Paginated<T>(pagedData, totalCount, pageNumStart, pageSize);
    }
}

public class Paginated<T>(IEnumerable<T> data, int count, int currentPage, int pageSize)
{
    public int CurrentPage { get; } = currentPage;
    public int TotalPages { get; } = (int)Math.Ceiling(count / (double)pageSize);
    public int Count { get; private set; } = count;
    public int PageSize { get; private set; } = pageSize;
    public IEnumerable<T> Data { get; private set; } = data.ToArray();

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
}

public class PaginatedOptions
{
    [Required]
    [Range(1, int.MaxValue)]
    public int CurrentPage { get; set; } = 1;

    [Required]
    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = 10;
}